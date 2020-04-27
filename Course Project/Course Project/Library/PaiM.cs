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
	/// Класс "Ограничение ИЛИ"
	/// </summary>
	public class PaiM
	{
		PictureBox picture = new PictureBox();
		public PaiM(PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод для создания "Ограничение ИЛИ"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		/// <returns></returns>
		public PictureBox Ris(MouseEventArgs e, MouseEventArgs e2, TextBox textBox, ref Queue<string> SaveText)
		{
            int x1 = e.X;
            int y1 = e.Y;
            Graphics gr = picture.CreateGraphics();
            SaveText.Enqueue(textBox.Text);
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            int x2 = textBox.Text.Length;
            gr.DrawString(textBox.Text, new Font("Times New Roman", 10), Brushes.Black, new PointF(x1 , y1));
            gr.Dispose();
            return picture;
            /*    String drawString = "Текст";
            Font drawFont = new Font("Arial", 9);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF(x1, y1);
            Graphics gr = picture.CreateGraphics();
			gr.DrawString(drawString, drawFont, drawBrush, drawPoint);
            gr.Dispose();
			return picture;*/
        }
		/// <summary>
		/// Метод для перерисовки "Ограничение ИЛИ"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e, MouseEventArgs e2, TextBox textBox, ref string[] mas, int i)
		{
            int x1 = e.X;
            int y1 = e.Y;
            string x = "";
            Graphics gr = picture.CreateGraphics();
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            x = mas[i];
            int x2 = x.Length;
            gr.DrawString(mas[i], new Font("Times New Roman", 10), Brushes.Black, new PointF(x1, y1));
            gr.Dispose();
            return picture;
        }
	}
}
