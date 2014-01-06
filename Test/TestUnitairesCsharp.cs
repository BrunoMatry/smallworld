using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {

	[TestClass]
	public class TestUnitairesCsharp {

		[TestMethod]
		public void Test_CreationPartieDemo_1() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			Assert.IsTrue(p.Joueurs[0].Peuple.Unites[0].Joueur == 0);
			Assert.IsTrue(p.Joueurs[1].Peuple.Unites[0].Joueur == 1);
		}

		[TestMethod]
		public void Test_CreationPartieDemo_2() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			IUnite uj1 = p.Joueurs[0].Peuple.Unites[0];
			IUnite uj2 = p.Joueurs[1].Peuple.Unites[0];
			Assert.IsTrue(uj1.Coordonnees.X == 0 || uj1.Coordonnees.X == 4);
			Assert.IsTrue(uj1.Coordonnees.Y == 0 || uj1.Coordonnees.Y == 4);
			Assert.IsTrue(uj2.Coordonnees.X == 0 || uj2.Coordonnees.X == 4);
			Assert.IsTrue(uj2.Coordonnees.Y == 0 || uj2.Coordonnees.Y == 4);

			Assert.IsTrue((uj1.Coordonnees.X != uj2.Coordonnees.X) || (uj1.Coordonnees.Y != uj2.Coordonnees.Y));
		}

		[TestMethod]
		public void Test_PasserTourJoueurDemo_1() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			int old_jc = p.UniteCourante.Joueur;
			p.PasserTourJoueur();
			Assert.IsTrue(p.UniteCourante.Joueur != old_jc);
		}

		[TestMethod]
		public void Test_CreationPartiePetite_1() {
			// Creation de la liste des peuples
			List<TypePeuple> lp = new List<TypePeuple>();
			lp.Add(TypePeuple.GAULOIS);
			lp.Add(TypePeuple.VIKING);

			// Creation d'une partie PETITE ; choix de peuples Gaulois / Viking
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.PETIT, lp, "partieTestPetite");
			Assert.IsTrue(p.Joueurs[0].Peuple.Unites[0].Joueur == 0);
			Assert.IsTrue(p.Joueurs[1].Peuple.Unites[0].Joueur == 1);
		}

		[TestMethod]
		public void Test_CreationPartiePetite_2() {
			// Creation de la liste des peuples
			List<TypePeuple> lp = new List<TypePeuple>();
			lp.Add(TypePeuple.GAULOIS);
			lp.Add(TypePeuple.VIKING);

			// Creation d'une partie PETITE ; choix de peuples Gaulois / Viking
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.PETIT, lp, "partieTestPetite");
			Assert.IsTrue(p.Joueurs[0].Peuple.Unites[0].Joueur == 0 || p.Joueurs[0].Peuple.Unites[0].Joueur == 1);
		}

		[TestMethod]
		public void Test_CreationPartieNormale_1() {
			// Creation de la liste des peuples
			List<TypePeuple> ln = new List<TypePeuple>();
			ln.Add(TypePeuple.VIKING);
			ln.Add(TypePeuple.GAULOIS);

			// Creation d'une partie NORMALE ; choix de peuples Viking / Gaulois
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.NORMAL, ln, "partieTestNormale");
			Assert.IsTrue(p.Joueurs[0].Peuple.Unites[0].Joueur == 0);
			Assert.IsTrue(p.Joueurs[1].Peuple.Unites[0].Joueur == 1);
		}
	}
}
