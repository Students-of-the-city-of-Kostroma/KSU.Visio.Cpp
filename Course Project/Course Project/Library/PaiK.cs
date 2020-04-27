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
	/// Класс "Эллипс"
	/// </summary>
	public class PaiK
	{
		PictureBox picture = new PictureBox();
		public PaiK (PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод для рисования "Эллипс"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Ris (MouseEventArgs e)
		{
            int x1 = e.X;
            int y1 = e.Y;
            Pen p = new Pen(Color.Black, 3);
            Graphics gr = picture.CreateGraphics();
            gr.DrawEllipse(p, x1, y1, 150, 80);
            gr.Dispose();
            return picture;
        }
		/// <summary>
		/// Метод для перерисовки "Эллипс"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e)
		{
            int x1 = e.X;
            int y1 = e.Y;
            Pen p = new Pen(Color.Black, 3);
            Graphics gr = picture.CreateGraphics();
            gr.DrawEllipse(p, x1, y1, 150, 80);
            gr.Dispose();
            return picture;
        }
	}
}
