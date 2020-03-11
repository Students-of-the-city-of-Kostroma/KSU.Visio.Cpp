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
	/// Класс для "Действия"
	/// </summary>
	public class PaiRect
	{
		PictureBox picture = new PictureBox();
		public PaiRect(PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод создания "Действия"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Ris(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Image newImage = Library.Properties.Resources.Deystviya;
			Point ulCorner = new Point(x1 - 63, y1);
			Graphics gr = picture.CreateGraphics();
			gr.DrawImage(newImage, ulCorner);
			gr.Dispose();
			return picture;
		}
		/// <summary>
		/// Метод перерисовки "Действия"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Image newImage = Library.Properties.Resources.Deystviya;
			Point ulCorner = new Point(x1 - 63, y1);
			Graphics gr = picture.CreateGraphics();
			gr.DrawImage(newImage, ulCorner);
			gr.Dispose();
			return picture;
		}
	}
}
