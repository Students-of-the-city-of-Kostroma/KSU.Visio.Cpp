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
			int a =saved.Component.Count;
			saved.Component.Add(Ef);
			//assert
			Assert.AreEqual(a+1 ,saved.Component.Count);
		}
		[TestMethod]
		public void Task_49_2()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Intrf.Count;
			saved.Intrf.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Intrf.Count);
		}
		[TestMethod]
		public void Task_49_3()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Organ2.Count;
			saved.Organ2.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Organ2.Count);
		}
		[TestMethod]
		public void Task_49_4()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.OrganOR.Count;
			saved.OrganOR.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.OrganOR.Count);
		}
		[TestMethod]
		public void Task_49_5()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Pac.Count;
			saved.Pac.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Pac.Count);
		}
		[TestMethod]
		public void Task_49_6()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Prim.Count;
			saved.Prim.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Prim.Count);
		}
		[TestMethod]
		public void Task_49_7()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Unit.Count;
			saved.Unit.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Unit.Count);
		}
		[TestMethod]
		public void Task_49_8()
		{
			Saved saved = new Saved();
			MouseEventArgs Ef = null;
			int a = saved.Zav.Count;
			saved.Zav.Add(Ef);
			//assert
			Assert.AreEqual(a + 1, saved.Zav.Count);
		}
	}
}
