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
		///  Для сохранения
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
		Queue <string> SaveText = new Queue<string>();
		// Обработка событий MouseEnter и MousLeave для изображений
		#region
		/// <summary>
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox1_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Действия";
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
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox2_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Решения";
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
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox3_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Начало процесса";
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
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox4_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Окончание процесса";
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
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox5_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Схождение действий";
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
		/// Метод вызываемый при наведении на компонент, отображает название компонента в Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox6_MouseEnter(object sender, EventArgs e)
		{
			label1.Text = "Зависимость";
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
			label1.Text = "Текст";
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
			if (sender == pictureBox1)
			{
				deli = PaiRect;
				deli2 = null;
			}
			if (sender == pictureBox2)
			{
				deli = PaiRhomb;
				deli2 = null;
			}
			if (sender == pictureBox3)
			{
				deli = PaiCircle;
				deli2 = null;
			}
			if (sender == pictureBox4)
			{
				deli = PaiCircleS;
				deli2 = null;
			}
			if (sender == pictureBox5)
			{
				deli = HevyLine;
				deli2 = null;
			}
			if (sender == pictureBox6)
			{
				deli = null;
				deli2 = Line;
			}
			if (sender == pictureBox7)
			{
				deli = TextBox1;
				deli2 = null;
			}

		}
		/// <summary>
		/// Метод для рисования "Действия"
		/// </summary>
		/// <param name="e"></param>
		private void PaiRect(MouseEventArgs e)
		{
			PaiRect paiRect = new PaiRect(picture);
			paiRect.Ris(e);
			sev.Deystviya.Add(e);
		}
		/// <summary>
		/// Метод для рисования "Решения"
		/// </summary>
		/// <param name="e"></param>
		private void PaiRhomb(MouseEventArgs e)
		{
			PaiRhomb paiRhomb = new PaiRhomb(picture);
			picture= paiRhomb.Ris(e);
			sev.Resheniya.Add(e);
		}
		/// <summary>
		/// Метод для рисования "Начало процесса"
		/// </summary>
		/// <param name="e"></param>
		private void PaiCircle(MouseEventArgs e)
		{
			PaiCircle paiCircle = new PaiCircle(picture);
			paiCircle.Ris(e);
			sev.NProtsessa.Add(e);

		}
		/// <summary>
		/// Метод для рисования "Окончание процесса"
		/// </summary>
		/// <param name="e"></param>
		private void PaiCircleS(MouseEventArgs e)
		{
			PaiCircleS paiCircleS = new PaiCircleS(picture);
			paiCircleS.Ris(e);
			sev.OProtsessa.Add(e);
		}
		/// <summary>
		/// Метод для рисования "Схождение действий"
		/// </summary>
		/// <param name="e"></param>
		private void HevyLine(MouseEventArgs e)
		{
			PaiIHevyLine paiIHevyLine = new PaiIHevyLine(picture);
			paiIHevyLine.Ris(e);
			sev.SDeystviy.Add(e);
		}
		/// <summary>
		/// Метод для рисования "Зависимости"
		/// </summary>
		/// <param name="e"></param>
		/// <param name="e2"></param>
		private void Line(MouseEventArgs e, MouseEventArgs e2)
		{
			Line line = new Line(picture);
			line.Ris(e, e2);
			sev.Zav.Add(e);
			sev.Zav.Add(e2);
		}
		/// <summary>
		/// Метод для написания текст
		/// </summary>
		/// <param name="e"></param>
		private void TextBox1(MouseEventArgs e)
		{
			TextBox1 textBoxx1 = new TextBox1(picture);
			textBoxx1.Ris(e, textBox1, ref SaveText);
			sev.Text.Add(e);
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
				Queue<string> queue1 = new Queue<string>();
				for (int i = 0; i < sev.Resheniya.Count(); i++)
				{
					if (e.X < sev.Resheniya[i].X + 3 && e.X > sev.Resheniya[i].X - 3 && e.Y < sev.Resheniya[i].Y + 3 && e.Y > sev.Resheniya[i].Y - 3)
					{
						sev.Resheniya.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.Deystviya.Count(); i++)
				{
					if (e.X < sev.Deystviya[i].X + 3 && e.X > sev.Deystviya[i].X - 3 && e.Y < sev.Deystviya[i].Y + 3 && e.Y > sev.Deystviya[i].Y - 3)
					{
						sev.Deystviya.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.NProtsessa.Count(); i++)
				{
					if (e.X < sev.NProtsessa[i].X + 3 && e.X > sev.NProtsessa[i].X - 3 && e.Y < sev.NProtsessa[i].Y + 3 && e.Y > sev.NProtsessa[i].Y - 3)
					{
						sev.NProtsessa.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.OProtsessa.Count(); i++)
				{
					if (e.X < sev.OProtsessa[i].X + 3 && e.X > sev.OProtsessa[i].X - 3 && e.Y < sev.OProtsessa[i].Y + 3 && e.Y > sev.OProtsessa[i].Y - 3)
					{
						sev.OProtsessa.RemoveAt(i);
					}
				}
				for (int i = 0; i < sev.SDeystviy.Count(); i++)
				{
					if (e.X < sev.SDeystviy[i].X + 3 && e.X > sev.SDeystviy[i].X - 3 && e.Y < sev.SDeystviy[i].Y + 3 && e.Y > sev.SDeystviy[i].Y - 3)
					{
						sev.SDeystviy.RemoveAt(i);
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
			for (int i = 0; SaveText.Count > 0; i++)
			{
				queue1.Enqueue(SaveText.Peek());
				mas[i] = SaveText.Dequeue();
			}
			for (int i = 0; queue1.Count() > 0; i++)
			{
				SaveText.Enqueue(queue1.Dequeue());
			}
			Pen p = new Pen(Color.Blue);
			Graphics gr = picture.CreateGraphics(); 
			for (int i = 0; i < sev.Deystviya.Count(); i++)
			{
				MouseEventArgs e = sev.Deystviya[i];
				PaiRect paiC = new PaiRect(picture);
				paiC.Paint(e);
			}
			for (int i = 0; i < sev.Resheniya.Count(); i++)
			{
				MouseEventArgs e = sev.Resheniya[i];
				PaiRhomb paiK = new PaiRhomb(picture);
				paiK.Paint(e);
			}
			for (int i = 0; i < sev.NProtsessa.Count(); i++)
			{
				MouseEventArgs e = sev.NProtsessa[i];
				PaiCircle paiU = new PaiCircle(picture);
				paiU.Paint(e);
			}
			for (int i = 0; i < sev.OProtsessa.Count(); i++)
			{
				MouseEventArgs e = sev.OProtsessa[i];
				PaiCircleS paiP = new PaiCircleS(picture);
				paiP.Paint(e);
			}
			for (int i = 0; i < sev.SDeystviy.Count(); i++)
			{
				MouseEventArgs e = sev.SDeystviy[i];
				PaiIHevyLine paiI = new PaiIHevyLine(picture);
				paiI.Paint(e);
			}
			for (int i = 0; i < sev.Zav.Count(); i = i + 2)
			{
				MouseEventArgs e = sev.Zav[i];
				MouseEventArgs e2 = sev.Zav[i+1];
				Line paiS = new Line(picture);
				paiS.Paint(e, e2);
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
			pictureBox7.Enabled = false;
			deli = null;
			deli2 = null;
			Points();
		}
		/// <summary>
		/// Метод, который выделяет главный угол (точку)
		/// </summary>
		private void Points ()
		{
			Pen pen = new Pen(Color.Blue, 6);
			Graphics gr = picture.CreateGraphics();
			for (int i = 0; i < sev.Deystviya.Count(); i++)
				gr.DrawRectangle(pen, sev.Deystviya[i].X, sev.Deystviya[i].Y, 3, 3);
			for (int i = 0; i < sev.Resheniya.Count(); i++)
				gr.DrawRectangle(pen, sev.Resheniya[i].X, sev.Resheniya[i].Y, 3, 3);
			for (int i = 0; i < sev.OProtsessa.Count(); i++)
				gr.DrawRectangle(pen, sev.OProtsessa[i].X, sev.OProtsessa[i].Y, 3, 3);
			for (int i = 0; i < sev.NProtsessa.Count(); i++)
				gr.DrawRectangle(pen, sev.NProtsessa[i].X, sev.NProtsessa[i].Y, 3, 3);
			for (int i = 0; i < sev.SDeystviy.Count(); i++)
				gr.DrawRectangle(pen, sev.SDeystviy[i].X, sev.SDeystviy[i].Y, 3, 3);
			for (int i = 0; i < sev.Text.Count(); i++)
				gr.DrawRectangle(pen, sev.Text[i].X, sev.Text[i].Y, 3, 3);
			for (int i = 0; i < sev.Zav.Count(); i = i + 2)
			{
				gr.DrawRectangle(pen, sev.Zav[i].X, sev.Zav[i].Y, 3, 3);
				gr.DrawRectangle(pen, sev.Zav[i + 1].X, sev.Zav[i + 1].Y, 3, 3);
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
			pictureBox7.Enabled = true;
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
					for (int i = 0; i < sev.Resheniya.Count(); i++)
					{
						if (e.X < sev.Resheniya[i].X + 3 && e.X > sev.Resheniya[i].X - 3 && e.Y < sev.Resheniya[i].Y + 3 && e.Y > sev.Resheniya[i].Y - 3)
						{
							sev.Resheniya[i] = e;
						}
					}
					for (int i = 0; i < sev.Deystviya.Count(); i++)
					{
						if (e.X < sev.Deystviya[i].X + 3 && e.X > sev.Deystviya[i].X - 3 && e.Y < sev.Deystviya[i].Y + 3 && e.Y > sev.Deystviya[i].Y - 3)
						{
							sev.Deystviya[i] = e;
						}
					}
					for (int i = 0; i < sev.NProtsessa.Count(); i++)
					{
						if (e.X < sev.NProtsessa[i].X + 3 && e.X > sev.NProtsessa[i].X - 3 && e.Y < sev.NProtsessa[i].Y + 3 && e.Y > sev.NProtsessa[i].Y - 3)
						{
							sev.NProtsessa[i] = e;
						}
					}
					for (int i = 0; i < sev.OProtsessa.Count(); i++)
					{
						if (e.X < sev.OProtsessa[i].X + 3 && e.X > sev.OProtsessa[i].X - 3 && e.Y < sev.OProtsessa[i].Y + 3 && e.Y > sev.OProtsessa[i].Y - 3)
						{
							sev.OProtsessa[i] = e;
						}
					}
					for (int i = 0; i < sev.SDeystviy.Count(); i++)
					{
						if (e.X < sev.SDeystviy[i].X + 3 && e.X > sev.SDeystviy[i].X - 3 && e.Y < sev.SDeystviy[i].Y + 3 && e.Y > sev.SDeystviy[i].Y - 3)
						{
							sev.SDeystviy[i] = e;
						}
					}
					for (int i = 0; i < sev.Text.Count(); i++)
					{
						if (e.X < sev.Text[i].X + 3 && e.X > sev.Text[i].X - 3 && e.Y < sev.Text[i].Y + 3 && e.Y > sev.Text[i].Y - 3)
						{
							sev.Text[i] = e;
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
			pictureBox6.Enabled = false;
			pictureBox7.Enabled = false;
			deli = null; 
			deli2 = null;
			Points();
		}
		/// <summary>
		/// Метод вызваемый после нажатия на кнопку "Создать новый"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void novoe_Click(object sender, EventArgs e)
		{
			sev.Resheniya.Clear();
			sev.SDeystviy.Clear();
			sev.Text.Clear();
			sev.OProtsessa.Clear();
			sev.NProtsessa.Clear();
			sev.Deystviya.Clear();
			sev.Zav.Clear();
			picture.Refresh();
			SaveText.Clear();
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "Настройки"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripDropDownButton1_Click(object sender, EventArgs e)
		{
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "вариант1"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void вариант1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.picture.BackgroundImage = global::Course_Project.Properties.Resources.Field1;
			picture.Refresh();
			picture_Paint();
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "стандарт"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void стандартToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.picture.BackgroundImage = global::Course_Project.Properties.Resources.Field;
			picture.Refresh();
			picture_Paint();
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "вариант2"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void вариант2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.picture.BackgroundImage = global::Course_Project.Properties.Resources.Field2;
			picture.Refresh();
			picture_Paint();
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "стандартСтрелочка"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void стандартСтрелочкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "вариант1"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void вариант1ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Cross;
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "курсор2"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void курсор2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.No;
		}
		/// <summary>
		/// Метод вызываемый после нажатия на кнопку "Обновить"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			picture.Refresh();
			picture_Paint();
		}
	}
}
