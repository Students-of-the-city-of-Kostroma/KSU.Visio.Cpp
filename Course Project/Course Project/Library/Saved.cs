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
		/// Лист для хранения MouseEventArgs компонента "Узел"
		/// </summary>
		public List<MouseEventArgs> Unit = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Компонент"
		/// </summary>
		public List<MouseEventArgs> Component = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Пакет"
		/// </summary>
		public List<MouseEventArgs> Pac = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Интерфейс"
		/// </summary>
		public List<MouseEventArgs> Intrf = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Зависимости"
		/// </summary>
		public List<MouseEventArgs> Zav = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Примечание"
		/// </summary>
		public List<MouseEventArgs> Prim = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Ограничение 2 элементов"
		/// </summary>
		public List<MouseEventArgs> Organ2 = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Ограничение ИЛИ"
		/// </summary>
		public List<MouseEventArgs> OrganOR = new List<MouseEventArgs> { };
	}
}
