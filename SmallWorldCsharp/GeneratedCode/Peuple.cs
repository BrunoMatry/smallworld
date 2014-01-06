using System;
using System.Collections.Generic;

public class Peuple : IPeuple
{
	private List<IUnite> _unites;
	private TypePeuple _type;
	private int _nbUnites;

	// Propriétés
	public int NombreUnites { get { return this._nbUnites; } }
	public List<IUnite> Unites { get { return this._unites; } set { this._unites = value; } }

	/**
	 * Constructeur de la classe Peuple
	 * 
	 * t Type d'unites de l'instance
	 * nb Nombre initial d'unites de l'instance
	 * j Identifiant du joueur a qui appartient le peuple
	 * posInit Position initiale des unites
	 */
	public Peuple(TypePeuple t, int nb, int j, Coordonnee posInit) {
		this._type = t;
		IFabriqueUnite fab = new FabriqueUnite();
		this._nbUnites = nb;
		this._unites = fab.CreerUnites(this._type, this._nbUnites, j, posInit);
	}

	/**
	 * Methode permettant la suppression d'une unite dans la table des unites
	 * et la mise a jour du compteur d'unites
	 */
	public void TuerUnite(IUnite unite) {
		this._unites.Remove(unite);
		this._nbUnites--;
	}
}

