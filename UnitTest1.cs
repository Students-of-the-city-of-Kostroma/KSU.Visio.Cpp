using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Course_Project;
using System.Windows.Forms;
using Library;

namespace UTCourseProject
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void Task_49_1()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a =saved.Ellipse.Count;
			saved.Ellipse.Add(Ef);
			//assert
			Assert.AreEqual(a+1 ,saved.Ellipse.Count);
		}
		[TestMethod]
		public void Task_49_2()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Rechteck.Count;
			saved.Rechteck.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Rechteck.Count);
		}
		[TestMethod]
		public void Task_49_3()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Arrow.Count;
			saved.Arrow.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Arrow.Count);
		}
		[TestMethod]
		public void Task_49_7()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Actor.Count;
			saved.Actor.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Actor.Count);
		}
		[TestMethod]
		public void Task_49_8()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.DArrow.Count;
			saved.DArrow.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.DArrow.Count);
		}
	}
}
