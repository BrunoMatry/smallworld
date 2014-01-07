using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

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
			Assert.IsTrue(p.Joueurs[0].Item2.Peuple.Unites.Count == 4);
		}

		[TestMethod]
		public void Test_CreationPartieDemo_2() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			IUnite uj1 = p.Joueurs[0].Item2.Peuple.Unites[0];
			IUnite uj2 = p.Joueurs[1].Item2.Peuple.Unites[0];
			Assert.IsTrue(uj1.Coordonnees.X == 0 || uj1.Coordonnees.X == 4);
			Assert.IsTrue(uj1.Coordonnees.Y == 0 || uj1.Coordonnees.Y == 4);
			Assert.IsTrue(uj2.Coordonnees.X == 0 || uj2.Coordonnees.X == 4);
			Assert.IsTrue(uj2.Coordonnees.Y == 0 || uj2.Coordonnees.Y == 4);

			Assert.IsTrue((uj1.Coordonnees.X != uj2.Coordonnees.X) || (uj1.Coordonnees.Y != uj2.Coordonnees.Y));
		}

		[TestMethod]
		public void Test_CreationPartiePetite_1() {
			// Creation de la liste des peuples
			List<TypePeuple> lp = new List<TypePeuple>();
			lp.Add(TypePeuple.GAULOIS);
			lp.Add(TypePeuple.VIKING);

			// Creation d'une partie PETITE ; choix de peuples Gaulois / Viking
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.PETIT, lp, "partieTestPetite");
			Assert.IsTrue(p.Joueurs[0].Item2.Peuple.Unites.Count == 6);
		}

		[TestMethod]
		public void Test_CreationPartiePetite_2() {
			// Creation de la liste des peuples
			List<TypePeuple> lp = new List<TypePeuple>();
			lp.Add(TypePeuple.GAULOIS);
			lp.Add(TypePeuple.VIKING);

			// Creation d'une partie PETITE ; choix de peuples Gaulois / Viking
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.PETIT, lp, "partieTestPetite");
			Assert.IsTrue(p.Joueurs[0].Item2.Peuple.Unites.Count == 6);
		}

		[TestMethod]
		public void Test_CreationPartieNormale_1() {
			// Creation de la liste des peuples
			List<TypePeuple> ln = new List<TypePeuple>();
			ln.Add(TypePeuple.VIKING);
			ln.Add(TypePeuple.GAULOIS);

			// Creation d'une partie NORMALE ; choix de peuples Viking / Gaulois
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.NORMAL, ln, "partieTestNormale");
			Assert.IsTrue(p.Joueurs[0].Item2.Peuple.Unites.Count == 8);
		}

		[TestMethod]
		public void Test_Coordonnee_1() {
			Coordonnee c = new Coordonnee(0, 1);
			Assert.IsTrue(c.X == 0);
			Assert.IsTrue(c.Y == 1);
		}

		[TestMethod]
		public void Test_Coordonnee_2() {
			Coordonnee c1 = new Coordonnee(0, 1);
			Coordonnee c2 = new Coordonnee(4, 2);
			Coordonnee c3 = new Coordonnee(0, 1);

			Assert.IsFalse(c1 == c2);
			Assert.IsTrue(c1 == c3);
			
			Assert.IsFalse(c1.Equals(c2));
			Assert.IsTrue(c1.Equals(c3));
		}

		[TestMethod]
		public void Test_Coordonnee_3() {
			Coordonnee c1 = new Coordonnee(0, 0);
			Coordonnee c2 = new Coordonnee(0, 0);
			Assert.IsTrue(c1 == c2);
		}

		[TestMethod]
		public void Test_Coordonnee_4()	{
			Coordonnee c1 = new Coordonnee(0, 0);
			Coordonnee c2 = new Coordonnee(0, 0);
			Assert.IsTrue(c1.Equals(c2));
		}

		[TestMethod]
		public void Test_UniteGaulois_1() {
			IUnite u = new UniteGaulois(0, new Coordonnee(0, 0));
			Assert.IsTrue(u.Attaque == 2);
			Assert.IsTrue(u.Defense == 1);
			Assert.IsTrue(u.PointsDeVie == 2);

			u.NouveauTour(TypeCase.PLAINE);
			Assert.IsTrue(u.Valeur == 2);
			Assert.IsTrue(u.PointsDeplacement == 2);

			u.NouveauTour(TypeCase.MONTAGNE);
			Assert.IsTrue(u.Valeur == 0);
			Assert.IsTrue(u.PointsDeplacement == 1);

			u.NouveauTour(TypeCase.FORET);
			Assert.IsTrue(u.Valeur == 1);
			Assert.IsTrue(u.PointsDeplacement == 1);
		}

		[TestMethod]
		public void Test_UniteViking_1() {
			IUnite u = new UniteViking(0, new Coordonnee(0, 0));
			Assert.IsTrue(u.Attaque == 2);
			Assert.IsTrue(u.Defense == 1);
			Assert.IsTrue(u.PointsDeVie == 2);

			u.NouveauTour(TypeCase.DESERT);
			Assert.IsTrue(u.Valeur == 0);
			Assert.IsTrue(u.PointsDeplacement == 1);

			u.NouveauTour(TypeCase.MONTAGNE);
			Assert.IsTrue(u.Valeur == 1);
			Assert.IsTrue(u.PointsDeplacement == 1);
		}

		[TestMethod]
		public void Test_UniteNain_1() {
			IUnite u = new UniteNain(0, new Coordonnee(0, 0));
			Assert.IsTrue(u.Attaque == 2);
			Assert.IsTrue(u.Defense == 1);
			Assert.IsTrue(u.PointsDeVie == 2);

			u.NouveauTour(TypeCase.FORET);
			Assert.IsTrue(u.Valeur == 2);
			Assert.IsTrue(u.PointsDeplacement == 1);

			u.NouveauTour(TypeCase.PLAINE);
			Assert.IsTrue(u.Valeur == 0);
			Assert.IsTrue(u.PointsDeplacement == 1);

			u.NouveauTour(TypeCase.MONTAGNE);
			Assert.IsTrue(u.Valeur == 1);
			Assert.IsTrue(u.PointsDeplacement == 1);
		}

		[TestMethod]
		public void Test_Peuple_1() {
			IPeuple p = new Peuple(TypePeuple.GAULOIS, 2, 0, new Coordonnee(0, 0));
			Assert.IsTrue(p.NombreUnites == 2);
			Assert.IsTrue(p.Unites[0].Coordonnees.Equals(new Coordonnee(0, 0)));
			Assert.IsTrue(p.Unites[1].Coordonnees.Equals(new Coordonnee(0, 0)));
			

		}

		[TestMethod]
		public void Test_Peuple_2() {
			IPeuple p = new Peuple(TypePeuple.NAINS, 4, 0, new Coordonnee(0, 0));
			IUnite uKilled = p.Unites[2];
			Assert.IsTrue(p.NombreUnites == 4);
			Assert.IsTrue(p.Unites.Count == 4);
			p.TuerUnite(uKilled);
			Assert.IsTrue(p.NombreUnites == 3);
			Assert.IsTrue(p.Unites.Count == 3);
		}

		[TestMethod]
		public void Test_Joueur_1() {
			IJoueur j = new Joueur(TypePeuple.VIKING, 4, new Coordonnee(0, 0));
			foreach(IUnite u in j.Peuple.Unites) {
				u.NouveauTour(TypeCase.PLAINE);
			}
			j.MAJPoints();
			Assert.IsTrue(j.Points == 4);
			Assert.IsTrue(j.EnJeu);
		}

		[TestMethod]
		public void Test_Joueur_2() {
			IJoueur j = new Joueur(TypePeuple.VIKING, 1, new Coordonnee(0, 0));
			IUnite u = j.Peuple.Unites[0];
			u.NouveauTour(TypeCase.PLAINE);
			j.MAJPoints();
			Assert.IsTrue(j.Points == 1);
			Assert.IsTrue(j.EnJeu);
			j.Peuple.TuerUnite(u);
			j.MAJPoints();
			Assert.IsTrue(j.Points == 0);
			Assert.IsFalse(j.EnJeu);
		}

		[TestMethod]
		public void Test_FabriqueUnite_1() {
			IFabriqueUnite f = new FabriqueUnite();
			List<IUnite> l = f.CreerUnites(TypePeuple.GAULOIS, 2, 0, new Coordonnee(0, 0));
			Assert.IsTrue(l[0].Coordonnees.Equals(new Coordonnee(0, 0)));
			Assert.IsTrue(l[1].Coordonnees.Equals(new Coordonnee(0, 0)));
			Assert.IsTrue(l[0].Joueur == 0);
			Assert.IsTrue(l[1].Joueur == 0);
		}

		[TestMethod]
		public void Test_FabriqueCase_1() {
			IFabriqueCase f = new FabriqueCase();
			Dictionary<TypeCase, Case> d = f.CreerCases();
			Assert.IsInstanceOfType(d[TypeCase.DESERT], typeof(CaseDesert));
			Assert.IsInstanceOfType(d[TypeCase.EAU], typeof(CaseEau));
			Assert.IsInstanceOfType(d[TypeCase.FORET], typeof(CaseForet));
			Assert.IsInstanceOfType(d[TypeCase.MONTAGNE], typeof(CaseMontagne));
			Assert.IsInstanceOfType(d[TypeCase.PLAINE], typeof(CasePlaine));
		}

		[TestMethod]
		public void Test_FabriqueCase_2() {
			IFabriqueCase f = new FabriqueCase();
			WrapperLib w = new WrapperLib(5, 5);
			TypeCase[,] grille = f.CreerGrille(w);
			Assert.IsTrue(grille[3,4] == TypeCase.DESERT
						|| grille[3,4] == TypeCase.EAU
						|| grille[3,4] == TypeCase.FORET
						|| grille[3,4] == TypeCase.MONTAGNE
						|| grille[3,4] == TypeCase.PLAINE);
		}

		[TestMethod]
		public void Test_Carte_1() {
			IFabriqueCase f = new FabriqueCase();
			WrapperLib w = new WrapperLib(5, 5);
			ICarte c = new CarteDemo(f.CreerGrille(w), f.CreerCases());
			List<Direction> l = c.GetDirectionsAutorisees(new Coordonnee(0, 0));
			Assert.IsTrue(l.Contains(Direction.EST));
			Assert.IsTrue(l.Contains(Direction.NORD));
			Assert.IsTrue(l.Count == 2);
		}

		[TestMethod]
		public void Test_Carte_2() {
			IFabriqueCase f = new FabriqueCase();
			WrapperLib w = new WrapperLib(15, 15);
			ICarte c = new CarteNormale(f.CreerGrille(w), f.CreerCases());
			List<Direction> l = c.GetDirectionsAutorisees(new Coordonnee(14, 14));
			Assert.IsTrue(l.Contains(Direction.SUD));
			Assert.IsTrue(l.Contains(Direction.OUEST));
			Assert.IsTrue(l.Count == 2);
		}

		[TestMethod]
		public void Test_Carte_3() {
			IFabriqueCase f = new FabriqueCase();
			WrapperLib w = new WrapperLib(10, 10);
			ICarte c = new CartePetit(f.CreerGrille(w), f.CreerCases());
			TypeCase t = c.GetTypeCase(new Coordonnee(5,7));
			Assert.IsTrue(t == TypeCase.DESERT
						|| t == TypeCase.EAU
						|| t == TypeCase.FORET
						|| t == TypeCase.MONTAGNE
						|| t == TypeCase.PLAINE);
		}

		[TestMethod]
		public void Test_Partie_PasserTourJoueur_1() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			int old_jc = p.Joueurs[0].Item1;
			p.PasserTourJoueur();
			Assert.IsFalse(p.Joueurs[0].Item1 == old_jc);
		}

		[TestMethod]
		public void Test_Partie_PasserTourJoueur_2() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			int old_jc = p.UniteCourante.Joueur;
			p.PasserTourJoueur();
			Assert.IsFalse(p.UniteCourante.Joueur == old_jc);
		}

		[TestMethod]
		public void Test_Partie_PasserTourJoueur_3() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			int old_jc = p.UniteCourante.Joueur;
			p.PasserTourJoueur();
			p.PasserTourJoueur();
			Assert.IsTrue(p.UniteCourante.Joueur == old_jc);
		}

		[TestMethod]
		public void Test_Partie_Selectionner() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			IUnite u = p.Joueurs[1].Item2.Peuple.Unites[2];
			p.Selectionner(u);
			Assert.IsTrue(p.UniteCourante == u);
		}

		[TestMethod]
		public void Test_Partie_GrilleUnite() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			Coordonnee c = p.UniteCourante.Coordonnees;
			Assert.IsTrue(p.GrilleUnites[c].Contains(p.UniteCourante));
		}

		[TestMethod]
		public void Test_Partie_Grille() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			TypeCase t = p.Grille[3,1];
			Assert.IsTrue(t == TypeCase.DESERT
						|| t == TypeCase.EAU
						|| t == TypeCase.FORET
						|| t == TypeCase.MONTAGNE
						|| t == TypeCase.PLAINE);
		}

		[TestMethod]
		public void Test_Partie_PasserTourUniteCourante() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; choix de peuples Gaulois / Nains
			IPartie p = MonteurPartie.CreerPartie(TypeCarte.DEMO, ld, "partieTestDemo");
			IUnite u = p.UniteCourante;
			p.PasserTourUniteCourante();
			Assert.IsFalse(p.UniteCourante == u);
		}

		[TestMethod]
		public void Test_Partie_Attaque() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; avec deux joueur Gaulois / Viking
			List<Tuple<int, IJoueur>> l = new List<Tuple<int, IJoueur>>();
			l.Add(new Tuple<int, IJoueur>(0, new Joueur(TypePeuple.GAULOIS, 1, new Coordonnee(0, 0))));
			l.Add(new Tuple<int, IJoueur>(0, new Joueur(TypePeuple.VIKING, 1, new Coordonnee(0, 1))));
			TypeCase[,] grille = new TypeCase[1, 2];
			grille[0, 0] = TypeCase.MONTAGNE;
			grille[0, 1] = TypeCase.MONTAGNE;
			IPartie p = new Partie("PartieTest", new CarteDemo(grille, null), l, 5);

			p.Attaque(Direction.NORD);

			Assert.IsTrue(false);
		}

		[TestMethod]
		public void Test_Partie_Deplacement() {
			// Creation de la liste des peuples
			List<TypePeuple> ld = new List<TypePeuple>();
			ld.Add(TypePeuple.GAULOIS);
			ld.Add(TypePeuple.NAINS);

			// Creation d'une partie DEMO ; avec un joueur (Gaulois)
			List<Tuple<int, IJoueur>> l = new List<Tuple<int, IJoueur>>();
			l.Add(new Tuple<int, IJoueur>(0, new Joueur(TypePeuple.GAULOIS, 1, new Coordonnee(0, 0))));
			TypeCase[,] grille = new TypeCase[1,2];
			grille[0, 0] = TypeCase.MONTAGNE;
			grille[0, 1] = TypeCase.MONTAGNE;
			IPartie p = new Partie("PartieTest", new CarteDemo(grille, null), l, 5);
			
			p.Deplacement(Direction.NORD);
			
			// Assert.IsTrue(p.UniteCourante.Coordonnees.Equals(new Coordonnee(0, 1)));
			Assert.IsTrue(p.UniteCourante.Joueur == p.Joueurs[0].Item1);
		}

		[TestMethod]
		public void Test_Partie_Enregistrer() {
			// TODO
			Assert.IsTrue(false);
		}
	}
}
