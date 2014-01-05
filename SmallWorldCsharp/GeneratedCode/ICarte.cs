using System.Collections.Generic;

public interface ICarte {

    TypeCase GetTypeCase(Coordonnee c);
    TypeCase[,] GetGrille();
	/**
	 * Methode permettant d'obtenir la case associee a une coordonnee
	 * @param c La coordonnee a tester
	 * @return la case associee
	 */
	Case GetCase(Coordonnee c);
	/**
	 * TODO Verfifier l'utilite de cette methode...
	 */
	List<Coordonnee> GetEmplacementUnites(int nbJoueurs);
	/**
	 * Methode permettant d'obtenir les directions autorisees depuis une coordonnee c
	 * @param c La coordonnée a tester
	 * @return la liste des directions autorisees
	 */
	List<Direction> GetDirectionsAutorisees(Coordonnee c);

	// Propriete
	Dictionary<Coordonnee, List<IUnite>> GrilleUnites { get; set; }
}

