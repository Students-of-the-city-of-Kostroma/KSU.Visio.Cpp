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
	/// Класс для "Актёра"
	/// </summary>
	public class PaiA
	{
		PictureBox picture = new PictureBox();
		public PaiA(PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод создания "Актёра"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Ris(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Pen p = new Pen(Color.Black, 3);
			Graphics gr = picture.CreateGraphics();
            gr.DrawEllipse(p, x1, y1, 30, 30);
            Point[] points = { new Point(x1+15, y1+34), new Point(x1+15, y1 +70), new Point(x1 , y1 + 110), new Point(x1 + 15, y1 + 70), new Point(x1 + 30, y1 + 110), new Point(x1 + 15, y1 + 70), new Point(x1 + 15, y1 + 34), new Point(x1 , y1 + 72), new Point(x1 + 15, y1 + 34), new Point(x1 + 30, y1 + 72), new Point(x1 + 15, y1 + 34) };
			gr.DrawPolygon(p, points);
			gr.Dispose();
			return picture;
		}
		/// <summary>
		/// Метод перерисовки "Актёра"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e)
		{
			Pen p = new Pen(Color.Black,3);
			Graphics gr = picture.CreateGraphics();
			int x1 = e.X;
			int y1 = e.Y;
            gr.DrawEllipse(p, x1, y1, 30, 30);
            Point[] points = { new Point(x1 + 15, y1 + 34), new Point(x1 + 15, y1 + 70), new Point(x1, y1 + 110), new Point(x1 + 15, y1 + 70), new Point(x1 + 30, y1 + 110), new Point(x1 + 15, y1 + 70), new Point(x1 + 15, y1 + 34), new Point(x1, y1 + 72), new Point(x1 + 15, y1 + 34), new Point(x1 + 30, y1 + 72), new Point(x1 + 15, y1 + 34) };
            gr.DrawPolygon(p, points);
            return picture;
		}
	}
}
