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
	/// Класс "Прямоугольник"
	/// </summary>
	public class PaiP
	{
		PictureBox picture = new PictureBox();
		public PaiP(PictureBox picture)
		{
			this.picture = picture;
		}
        /// <summary>
        /// Метод для рисования "Прямоугольник"
        /// </summary>
        /// <param name="e"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public PictureBox Ris(MouseEventArgs e, MouseEventArgs e2)
        {
            int x1 = e.X;
            int y1 = e.Y;
            int x2 = e2.X;
            int y2 = e2.Y;
            Pen p = new Pen(Color.Black, 3);
            Graphics gr = picture.CreateGraphics();
            Point[] points = { new Point(x1, y1), new Point(x2, y1 ), new Point(x2, y2), new Point(x1, y2)};
            gr.DrawPolygon(p,points);
            gr.Dispose();
            return picture;
        }
        /// <summary>
        /// Метод для перерисовки "Прямоугольник"
        /// </summary>
        /// <param name="e"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public PictureBox Paint(MouseEventArgs e, MouseEventArgs e2)
        {
            int x1 = e.X;
            int y1 = e.Y;
            int x2 = e2.X;
            int y2 = e2.Y;
            Pen p = new Pen(Color.Black, 3);
            Graphics gr = picture.CreateGraphics();
            Point[] points = { new Point(x1, y1), new Point(x2, y1), new Point(x2, y2), new Point(x1, y2) };
            gr.DrawPolygon(p, points);
            gr.Dispose();
            return picture;
        }
    }
}
