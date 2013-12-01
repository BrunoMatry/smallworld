using System;
using System.Collections.Generic;

public interface IPartie {

	List<IUnite> GetUnites();
	List<TypeCase> GetGrille();
	List<int> GetPointsJoueurs();

	Boolean NouveauTour();
	void Selectionner(IUnite unite);
	IUnite GetUniteCourante();
	void Attaque(Direction dir);
	void Deplacement(Direction dir);
	List<Coordonnee> GetDirectionsAutorisees(Coordonnee c);
	void PasserTourUniteCourante();
	void PasserTourJoueur();

	void Enregistrer();
	void EnregistrerSous();
}

