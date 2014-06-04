using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFMSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            popuniCbb();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            About win2 = new About();
            win2.Show();
        }

        private void popuniCbb()
        {
            for (int i = 1; i < 10; i++)
            {
                BitmapImage im = new BitmapImage(new Uri("Slike.g" + i));
                cbbGlava.Items.Add(im);
            }
        }
    }
}
