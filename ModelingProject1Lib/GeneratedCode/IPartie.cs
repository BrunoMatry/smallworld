using System;
using System.Collections.Generic;

public interface IPartie {

	Dictionary<Coordonnee, IUnite> GetUnitesGrille();
    TypeCase[,] GetGrille();
	List<int> GetPointsJoueurs();

	Boolean NouveauTour();
	void Selectionner(IUnite unite);
	IUnite GetUniteCourante();
	void Attaque(Direction dir);
	void Deplacement(Direction dir);
	void PasserTourUniteCourante();
	void PasserTourJoueur();

	void Enregistrer();
	void EnregistrerSous(string chemin);
}

