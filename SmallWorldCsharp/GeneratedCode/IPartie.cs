using System;
using System.Collections.Generic;

public interface IPartie {

    TypeCase[,] Grille { get ; }
	Unite UniteCourante { get; }
	Dictionary<Coordonnee, List<Unite>> GrilleUnites { get; }
	List<Tuple<int, Joueur>> Joueurs { get; }

	void Selectionner(Unite unite);
	void Attaque(Direction dir);
	void Deplacement(Direction dir);
	void PasserTourUniteCourante();
	void PasserTourJoueur();
	void Enregistrer();
	void EnregistrerSous(string chemin);
}

