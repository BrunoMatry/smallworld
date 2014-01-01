using System;

public interface IUnite {

	Boolean Attaquer(IUnite uniteCible);
	void Deplacer(Coordonnee caseCible, TypeCase caseActuelle);
	void NouveauTour(TypeCase caseActuelle);
	Coordonnee GetCoordonnees();
	int GetAttaque();
	int GetDefense();
	int GetValeur();
	int GetPointsDeVie();
	int GetPointDeplacement();
}

