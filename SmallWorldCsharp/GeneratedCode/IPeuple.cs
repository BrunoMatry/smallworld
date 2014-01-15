using System.Collections.Generic;

public interface IPeuple {

	int NombreUnites { get; }
	List<Unite> Unites { get; set; }
	/**
	 * Methode permettant de supprimer une unite de la liste des unites
	 * @param unite l'unite a retirer de la liste des unites
	 */
	void TuerUnite(Unite unite);
}

