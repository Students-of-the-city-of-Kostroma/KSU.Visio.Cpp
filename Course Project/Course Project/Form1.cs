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
            textBox1.Hide();
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
			label1.Text = "Актёр";
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
			label1.Text = "Эллипс";
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
			label1.Text = "Текст";
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
			label1.Text = "Прямоугольник";
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
			label1.Text = "Пунктирная стрелка";
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
			label1.Text = "Стрелка";
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
        /// Переменные типа bool, необходимы для единичного размещения компонентов
        /// </summary>
        bool flag = true, flag1 = true, flag2 = true, flag3 = true;
        /// <summary>
        /// Метод определяющий какой из элементов удерживается
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e) 
		{
            textBox1.Hide();
            textBox1.Clear();
            if (sender == pictureBox2)
            {
                deli = PaiA;
                deli2 = null;
            }
            if (sender == pictureBox1)
			{
				deli = PaiE;
				deli2 = null;
			}
			if (sender == pictureBox4)
			{
				deli2 = PaiP;
				deli = null;
			}
			if (sender == pictureBox5)
			{
				deli2 = PaiDA;
				deli = null;
			}
			if (sender == pictureBox6) 
			{
				deli = null;
				deli2 = PaiAr;
			}
            if (sender == pictureBox3)
            {
                textBox1.Show();
                deli = TextBox1;
                deli2 = null;
            }

        }
        /// <summary>
        /// Метод для рисования "Эллипс"
        /// </summary>
        /// <param name="e"></param>
        private void PaiE(MouseEventArgs e)
		{
			PaiE paiE = new PaiE(picture);
			picture= paiE.Ris(e);
			sev.Ellipse.Add(e);
		}
		/// <summary>
		/// Метод для рисования "Актёра"
		/// </summary>
		/// <param name="e"></param>
		private void PaiA(MouseEventArgs e)
		{
			PaiA paiA = new PaiA(picture);
			paiA.Ris(e);
			sev.Actor.Add(e);	
		}
		/// <summary>
		/// Метод для рисования "Прямоугольника"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		private void PaiP(MouseEventArgs e, MouseEventArgs e2)
		{
			PaiP paiP = new PaiP(picture);
			paiP.Ris(e, e2);
			sev.Rechteck.Add(e);
			sev.Rechteck.Add(e2);
		}
        /// <summary>
        /// Метод для рисования "Пунктирная стрелка"
        /// </summary>
        /// <param name="e"></param>
        /// <param name="e2"></param>
        private void PaiDA(MouseEventArgs e, MouseEventArgs e2)
		{
			PaiDA paiDA = new PaiDA(picture);
			paiDA.Ris(e, e2);
			sev.DArrow.Add(e);
			sev.DArrow.Add(e2);
		}
		/// <summary>
		/// Метод для рисования "Стрелка"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		private void PaiAr (MouseEventArgs e, MouseEventArgs e2)
		{
			PaiAr paiAr = new PaiAr(picture);
			paiAr.Ris(e, e2);
			sev.Arrow.Add(e);
			sev.Arrow.Add(e2);
		}
        /// <summary>
        /// Метод для написания текста
        /// </summary>
        /// <param name="e"></param>
        private void TextBox1(MouseEventArgs e)
        {
            if (textBox1.Text != "")
            {
                TextBox1 textBoxx1 = new TextBox1(picture);
                textBoxx1.Ris(e, textBox1, ref SaveText);
                sev.Text.Add(e);
            }
        }
        /// <summary>
        /// Рисование компонентов в виде фигур после клика мышью по форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picture_MouseClick(object sender, MouseEventArgs e)
		{
            if (deli != null && (flag2 || flag3))
            {
                if (flag == false && flag2)
                {
                    deli(e);
                    flag2 = false;
                    deli = null;
                }
                if (flag1 == false && flag3)
                {
                    deli(e);
                    flag3 = false;
                    deli = null;
                }
            }
            if (deli != null && (!flag2 || !flag3))
            {
                deli(e);
            }
            if (deli != null && flag && flag1 && flag2 && flag3)
            {
                deli(e);
            }
            if (this.Cursor==Cursors.Hand)
			{
                Queue<string> queue1 = new Queue<string>();
                for (int i = 0; i < sev.Ellipse.Count(); i++)
				{
					if (e.X < sev.Ellipse[i].X + 3 && e.X > sev.Ellipse[i].X - 3 && e.Y < sev.Ellipse[i].Y + 3 && e.Y > sev.Ellipse[i].Y - 3)
					{
						sev.Ellipse.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.Actor.Count(); i++)
				{
					if (e.X < sev.Actor[i].X + 3 && e.X > sev.Actor[i].X - 3 && e.Y < sev.Actor[i].Y + 3 && e.Y > sev.Actor[i].Y - 3)
					{
						sev.Actor.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.Rechteck.Count(); i++)
				{
					if (e.X < sev.Rechteck[i].X + 3 && e.X > sev.Rechteck[i].X - 3 && e.Y < sev.Rechteck[i].Y + 3 && e.Y > sev.Rechteck[i].Y - 3)
					{
						if (i % 2 == 0)
						{
							sev.Rechteck.RemoveAt(i + 1);
							sev.Rechteck.RemoveAt(i);
						}
						else
						{
							sev.Rechteck.RemoveAt(i - 1);
							sev.Rechteck.RemoveAt(i-1);
						}

					}
				}
				for (int i = 0; i < sev.Arrow.Count(); i++)
				{
					if (e.X < sev.Arrow[i].X + 3 && e.X > sev.Arrow[i].X - 3 && e.Y < sev.Arrow[i].Y + 3 && e.Y > sev.Arrow[i].Y - 3)
					{
						if (i % 2 == 0)
						{
							sev.Arrow.RemoveAt(i + 1);
							sev.Arrow.RemoveAt(i);
						}
						else
						{
							sev.Arrow.RemoveAt(i - 1);
							sev.Arrow.RemoveAt(i - 1);
						}
					}
				}
                for (int i = 0; i < sev.Text.Count(); i++)
                {
                    if (e.X < sev.Text[i].X + 3 && e.X > sev.Text[i].X - 3 && e.Y < sev.Text[i].Y + 3 && e.Y > sev.Text[i].Y - 3)
                    {
                        sev.Text.RemoveAt(i);
                        SaveText.Dequeue();
                    }
                    else
                    {
                        queue1.Enqueue(SaveText.Dequeue());
                    }
                }
                for (int i = 0; i < sev.DArrow.Count(); i++)
                {
                    if (e.X < sev.DArrow[i].X + 3 && e.X > sev.DArrow[i].X - 3 && e.Y < sev.DArrow[i].Y + 3 && e.Y > sev.DArrow[i].Y - 3)
                    {
                        if (i % 2 == 0)
                        {
                            sev.DArrow.RemoveAt(i + 1);
                            sev.DArrow.RemoveAt(i);
                        }
                        else
                        {
                            sev.DArrow.RemoveAt(i - 1);
                            sev.DArrow.RemoveAt(i - 1);
                        }
                    }
                }
                while (SaveText.Count() > 0)
                {
                    queue1.Enqueue(SaveText.Dequeue());
                }
                while (queue1.Count() > 0)
                {
                    SaveText.Enqueue(queue1.Dequeue());
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
            for (int i = 0; SaveText.Count > 0; i++)
            {
                queue1.Enqueue(SaveText.Peek());
                mas[i] = SaveText.Dequeue();
            }
            for (int i = 0; queue1.Count() > 0; i++)
            {
                SaveText.Enqueue(queue1.Dequeue());
            }

            for (int i = 0; i < sev.Actor.Count(); i++)
			{
				MouseEventArgs e = sev.Actor[i];
				PaiA paiA = new PaiA(picture);
				paiA.Paint(e);
			}
			for (int i = 0; i < sev.Ellipse.Count(); i++)
			{
				MouseEventArgs e = sev.Ellipse[i];
				PaiE paiE = new PaiE(picture);
				paiE.Paint(e);
			}
			for (int i = 0; i < sev.Rechteck.Count(); i=i+2)
			{
				MouseEventArgs e = sev.Rechteck[i];
				MouseEventArgs e2 = sev.Rechteck[i+1];
				PaiP paiP = new PaiP(picture);
				paiP.Paint(e, e2);
			}
			for (int i = 0; i < sev.DArrow.Count(); i = i + 2)
			{
				MouseEventArgs e = sev.DArrow[i];
				MouseEventArgs e2 = sev.DArrow[i+1];
				PaiDA paiS = new PaiDA(picture);
				paiS.Paint(e, e2);
			}
			for (int i = 0; i < sev.Arrow.Count(); i = i + 2)
			{
				MouseEventArgs e = sev.Arrow[i];
				MouseEventArgs e2 = sev.Arrow[i+1];
				PaiAr paiAr = new PaiAr(picture);
				paiAr.Paint(e, e2);
			}
            for (int i = 0; i < sev.Text.Count(); i++)
            {
                MouseEventArgs e = sev.Text[i];
                TextBox1 paiL = new TextBox1(picture);
                paiL.Paint(e, textBox1, ref mas, j);
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
			pictureBox6.Enabled = false;
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
			for (int i = 0; i < sev.Actor.Count(); i++)
				gr.DrawRectangle(pen, sev.Actor[i].X, sev.Actor[i].Y, 3, 3);
			for (int i = 0; i < sev.Ellipse.Count(); i++)
				gr.DrawRectangle(pen, sev.Ellipse[i].X, sev.Ellipse[i].Y, 3, 3);
            for (int i = 0; i < sev.Text.Count(); i++)
                gr.DrawRectangle(pen, sev.Text[i].X, sev.Text[i].Y, 3, 3);
            for (int i = 0; i < sev.Rechteck.Count(); i = i + 2)
			{
				gr.DrawRectangle(pen, sev.Rechteck[i].X, sev.Rechteck[i].Y, 3, 3);
				gr.DrawRectangle(pen, sev.Rechteck[i+1].X, sev.Rechteck[i+1].Y, 3, 3);
			}
			for (int i = 0; i < sev.DArrow.Count(); i = i + 2)
			{
				gr.DrawRectangle(pen, sev.DArrow[i].X, sev.DArrow[i].Y, 3, 3);
				gr.DrawRectangle(pen, sev.DArrow[i + 1].X, sev.DArrow[i + 1].Y, 3, 3);
			}
			for (int i = 0; i < sev.Arrow.Count(); i = i + 2)
			{
				gr.DrawRectangle(pen, sev.Arrow[i].X, sev.Arrow[i].Y, 3, 3);
				gr.DrawRectangle(pen, sev.Arrow[i + 1].X, sev.Arrow[i + 1].Y, 3, 3);
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
			pictureBox6.Enabled = true;
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
					for (int i = 0; i < sev.Ellipse.Count(); i++)
					{
						if (e.X < sev.Ellipse[i].X + 3 && e.X > sev.Ellipse[i].X - 3 && e.Y < sev.Ellipse[i].Y + 3 && e.Y > sev.Ellipse[i].Y - 3)
						{
							sev.Ellipse[i] = e;
						}
					}
					for (int i = 0; i < sev.Actor.Count(); i++)
					{
						if (e.X < sev.Actor[i].X + 3 && e.X > sev.Actor[i].X - 3 && e.Y < sev.Actor[i].Y + 3 && e.Y > sev.Actor[i].Y - 3)
						{
							sev.Actor[i] = e;
						}
					}
					for (int i = 0; i < sev.Rechteck.Count(); i++)
					{
						if (e.X < sev.Rechteck[i].X + 3 && e.X > sev.Rechteck[i].X - 3 && e.Y < sev.Rechteck[i].Y + 3 && e.Y > sev.Rechteck[i].Y - 3)
						{
							sev.Rechteck[i] = e;
						}
					}
					for (int i = 0; i < sev.Arrow.Count(); i++)
					{
						if (e.X < sev.Arrow[i].X + 3 && e.X > sev.Arrow[i].X - 3 && e.Y < sev.Arrow[i].Y + 3 && e.Y > sev.Arrow[i].Y - 3)
						{
							sev.Arrow[i] = e;
						}
					}
                    for (int i = 0; i < sev.Text.Count(); i++)
                    {
                        if (e.X < sev.Text[i].X + 3 && e.X > sev.Text[i].X - 3 && e.Y < sev.Text[i].Y + 3 && e.Y > sev.Text[i].Y - 3)
                        {
                            sev.Text[i] = e;
                        }
                    }
                    for (int i = 0; i < sev.DArrow.Count(); i++)
					{
						if (e.X < sev.DArrow[i].X + 3 && e.X > sev.DArrow[i].X - 3 && e.Y < sev.DArrow[i].Y + 3 && e.Y > sev.DArrow[i].Y - 3)
						{
							sev.DArrow[i] = e;
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
			pictureBox6.Enabled = false;
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
			sev.Ellipse.Clear();
			sev.Rechteck.Clear();
			sev.Arrow.Clear();
			sev.Actor.Clear();
			sev.DArrow.Clear();
			picture.Refresh();
            flag = true;
            flag1 = true;
            flag2 = true;
            flag3 = true;
        }
}
}
