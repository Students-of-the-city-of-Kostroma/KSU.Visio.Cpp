using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
	/// <summary>
	/// Класс для сохранения элементов
	/// </summary>
	public class Saved
	{
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Действия"
		/// </summary>
		public List<MouseEventArgs> Deystviya = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Решения"
		/// </summary>
		public List<MouseEventArgs> Resheniya = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Окончание процесса"
		/// </summary>
		public List<MouseEventArgs> OProtsessa = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Схождение действий"
		/// </summary>
		public List<MouseEventArgs> SDeystviy = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Зависимости"
		/// </summary>
		public List<MouseEventArgs> Zav = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Начало процесса"
		/// </summary>
		public List<MouseEventArgs> NProtsessa = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Написание текста"
		/// </summary>
		public List<MouseEventArgs> Text = new List<MouseEventArgs> { };
	}
}
