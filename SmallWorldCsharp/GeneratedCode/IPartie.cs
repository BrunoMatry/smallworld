using System;
using System.Collections.Generic;

public interface IPartie {

	// Proprietes
	TypeCase[][] Grille { get; }
	Unite UniteCourante { get; }
	Dictionary<Coordonnee, List<Unite>> GrilleUnites { get; }
	List<Joueur> Joueurs { get; }

	/**
	 * Methode permettant de changer l'unite courante
	 * @param unite la nouvelle unite selectionnee
	 */
	void Selectionner(Unite unite);
	/**
	 * Methode permettant a l'unite courante d'attaquer dans une direction
	 * @param dir la direction de l'attaque
	 */
	void Attaque(Direction dir);
	/**
	 * Methode permettant a l'unite courante de se deplacer dans une direction donnee
	 * (si le deplacement est autorise)
	 * @param la direction du deplacement
	 */
	void Deplacement(Direction dir);
	/**
	 * Methode permettant de passer le tour de l'unite courante afin de donner la main a une autre unite du meme joueur
	 */
	void PasserTourUniteCourante();
	/**
	 * Methode permettant de passer le tour du joueur courant
	 */
	void PasserTourJoueur();
	/**
	 * Methode permettant de sauvegarder la partie sans avoir a entrer un nom pour le fichier
	 */
	void Enregistrer();
	/**
	 * Methode permettant de sauvegarder la partie apres avoir entre un nom pour le fichier
	 * @param nom le nom de la partie
	 */
	void EnregistrerSous(string nom);
}

