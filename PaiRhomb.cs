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
	/// Класс "Решения"
	/// </summary>
	public class PaiRhomb
	{
		PictureBox picture = new PictureBox();
		public PaiRhomb(PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод для рисования "Решения"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Ris(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Image newImage = Library.Properties.Resources.Resheniya;
			Point ulCorner = new Point(x1 - 40, y1);
			Graphics gr = picture.CreateGraphics();
			gr.DrawImage(newImage, ulCorner);
			gr.Dispose();
			return picture;
		}
		/// <summary>
		/// Метод для перерисовки "Решения"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Image newImage = Library.Properties.Resources.Resheniya;
			Point ulCorner = new Point(x1 - 40, y1);
			Graphics gr = picture.CreateGraphics();
			gr.DrawImage(newImage, ulCorner);
			gr.Dispose();
			return picture;
		}
	}
}
