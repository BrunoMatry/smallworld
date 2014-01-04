using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace Test {
	[TestClass]
	public class TestUnitairesWrapper {
		
		[TestMethod]
		public void TestMethod1() {
			WrapperLib w = new WrapperLib();
			List<int> l = w.gen_carte(1, 3);
			Assert.IsTrue(l[0] == 0);
			Assert.IsTrue(l[1] == 0);
			Assert.IsTrue(l[2] == 0);
		}

		[TestMethod]
		public void TestWrapper2() {
			// Genere une carte de 3 cases avec deux types de case different
			WrapperLib w = new WrapperLib();
			List<int> l = w.gen_carte(2, 3);
			Assert.IsTrue(l[0] == 0 || l[0] == 1);
		}
	}
}
