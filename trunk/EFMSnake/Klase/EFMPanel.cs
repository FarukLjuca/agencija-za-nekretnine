using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFMSnake.Klase
{
	public class EFMPanel : Panel
	{
		public EFMPanel()
		{
			this.DoubleBuffered = true;
			this.SetStyle (ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}
