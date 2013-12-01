using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IUnite {

	Boolean Attaquer(IUnite uniteCible);
    void Deplacer(Coordonnee caseCible, TypeCase caseActuelle);
	void NouveauTour(TypeCase caseActuelle);

    int GetCoordonnees();
    int GetAttaque();
    int GetDefense();
	int GetValeur();
	int GetPointsDeVie();
	int GetPointDeplacement();
}

