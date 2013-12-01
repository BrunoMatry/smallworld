using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IPartie {

	List<IUnite> getUnites();
	List<TypeCase> GetGrille();
	List<int> GetPointsJoueurs();

	bool NouveauTour();
	void Selectionner(IUnite unite);
	IUnite getUniteCourante();
	void attaque(Direction dir);
	void deplacement(Direction dir);
	List<Coordonnee> GetDirectionsAutorisees(Coordonnee c);
	void PasserTourUniteCourante();
	void PasserTourJoueur();

	void Enregistrer();
	void EnregistrerSous();
}

