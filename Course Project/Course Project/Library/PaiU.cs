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
	/// Класс "Примечание"и "Ограничение"
	/// </summary>
	public class PaiU
	{
		PictureBox picture = new PictureBox();
		public PaiU(PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод для рисования "Примечание"и "Ограничение"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Ris(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Pen p = new Pen(Color.Blue);
			Graphics gr = picture.CreateGraphics();
			Point[] points = { new Point(x1, y1), new Point(x1, y1 + 80), new Point(x1 + 90, y1 + 80), new Point(x1 + 90, y1 + 25), new Point(x1 + 75, y1 + 25), new Point(x1 + 75, y1), new Point(x1 + 90, y1 + 25), new Point(x1 + 75, y1) };
			gr.DrawPolygon(p, points);
			gr.Dispose();
			return picture;
		}
		/// <summary>
		/// Метод для перерисовки "Примечание"и "Ограничение"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e)
		{
			Pen p = new Pen(Color.Blue);
			Graphics gr = picture.CreateGraphics();
			int x1 = e.X;
			int y1 = e.Y;
			Point[] points = { new Point(x1, y1), new Point(x1, y1 + 80), new Point(x1 + 90, y1 + 80), new Point(x1 + 90, y1 + 25), new Point(x1 + 75, y1 + 25), new Point(x1 + 75, y1), new Point(x1 + 90, y1 + 25), new Point(x1 + 75, y1) };
			gr.DrawPolygon(p, points);
			return picture;
		}
	}
}
