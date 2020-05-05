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
		/// Лист для хранения MouseEventArgs компонента "Aктёра"
		/// </summary>
		public List<MouseEventArgs> Actor = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Эллипс"
		/// </summary>
		public List<MouseEventArgs> Ellipse = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Прямоугольник"
		/// </summary>
		public List<MouseEventArgs> Rechteck = new List<MouseEventArgs> { };
        /// <summary>
        /// Лист для хранения MouseEventArgs компонента "Пунктирная стрелка"
        /// </summary>
        public List<MouseEventArgs> DArrow = new List<MouseEventArgs> { };
		/// <summary>
		/// Лист для хранения MouseEventArgs компонента "Стрелка"
		/// </summary>
		public List<MouseEventArgs> Arrow = new List<MouseEventArgs> { };
        /// <summary>
        /// Лист для хранения MouseEventArgs компонента "Написание текста"
        /// </summary>
        public List<MouseEventArgs> Text = new List<MouseEventArgs> { };
    }
}
