using DataMatrix.net;
using Microsoft.Expression.Encoder.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebcamControl;

namespace EFM
{
	/// <summary>
	/// Interaction logic for FrmCam.xaml
	/// </summary>
	public partial class FrmCam : Window
	{
		public FrmCam()
		{
			InitializeComponent ();
			Binding B = new Binding ("SelectedValue");
			B.Source = CBDev;
			WCAM.SetBinding (Webcam.VideoDeviceProperty, B);
			var Devs = EncoderDevices.FindDevices (EncoderDeviceType.Video);
			CBDev.ItemsSource = Devs;
			CBDev.SelectedIndex = 0;
			
			WCAM.FrameRate = 60;
			WCAM.FrameSize = new System.Drawing.Size (640, 480);
			WCAM.StartCapture ();
		}

		private void BtnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close ();
		}


		public static Bitmap sharpen(Bitmap image)
		{
			Bitmap sharpenImage = new Bitmap (image.Width, image.Height);

			int filterWidth = 3;
			int filterHeight = 3;
			int w = image.Width;
			int h = image.Height;

			double[,] filter = new double[filterWidth, filterHeight];

			filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
			filter[1, 1] = 9;

			double factor = 1.0;
			double bias = 0.0;

			System.Drawing.Color[,] result = new System.Drawing.Color[image.Width, image.Height];

			for (int x = 0; x < w; ++x)
			{
				for (int y = 0; y < h; ++y)
				{
					double red = 0.0, green = 0.0, blue = 0.0;
					for (int filterX = 0; filterX < filterWidth; filterX++)
					{
						for (int filterY = 0; filterY < filterHeight; filterY++)
						{
							int imageX = (x - filterWidth / 2 + filterX + w) % w;
							int imageY = (y - filterHeight / 2 + filterY + h) % h;

							//=====[INSERT LINES]========================================================
							// Get the color here - once per fiter entry and image pixel.
							System.Drawing.Color iimageColor = image.GetPixel (imageX, imageY);
							//===========================================================================

							red += iimageColor.R * filter[filterX, filterY];
							green += iimageColor.G * filter[filterX, filterY];
							blue += iimageColor.B * filter[filterX, filterY];
						}
						int r = Math.Min (Math.Max ((int) (factor * red + bias), 0), 255);
						int g = Math.Min (Math.Max ((int) (factor * green + bias), 0), 255);
						int b = Math.Min (Math.Max ((int) (factor * blue + bias), 0), 255);

						result[x, y] = System.Drawing.Color.FromArgb (r, g, b);
					}
				}
			}
			for (int i = 0; i < w; ++i)
			{
				for (int j = 0; j < h; ++j)
				{
					sharpenImage.SetPixel (i, j, result[i, j]);
				}
			}
			return sharpenImage;
		}

		public static Bitmap ConvertTo1Bit(Bitmap input)
		{
			var masks = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
			var output = new Bitmap (input.Width, input.Height, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
			var data = new sbyte[input.Width, input.Height];
			var inputData = input.LockBits (new System.Drawing.Rectangle (0, 0, input.Width, input.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			try
			{
				var scanLine = inputData.Scan0;
				var line = new byte[inputData.Stride];
				for (var y = 0; y < inputData.Height; y++, scanLine += inputData.Stride)
				{
					System.Runtime.InteropServices.Marshal.Copy (scanLine, line, 0, line.Length);
					for (var x = 0; x < input.Width; x++)
					{
						data[x, y] = (sbyte) (64 * (GetGreyLevel (line[x * 3 + 2], line[x * 3 + 1], line[x * 3 + 0]) - 0.5));
					}
				}
			}
			finally
			{
				input.UnlockBits (inputData);
			}
			var outputData = output.LockBits (new System.Drawing.Rectangle (0, 0, output.Width, output.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
			try
			{
				var scanLine = outputData.Scan0;
				for (var y = 0; y < outputData.Height; y++, scanLine += outputData.Stride)
				{
					var line = new byte[outputData.Stride];
					for (var x = 0; x < input.Width; x++)
					{
						var j = data[x, y] > 0;
						if (j) line[x / 8] |= masks[x % 8];
						var error = (sbyte) (data[x, y] - (j ? 32 : -32));
						if (x < input.Width - 1) data[x + 1, y] += (sbyte) (7 * error / 16);
						if (y < input.Height - 1)
						{
							if (x > 0) data[x - 1, y + 1] += (sbyte) (3 * error / 16);
							data[x, y + 1] += (sbyte) (5 * error / 16);
							if (x < input.Width - 1) data[x + 1, y + 1] += (sbyte) (1 * error / 16);
						}
					}
					System.Runtime.InteropServices.Marshal.Copy (line, 0, scanLine, outputData.Stride);
				}
			}
			finally
			{
				output.UnlockBits (outputData);
			}
			return output;
		}

		public static double GetGreyLevel(byte r, byte g, byte b)
		{
			return (r * 0.299 + g * 0.587 + b * 0.114) / 255;
		}
		private string DecodeText(Bitmap b)
		{
			DmtxImageDecoder decoder = new DmtxImageDecoder ();
			System.Drawing.Bitmap oBitmap = new System.Drawing.Bitmap (b);
			List<string> oList = decoder.DecodeImage (oBitmap);

			StringBuilder sb = new StringBuilder ();
			sb.Length = 0;
			foreach (string s in oList)
			{
				sb.Append (s);
			}
			return sb.ToString ();
		}
		private void BtnOK_Click(object sender, RoutedEventArgs e)
		{
			//WCAM.SnapshotFormat = System.Drawing.Imaging.ImageFormat.Png;
			//WCAM.ImageDirectory = Environment.GetEnvironmentVariable ("TEMP");
			Bitmap B = WCAM.TakeSnapshot ();
			//byte [] b = GetJpgImage (BtnOK, 1.0, 100);
			//Bitmap B = (Bitmap) Bitmap.FromStream (new MemoryStream (b));
			B.Save ("nesto.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
			ImageProcessor.ImageProcessor up = new ImageProcessor.ImageProcessor ();
			up.SetImage (B);
			up.ApplySharpen (50.5);

			//Bitmap B2 = ConvertTo1Bit (B);
			//B2.Save ("nesto2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
			System.Collections.ArrayList A = new System.Collections.ArrayList();
			BarcodeImaging.FullScanPage (ref A, B, 30000);
			//System.Windows.MessageBox.Show (DecodeText (B));
			if (A.Count > 0)
			{
				System.Windows.MessageBox.Show ("Pronađeno: " + A[0].ToString());
			}
			else
			{ System.Windows.MessageBox.Show ("Nema bar kôda..."); }
			
			//WCAM.TakeSnapshot ();
		}

		public static byte[] GetJpgImage(UIElement source, double scale, int quality)
		{
			double actualHeight = source.RenderSize.Height;
			double actualWidth = source.RenderSize.Width;

			double renderHeight = actualHeight * scale;
			double renderWidth = actualWidth * scale;

			RenderTargetBitmap renderTarget = new RenderTargetBitmap ((int) renderWidth, (int) renderHeight, 96, 96, PixelFormats.Pbgra32);
			VisualBrush sourceBrush = new VisualBrush (source);

			DrawingVisual drawingVisual = new DrawingVisual ();
			DrawingContext drawingContext = drawingVisual.RenderOpen ();

			using (drawingContext)
			{
				drawingContext.PushTransform (new ScaleTransform (scale, scale));
				drawingContext.DrawRectangle (sourceBrush, null, new Rect (new System.Windows.Point (0, 0), new System.Windows.Point (actualWidth, actualHeight)));
			}
			renderTarget.Render (drawingVisual);

			JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder ();
			jpgEncoder.QualityLevel = quality;
			jpgEncoder.Frames.Add (BitmapFrame.Create (renderTarget));

			Byte[] _imageArray;

			using (MemoryStream outputStream = new MemoryStream ())
			{
				jpgEncoder.Save (outputStream);
				_imageArray = outputStream.ToArray ();
			}

			return _imageArray;
		}
	}
}
