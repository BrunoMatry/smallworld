using System;
using System.Collections.Generic;

public interface IPartie {

    TypeCase[,] Grille { get ; }

	bool NouveauTour();
	void Selectionner(IUnite unite);
    IUnite UniteCourante {get;}
	void Attaque(Direction dir);
	void Deplacement(Direction dir);
	void PasserTourUniteCourante();
	void PasserTourJoueur();

	void Enregistrer();
	void EnregistrerSous(string chemin);

    Dictionary<Coordonnee, List<IUnite>> GrilleUnites { get; }
    List<int> PointsJoueurs { get; }
}

