using System;
using System.Collections.Generic;

public class Peuple : IPeuple
{
	private List<IUnite> _unites;
	private TypePeuple _type;
	private int _nbUnites;

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
		this._unites = fab.CreerUnites(this._type, this._nbUnites, j, posInit);
		this._nbUnites = nb;
	}


	public virtual List<IUnite> GetUnites() {
		return this._unites;
	}

	public virtual int GetNombreUnites() {
		return this._nbUnites;
	}

	public virtual void TuerUnite(IUnite unite) {
		this._unites.Remove(unite);
		this._nbUnites--;
	}
}

