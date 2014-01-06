using System;
using System.Collections.Generic;

public interface IPartie {

    TypeCase[,] Grille { get ; }
	IUnite UniteCourante { get; }
	Dictionary<Coordonnee, List<IUnite>> GrilleUnites { get; }
	Dictionary<int, IJoueur> Joueurs { get; }

	void Selectionner(IUnite unite);
	void Attaque(Direction dir);
	void Deplacement(Direction dir);
	void PasserTourUniteCourante();
	void PasserTourJoueur();
	void Enregistrer();
	void EnregistrerSous(string chemin);

    
}

