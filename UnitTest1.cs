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
			int a = saved.Resheniya.Count;
			saved.Resheniya.Add(Ef);
			Assert.AreEqual(a+1 ,saved.Resheniya.Count);
		}
		[TestMethod]
		public void Task_49_2()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.SDeystviy.Count;
			saved.SDeystviy.Add(Ef);
			Assert.AreEqual(a + 1, saved.SDeystviy.Count);
		}
		[TestMethod]
		public void Task_49_3()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Text.Count;
			saved.Text.Add(Ef);
			Assert.AreEqual(a + 1, saved.Text.Count);
		}
		[TestMethod]
		public void Task_49_4()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.OProtsessa.Count;
			saved.OProtsessa.Add(Ef);
			Assert.AreEqual(a + 1, saved.OProtsessa.Count);
		}
		[TestMethod]
		public void Task_49_5()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.NProtsessa.Count;
			saved.NProtsessa.Add(Ef);
			Assert.AreEqual(a + 1, saved.NProtsessa.Count);
		}
		[TestMethod]
		public void Task_49_6()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Deystviya.Count;
			saved.Deystviya.Add(Ef);
			Assert.AreEqual(a + 1, saved.Deystviya.Count);
		}
		[TestMethod]
		public void Task_49_7()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Zav.Count;
			saved.Zav.Add(Ef);
			Assert.AreEqual(a + 1, saved.Zav.Count);
		}
	}
}
