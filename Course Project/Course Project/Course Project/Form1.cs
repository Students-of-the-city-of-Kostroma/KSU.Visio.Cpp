using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Drawing.Drawing2D.LineCap;
using Library;

namespace Course_Project
{
	public partial class Form1 : Form
	{
		public Form1()
		{

			InitializeComponent();
		}
		/// <summary>
		///  для сохранения
		/// </summary>
		Saved sev = new Saved();
		delegate void del (MouseEventArgs e);
		/// <summary>
		/// Делегат для компонентов в виде фигур
		/// </summary>
		del deli;
		delegate void del2 (MouseEventArgs e, MouseEventArgs e2);
		/// <summary>
		/// Делегат для компонентов в виде прямых
		/// </summary>
		del2 deli2;
        Queue<string> SaveText = new Queue<string>();
        // Обработка событий MouseEnter и MousLeave для изображений
        #region
        /// <summary>
        /// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Узел";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox2_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox1_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Компонент";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox1_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox3_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Пакет";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox3_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox4_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Интерфейс";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox4_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox5_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Зависимость";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox5_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox6_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Ограничение";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox6_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox7_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Примечание";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox7_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox8_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Ограничение 2 элементов";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox8_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Labael
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox9_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Ограничение ИЛИ";
		}
		/// <summary>
		/// Метод вызываемый при покидании курсора мыши с выбираемого компонента, очищает Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox9_MouseLeave(object sender, EventArgs e)
		{
			label1.Text = "";
		}
		#endregion
		/// <summary>
		/// Переменная класса MouseEventArgs, необходима для задания начала линии
		/// </summary>
		MouseEventArgs Ef;
		/// <summary>
		/// Переменная класса MouseEventArgs, необходима для задания начала линии
		/// </summary>
		MouseEventArgs Ef2;
		/// <summary>
		/// Метод определяющий какой из элементов удерживается
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox2_MouseDown(object sender, MouseEventArgs e) 
		{
			if (sender == pictureBox2)
			{
				deli = PaiC;
				deli2 = null;
			}
			if (sender == pictureBox1)
			{
				deli = PaiK;
				deli2 = null;
			}
			if (sender == pictureBox4)
			{
				deli2 = PaiI;
				deli = null;
			}
			if (sender == pictureBox5)
			{
				deli2 = PaiS;
				deli = null;
			}
			if (sender == pictureBox8) 
			{
				deli = null;
				deli2 = PaiL;
			}
			if (sender == pictureBox3)
			{
				deli = null;
				deli2 = PaiM;
			}

		}
		/// <summary>
		/// Метод для рисования "Узла"
		/// </summary>
		/// <param name="e"></param>
		private void PaiK(MouseEventArgs e)
		{
			PaiK paiK = new PaiK(picture);
			picture= paiK.Ris(e);
			sev.Component.Add(e);
		}
		/// <summary>
		/// Метод для рисования "Компонента"
		/// </summary>
		/// <param name="e"></param>
		private void PaiC(MouseEventArgs e)
		{
			PaiC paiC = new PaiC(picture);
			paiC.Ris(e);
			sev.Unit.Add(e);
			
		}
		/// <summary>
		/// Метод для рисования "Интерфейса"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		private void PaiI(MouseEventArgs e, MouseEventArgs e2)
		{
			PaiI paiI = new PaiI(picture);
			paiI.Ris(e, e2);
			sev.Intrf.Add(e);
			sev.Intrf.Add(e2);
		}
		/// <summary>
		/// Метод для рисования "Зависимости"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		private void PaiS(MouseEventArgs e, MouseEventArgs e2)
		{
			PaiS paiS = new PaiS(picture);
			paiS.Ris(e, e2);
			sev.Zav.Add(e);
			sev.Zav.Add(e2);
		}
		/// <summary>
		/// Метод для рисования "Ограничения 2 элементов"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		private void PaiL (MouseEventArgs e, MouseEventArgs e2)
		{
			PaiL paiL = new PaiL(picture);
			paiL.Ris(e, e2);
			sev.Organ2.Add(e);
			sev.Organ2.Add(e2);
		}
		/// <summary>
		/// Метод для рисования "Ограничения ИЛИ"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		private void PaiM(MouseEventArgs e, MouseEventArgs e2)
		{
			PaiM paiM = new PaiM(picture);
			paiM.Ris(e, e2, textBox1, ref SaveText);
			sev.OrganOR.Add(e);
			sev.OrganOR.Add(e2);
		}
		/// <summary>
		/// Рисование компонентов в виде фигур после клика мышью по форме
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void picture_MouseClick(object sender, MouseEventArgs e)
		{
			if (deli != null)
			{
				deli(e);
			}
			if (this.Cursor==Cursors.Hand)
			{
				for (int i = 0; i < sev.Component.Count(); i++)
				{
					if (e.X < sev.Component[i].X + 3 && e.X > sev.Component[i].X - 3 && e.Y < sev.Component[i].Y + 3 && e.Y > sev.Component[i].Y - 3)
					{
						sev.Component.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.Unit.Count(); i++)
				{
					if (e.X < sev.Unit[i].X + 3 && e.X > sev.Unit[i].X - 3 && e.Y < sev.Unit[i].Y + 3 && e.Y > sev.Unit[i].Y - 3)
					{
						sev.Unit.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.Prim.Count(); i++)
				{
					if (e.X < sev.Prim[i].X + 3 && e.X > sev.Prim[i].X - 3 && e.Y < sev.Prim[i].Y + 3 && e.Y > sev.Prim[i].Y - 3)
					{
						sev.Prim.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.Pac.Count(); i++)
				{
					if (e.X < sev.Pac[i].X + 3 && e.X > sev.Pac[i].X - 3 && e.Y < sev.Pac[i].Y + 3 && e.Y > sev.Pac[i].Y - 3)
					{
						sev.Pac.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.Intrf.Count(); i++)
				{
					if (e.X < sev.Intrf[i].X + 3 && e.X > sev.Intrf[i].X - 3 && e.Y < sev.Intrf[i].Y + 3 && e.Y > sev.Intrf[i].Y - 3)
					{
						if (i % 2 == 0)
						{
							sev.Intrf.RemoveAt(i + 1);
							sev.Intrf.RemoveAt(i);
						}
						else
						{
							sev.Intrf.RemoveAt(i - 1);
							sev.Intrf.RemoveAt(i-1);
						}

					}
				}
				for (int i = 0; i < sev.Organ2.Count(); i++)
				{
					if (e.X < sev.Organ2[i].X + 3 && e.X > sev.Organ2[i].X - 3 && e.Y < sev.Organ2[i].Y + 3 && e.Y > sev.Organ2[i].Y - 3)
					{
						if (i % 2 == 0)
						{
							sev.Organ2.RemoveAt(i + 1);
							sev.Organ2.RemoveAt(i);
						}
						else
						{
							sev.Organ2.RemoveAt(i - 1);
							sev.Organ2.RemoveAt(i - 1);
						}
					}
				}
				for (int i = 0; i < sev.OrganOR.Count(); i++)
				{
					if (e.X < sev.OrganOR[i].X + 3 && e.X > sev.OrganOR[i].X - 3 && e.Y < sev.OrganOR[i].Y + 3 && e.Y > sev.OrganOR[i].Y - 3)
					{
						if (i % 2 == 0)
						{
							sev.OrganOR.RemoveAt(i + 1);
							sev.OrganOR.RemoveAt(i);
						}
						else
						{
							sev.OrganOR.RemoveAt(i - 1);
							sev.OrganOR.RemoveAt(i - 1);
						}
					}
				}
				for (int i = 0; i < sev.Zav.Count(); i++)
				{
					if (e.X < sev.Zav[i].X + 3 && e.X > sev.Zav[i].X - 3 && e.Y < sev.Zav[i].Y + 3 && e.Y > sev.Zav[i].Y - 3)
					{
						if (i % 2 == 0)
						{
							sev.Zav.RemoveAt(i + 1);
							sev.Zav.RemoveAt(i);
						}
						else
						{
							sev.Zav.RemoveAt(i - 1);
							sev.Zav.RemoveAt(i - 1);
						}
					}
				}
			}
			
		}
		/// <summary>
		/// Метод запоминающий параметр "е" после нажатия на кнопку мыши (для рисования прямых)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void picture_MouseDown(object sender, MouseEventArgs e)
		{
			Ef = e;
		}
		/// <summary>
		/// Метод запоминающий параметр "е" после отпускания кнопки мыши (для рисования прямых)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void picture_MouseUp(object sender, MouseEventArgs e)
		{
			Ef2 = e;
			if (deli2 != null)
			{
				deli2(Ef, Ef2);
			}
			if (this.Cursor == Cursors.SizeAll)
			{
				picture.Refresh();
				picture_Paint();
				Points();
			}
			if (this.Cursor == Cursors.Hand)
			{
				picture.Refresh();
				picture_Paint();
				Points();
			}

		}
		/// <summary>
		/// Метод перерисовки созданных элементов
		/// </summary>
		private void picture_Paint()
		{
            string[] mas = new string[SaveText.Count];
            Queue<string> queue1 = new Queue<string>();
            int j = 0;
            Pen p = new Pen(Color.Blue);
			Graphics gr = picture.CreateGraphics(); 
			for (int i = 0; i < sev.Unit.Count(); i++)
			{
				MouseEventArgs e = sev.Unit[i];
				PaiC paiC = new PaiC(picture);
				paiC.Paint(e);
			}
			for (int i = 0; i < sev.Component.Count(); i++)
			{
				MouseEventArgs e = sev.Component[i];
				PaiK paiK = new PaiK(picture);
				paiK.Paint(e);
			}
			for (int i = 0; i < sev.Intrf.Count(); i=i+2)
			{
				MouseEventArgs e = sev.Intrf[i];
				MouseEventArgs e2 = sev.Intrf[i+1];
				PaiI paiI = new PaiI(picture);
				paiI.Paint(e, e2);
			}
			for (int i = 0; i < sev.Zav.Count(); i = i + 2)
			{
				MouseEventArgs e = sev.Zav[i];
				MouseEventArgs e2 = sev.Zav[i+1];
				PaiS paiS = new PaiS(picture);
				paiS.Paint(e, e2);
			}
			for (int i = 0; i < sev.Organ2.Count(); i = i + 2)
			{
				MouseEventArgs e = sev.Organ2[i];
				MouseEventArgs e2 = sev.Organ2[i+1];
				PaiL paiL = new PaiL(picture);
				paiL.Paint(e, e2);
			}
			for (int i = 0; i < sev.OrganOR.Count(); i++)
			{
				MouseEventArgs e = sev.OrganOR[i];
				MouseEventArgs e2 = sev.OrganOR[i+1];
				PaiM paiM = new PaiM(picture);
				paiM.Paint(e, e2, textBox1, ref mas, j);
                j++;
			}
		}
		/// <summary>
		/// Метод для для вызова метода перерисовки после изменения формы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void picture_Paint(object sender, PaintEventArgs e)
		{
			picture_Paint();
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "Переместить"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.SizeAll; 
			pictureBox1.Enabled = false;
			pictureBox2.Enabled = false;
			pictureBox3.Enabled = false;
			pictureBox4.Enabled = false;
			pictureBox5.Enabled = false;
			pictureBox8.Enabled = false;
			pictureBox3.Enabled = false;
			deli = null;deli2 = null;
			Points();
		}
		/// <summary>
		/// Метод, который выделяет главный угол (точку)
		/// </summary>
		private void Points ()
		{
			Pen pen = new Pen(Color.Blue, 6);
			Graphics gr = picture.CreateGraphics();
			for (int i = 0; i < sev.Unit.Count(); i++)
				gr.DrawRectangle(pen, sev.Unit[i].X, sev.Unit[i].Y, 3, 3);
			for (int i = 0; i < sev.Component.Count(); i++)
				gr.DrawRectangle(pen, sev.Component[i].X, sev.Component[i].Y, 3, 3);
			for (int i = 0; i < sev.Pac.Count(); i++)
				gr.DrawRectangle(pen, sev.Pac[i].X, sev.Pac[i].Y, 3, 3);
			for (int i = 0; i < sev.Prim.Count(); i++)
				gr.DrawRectangle(pen, sev.Prim[i].X, sev.Prim[i].Y, 3, 3);
			for (int i = 0; i < sev.Intrf.Count(); i = i + 2)
			{
				gr.DrawRectangle(pen, sev.Intrf[i].X, sev.Intrf[i].Y, 3, 3);
				gr.DrawRectangle(pen, sev.Intrf[i+1].X, sev.Intrf[i+1].Y, 3, 3);
			}
			for (int i = 0; i < sev.Zav.Count(); i = i + 2)
			{
				gr.DrawRectangle(pen, sev.Zav[i].X, sev.Zav[i].Y, 3, 3);
				gr.DrawRectangle(pen, sev.Zav[i + 1].X, sev.Zav[i + 1].Y, 3, 3);
			}
			for (int i = 0; i < sev.Organ2.Count(); i = i + 2)
			{
				gr.DrawRectangle(pen, sev.Organ2[i].X, sev.Organ2[i].Y, 3, 3);
				gr.DrawRectangle(pen, sev.Organ2[i + 1].X, sev.Organ2[i + 1].Y, 3, 3);
			}
			for (int i = 0; i < sev.OrganOR.Count(); i = i + 2)
			{
				gr.DrawRectangle(pen, sev.OrganOR[i].X, sev.OrganOR[i].Y, 3, 3);
				gr.DrawRectangle(pen, sev.OrganOR[i + 1].X, sev.OrganOR[i + 1].Y, 3, 3);
			}
			pen.Dispose();
			gr.Dispose();
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "Создать"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Arrow;
			pictureBox1.Enabled = true;
			pictureBox2.Enabled = true;
			pictureBox3.Enabled = true;
			pictureBox4.Enabled = true;
			pictureBox5.Enabled = true;
			pictureBox8.Enabled = true;
			pictureBox3.Enabled = true;
			picture.Refresh();
			picture_Paint();
		}
		/// <summary>
		/// Метод для перемещения компонентов
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void picture_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.Cursor == Cursors.SizeAll)
			{
				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					for (int i = 0; i < sev.Component.Count(); i++)
					{
						if (e.X < sev.Component[i].X + 3 && e.X > sev.Component[i].X - 3 && e.Y < sev.Component[i].Y + 3 && e.Y > sev.Component[i].Y - 3)
						{
							sev.Component[i] = e;
						}
					}
					for (int i = 0; i < sev.Unit.Count(); i++)
					{
						if (e.X < sev.Unit[i].X + 3 && e.X > sev.Unit[i].X - 3 && e.Y < sev.Unit[i].Y + 3 && e.Y > sev.Unit[i].Y - 3)
						{
							sev.Unit[i] = e;
						}
					}
					for (int i = 0; i < sev.Prim.Count(); i++)
					{
						if (e.X < sev.Prim[i].X + 3 && e.X > sev.Prim[i].X - 3 && e.Y < sev.Prim[i].Y + 3 && e.Y > sev.Prim[i].Y - 3)
						{
							sev.Prim[i] = e;
						}
					}
					for (int i = 0; i < sev.Pac.Count(); i++)
					{
						if (e.X < sev.Pac[i].X + 3 && e.X > sev.Pac[i].X - 3 && e.Y < sev.Pac[i].Y + 3 && e.Y > sev.Pac[i].Y - 3)
						{
							sev.Pac[i] = e;
						}
					}
					for (int i = 0; i < sev.Intrf.Count(); i++)
					{
						if (e.X < sev.Intrf[i].X + 3 && e.X > sev.Intrf[i].X - 3 && e.Y < sev.Intrf[i].Y + 3 && e.Y > sev.Intrf[i].Y - 3)
						{
							sev.Intrf[i] = e;
						}
					}
					for (int i = 0; i < sev.Organ2.Count(); i++)
					{
						if (e.X < sev.Organ2[i].X + 3 && e.X > sev.Organ2[i].X - 3 && e.Y < sev.Organ2[i].Y + 3 && e.Y > sev.Organ2[i].Y - 3)
						{
							sev.Organ2[i] = e;
						}
					}
					for (int i = 0; i < sev.OrganOR.Count(); i++)
					{
						if (e.X < sev.OrganOR[i].X + 3 && e.X > sev.OrganOR[i].X - 3 && e.Y < sev.OrganOR[i].Y + 3 && e.Y > sev.OrganOR[i].Y - 3)
						{
							sev.OrganOR[i] = e;
						}
					}
					for (int i = 0; i < sev.Zav.Count(); i++)
					{
						if (e.X < sev.Zav[i].X + 3 && e.X > sev.Zav[i].X - 3 && e.Y < sev.Zav[i].Y + 3 && e.Y > sev.Zav[i].Y - 3)
						{
							sev.Zav[i] = e;
						}
					}
				}
			}
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "Удалить"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Hand;
			pictureBox1.Enabled = false;
			pictureBox2.Enabled = false;
			pictureBox3.Enabled = false;
			pictureBox4.Enabled = false;
			pictureBox5.Enabled = false;
			pictureBox8.Enabled = false;
			pictureBox3.Enabled = false;
			deli = null; deli2 = null;
			Points();
		}
		/// <summary>
		/// Метод вызваемый после нажатия на кнопку "Создать новый"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void novoe_Click(object sender, EventArgs e)
		{
			sev.Component.Clear();
			sev.Intrf.Clear();
			sev.Organ2.Clear();
			sev.OrganOR.Clear();
			sev.Pac.Clear();
			sev.Prim.Clear();
			sev.Unit.Clear();
			sev.Zav.Clear();
			picture.Refresh();
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "Настройки"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripDropDownButton1_Click(object sender, EventArgs e)
		{

		}

    }
}
