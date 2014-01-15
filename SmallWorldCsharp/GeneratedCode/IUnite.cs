using System;

public interface IUnite {

	// Proprietes
	int Attaque { get; }
	int Defense { get; }
	int Valeur { get; }
	int PointsDeVie { get; set; }
	int PointsDeplacement { get; }
	int Joueur { get; }
	Coordonnee Coordonnees { get; }     

	/**
	 * Methode permettant a une instance d'unite d'attaquer une autre unite
	 * @param uniteCible l'unite cible par l'attaque
	 * @return true si l'attaque a reussi, false sinon
	 */
	Boolean Attaquer(IUnite uniteCible);
	/**
	 * Methode permettant a une unite de se deplacer
	 * @param cc la case ciblee par le deplacement
	 * @param tca le type de la case sur laquelle se trouve l'unite actuellement 
	 */
	void Deplacer(Coordonnee cc, TypeCase tca);
	/**
	 * Methode permettant de mettre a jour les parametres interne d'une unite a la fin d'un tour
	 * @param ca le type de la case sur laquelle se trouve l'unite actuellement
	 */
	void NouveauTour(TypeCase ca);
	
}

