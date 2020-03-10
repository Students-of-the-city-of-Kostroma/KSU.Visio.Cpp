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
	/// Класс "Окончание процесса"
	/// </summary>
	public class PaiCircleS
	{
		PictureBox picture = new PictureBox();
		public PaiCircleS(PictureBox picture)
		{
			this.picture = picture;
		}
		/// <summary>
		/// Метод для рисования "Окончание процесса"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Ris(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Image newImage = Library.Properties.Resources.Okonchaniye_protsessa;
			Point ulCorner = new Point(x1 - 15, y1);
			Graphics gr = picture.CreateGraphics();
			gr.DrawImage(newImage, ulCorner);
			gr.Dispose();
			return picture;
		}
		/// <summary>
		/// Метод для перерисовки "Окончание процесса"
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public PictureBox Paint(MouseEventArgs e)
		{
			int x1 = e.X;
			int y1 = e.Y;
			Image newImage = Library.Properties.Resources.Okonchaniye_protsessa;
			Point ulCorner = new Point(x1 - 15, y1);
			Graphics gr = picture.CreateGraphics();
			gr.DrawImage(newImage, ulCorner);
			gr.Dispose();
			return picture;
		}
	}
}
