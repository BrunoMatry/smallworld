using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace Test
{
	[TestClass]
	public class TestUnitairesWrapper {

		[TestMethod]
		unsafe public void Test_GenerationCarte_1() {
			// Creation du wrapper (carte de taille 1 x 1)
			WrapperLib w = new WrapperLib(1, 2);
			// Generation de la carte avec un seul type de case
			List<int> l = w.generer_carte(1);
			Assert.IsTrue(l[0] == 0);
			
		}

		[TestMethod]
		unsafe public void Test_GenerationCarte_2 () {
			// Creation du wrapper (carte de taille 1 x 1)
			WrapperLib w = new WrapperLib(1, 1);
			// Generation de la carte avec deux types de case
			List<int> l = w.generer_carte(2);
			Assert.IsTrue(l[0] == 0 || l[0] == 1);
		}
	}
}
