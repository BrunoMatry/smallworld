using System;

public interface IUnite {

	Boolean Attaquer(IUnite uniteCible);
	void Deplacer(Coordonnee caseCible, TypeCase caseActuelle);
	void NouveauTour(TypeCase caseActuelle);
	int Attaque { get; }
	int Defense { get; }
	int Valeur { get; }
	int PointsDeVie { get; set; }
	int PointsDeplacement { get; }
	int Joueur { get; }
	Coordonnee Coordonnees { get; }
}

