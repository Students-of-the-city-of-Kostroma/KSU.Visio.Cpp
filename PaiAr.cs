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
	/// Класс "Стрелка"
	/// </summary>
	public class PaiAr
	{
		PictureBox picture = new PictureBox();
		public PaiAr(PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод для рисования "Стрелка"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		/// <returns></returns>
		public PictureBox Ris(MouseEventArgs e, MouseEventArgs e2)
		{
			float x1 = e.X;
			float y1 = e.Y;
			float x2 = e2.X;
			float y2 = e2.Y;
			Pen p = new Pen(Color.Black, 3);
			p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			Graphics gr = picture.CreateGraphics();
			gr.DrawLine(p, x1, y1, x2, y2);
			gr.Dispose();
			return picture;
		}
		/// <summary>
		/// Метод для перерисолвки "Стрелка"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e, MouseEventArgs e2)
		{
			Graphics gr = picture.CreateGraphics();
			float x1 = e.X;
			float y1 = e.Y;
			float x2 = e2.X;
			float y2 = e2.Y;
			Pen pe = new Pen(Color.Black, 3);
			pe.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			gr.DrawLine(pe, x1, y1, x2, y2);
			pe.Dispose();
			return picture;
		}

	}
}
