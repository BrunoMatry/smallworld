using System;
using System.Collections.Generic;

public class Peuple : IPeuple
{
	private List<IUnite> _unites;
	private IFabriqueUnite _fabriqueUnites;
	private TypePeuple _type;
	private TypePeuple t;
	private int nbUnites;

	public Peuple(TypePeuple t, int nbUnites)
	{
		// TODO: Complete member initialization
		this.t = t;
		this.nbUnites = nbUnites;
	}

	public virtual List<IUnite> GetUnites()
	{
		throw new System.NotImplementedException();
	}

	public virtual int GetNombreUnites()
	{
		throw new System.NotImplementedException();
	}

	public virtual void TuerUnite(IUnite unite)
	{
		throw new System.NotImplementedException();
	}

	public virtual void CreerUnite(int nb, int idJoueur)
	{
		throw new System.NotImplementedException();
	}

}

