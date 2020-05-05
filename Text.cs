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
    /// Класс "Написание текста"
    /// </summary>
    public class TextBox1
    {
        PictureBox picture = new PictureBox();
        public TextBox1(PictureBox picture)
        {
            this.picture = picture;
        }
        /// <summary>
        /// Метод для рисования "Наисание текста"
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public PictureBox Ris(MouseEventArgs e, TextBox textBox, ref Queue<string> SaveText)
        {
            int x1 = e.X;
            int y1 = e.Y;
            Graphics gr = picture.CreateGraphics();
            SaveText.Enqueue(textBox.Text);
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            gr.DrawString(textBox.Text, new Font("Times New Roman", 10), Brushes.Black, new PointF(x1 , y1));
            gr.Dispose();
            return picture;
        }
        /// <summary>
        /// Метод для перерисолвки "Написание текста"
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public PictureBox Paint(MouseEventArgs e, TextBox textBox, ref string[] mas, int i)
        {
            int x1 = e.X;
            int y1 = e.Y;
            string x = " ";
            Graphics gr = picture.CreateGraphics();
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            x = mas[i];
            gr.DrawString(mas[i], new Font("Times New Roman", 10), Brushes.Black, new PointF(x1, y1));
            gr.Dispose();
            return picture;
        }

    }
}
