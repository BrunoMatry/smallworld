using System.Collections.Generic;
using Wrapper;

public interface IFabriqueCase {
	/**
	 * Methode permettant d'associer les TYpeCase a leurs objets
	 * @return l'ensemble des TypeCase asssocie a leurs Case
	 */
    Dictionary<TypeCase, Case> CreerCases();
	/**
	 * Methode permettant de generer une grille aleatoire pour la carte
	 * @param w le WrapperLib qui est capable de generer la carte
	 * @return la grille associee a la nouvelle carte
	 */
	TypeCase[][] CreerGrille(WrapperLib w);
}