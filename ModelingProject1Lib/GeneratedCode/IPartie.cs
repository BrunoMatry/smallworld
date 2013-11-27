using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IPartie 
{
	List<IUnite> getUnites();

	void attaque(Direction dir);

	void deplacement(Direction dir);

	void passerTour();

	IUnite getUniteCourante();

	bool nouveauTour();

	List<Coordonnee> getDirectionsAutorisees(Coordonnee c);

	List<TypeCase> getGrille();

	void enregistrer();

	void enregistrerSous();

	List<int> getPointsJoueurs();

	void passerTourJoueur();

	void selectionner(IUnite unite);

}

