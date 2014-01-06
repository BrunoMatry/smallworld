using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace Test {

	[TestClass]
	public class TestUnitairesWrapper {

		[TestMethod]
		public void Test_GenerationCarte_1() {
			// Creation du wrapper (carte de taille 1 x 1)
			WrapperLib w = new WrapperLib(1, 1);
			// Generation de la carte avec un seul type de case
			List<int> l = w.generer_carte(1);
			Assert.IsTrue(l[0] == 0);
		}

		[TestMethod]
		public void Test_GenerationCarte_2 () {
			// Creation du wrapper (carte de taille 1 x 1)
			WrapperLib w = new WrapperLib(1, 1);
			// Generation de la carte avec deux types de case
			List<int> l = w.generer_carte(2);
			Assert.IsTrue(l[0] == 0 || l[0] == 1);
		}

		[TestMethod]
		public void Test_GenerationCarte_3() {
			// Creation du wrapper (carte de taille 3 x 3)
			WrapperLib w = new WrapperLib(3, 3);
			// Generation de la carte avec un seul type de case
			List<int> l = w.generer_carte(1);
			for(int i = 0 ; i < 9 ; i++)
				Assert.IsTrue(l[i] == 0);
		}

		[TestMethod]
		public void Test_GenerationCarte_4() {
			// Creation du wrapper (carte de taille 3 x 3)
			WrapperLib w = new WrapperLib(3, 3);
			// Generation de la carte avec deux types de case
			List<int> l = w.generer_carte(2);
			for (int i = 0; i < 9; i++)
				Assert.IsTrue(l[i] == 0 || l[i] == 1);
		}

		[TestMethod]
		public void Test_PlacementUnites_1() {
			// 2 joueurs
			int nbj = 1;
			// Creation du wrapper (carte de taille 3 x 3)
			WrapperLib w = new WrapperLib(3, 3);
			// Placement des unites
			List<Tuple<int, int>> l = w.placer_unites(nbj);

			Assert.IsTrue(l[0].Item1 == 0 || l[0].Item1 == 2);
			Assert.IsTrue(l[0].Item2 == 0 || l[0].Item2 == 2);
		}

		[TestMethod]
		public void Test_PlacementUnites_2() {
			// 4 joueurs
			int nbj = 4;
			// Creation du wrapper (carte de taille 3 x 3)
			WrapperLib w = new WrapperLib(3, 3);
			// Placement des unites
			List<Tuple<int, int>> l = w.placer_unites(nbj);
			for (int i = 0; i < 4; i++) {
				Assert.IsTrue(l[i].Item1 == 0 || l[i].Item1 == 2);
				Assert.IsTrue(l[i].Item2 == 0 || l[i].Item2 == 2);
			}
		}

		[TestMethod]
		public void Test_PlacementUnites_3() {
			// 4 joueurs
			int nbj = -1;
			// Creation du wrapper (carte de taille 3 x 3)
			WrapperLib w = new WrapperLib(3, 3);
			// Placement des unites
			List<Tuple<int, int>> l = w.placer_unites(nbj);
			Assert.IsTrue(l.Count == 0);
		}

		[TestMethod]
		public void Test_PlacementUnites_4() {
			// 8 joueurs
			int nbj = 8;
			// Creation du wrapper (carte de taille 10 x 10)
			WrapperLib w = new WrapperLib(10, 10);
			// Placement des unites
			List<Tuple<int, int>> l = w.placer_unites(nbj);
			Assert.IsTrue(l.Count == 8);
		}
	}
}
