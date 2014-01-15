using System.Collections.Generic;

public interface IFabriqueUnite {

	/**
	 * Methode permettant de generer des unites
	 * @param type le type du peuple du joueur
	 * @param nbUnites le nombre d'unites a generer
	 * @param joueur l'id du joueur qui demande la creation des unites
	 * @param c la coordonnee initiale a laquelle placer les unites
	 * @return une liste d'unites
	 */
	List<Unite> CreerUnites(TypePeuple type, int nbUnites, int joueur, Coordonnee c);
}

