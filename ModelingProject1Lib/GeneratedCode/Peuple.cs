﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Peuple : IPeuple
{
	private Vector<IUnite> _unites
	{
		get;
		set;
	}

	private IFabriqueUnite _fabriqueUnites
	{
		get;
		set;
	}

	private TypePeuple _type
	{
		get;
		set;
	}

	public virtual Vector<IUnite> getUnites()
	{
		throw new System.NotImplementedException();
	}

	public virtual int getNombreUnites()
	{
		throw new System.NotImplementedException();
	}

	public virtual void tuerUnite(IUnite unite)
	{
		throw new System.NotImplementedException();
	}

	public virtual void creerUnite(int nb, int idJoueur)
	{
		throw new System.NotImplementedException();
	}

}

