using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Library
{
	/// <summary>
	/// Класс "Схождение действий"
	/// </summary>
	public class PaiIHevyLine
	{
		PictureBox picture = new PictureBox();
		public PaiIHevyLine(PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод для рисования "Схождение действий"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Ris(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Image newImage = Library.Properties.Resources.Skhozhdeniye_deystviy;
			Point ulCorner = new Point(x1 - 110, y1);
			Graphics gr = picture.CreateGraphics();
			gr.DrawImage(newImage, ulCorner);
			gr.Dispose();
			return picture;
		}
		/// <summary>
		/// Метод для перерисовки "Схождение действий"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Image newImage = Library.Properties.Resources.Skhozhdeniye_deystviy;
			Point ulCorner = new Point(x1 - 110, y1);
			Graphics gr = picture.CreateGraphics();
			gr.DrawImage(newImage, ulCorner);
			gr.Dispose();
			return picture;
		}
	}
}
