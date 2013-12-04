using System;
using System.Collections.Generic;

public abstract class MonteurPartie : IMonteurPartie
{
	private IStrategiePartie _strategie
	{
		get;
		set;
	}

	private IPartie LancerCreation(string nomPartie, TypeCarte tc, List<TypePeuple> tp)
	{
		throw new System.NotImplementedException();
	}

	private IPartie LancerCreation(string nomPartie, TypeCarte tc, List<TypePeuple> tp, List<List<Coordonnee>> unites, List<TypeCase> grille)
	{
		throw new System.NotImplementedException();
	}

	public virtual IPartie CreerPartie(String file)
	{
		throw new System.NotImplementedException();
	}

	public virtual IPartie CreerPartie(TypeCarte tc, List<TypePeuple> tp, string nomPartie)
	{
		throw new System.NotImplementedException();
	}

}

