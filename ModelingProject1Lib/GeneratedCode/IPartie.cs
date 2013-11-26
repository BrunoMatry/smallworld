using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IPartie 
{
	Vector<IUnite> getUnites();

	void attaque(Direction dir);

	void deplacement(Direction dir);

	void passerTour();

	IUnite getUniteCourante();

	bool nouveauTour();

	Vector<Coordonnee> getDirectionsAutorisees(Coordonnee c);

	Vector<TypeCase> getGrille();

	void enregistrer();

	void enregistrerSous();

	Vector<int> getPointsJoueurs();

	void passerTourJoueur();

	void selectionner(IUnite unite);

}

