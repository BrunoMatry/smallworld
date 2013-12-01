using System;
using System.Collections.Generic;

public abstract class MonteurPartie : IMonteurPartie
{
	private IStrategiePartie _strategie
	{
		get;
		set;
	}

	private IPartie lancerCreation(string nomPartie, TypeCarte tc, List<TypePeuple> tp)
	{
		throw new System.NotImplementedException();
	}

	private IPartie lancerCreation(string nomPartie, TypeCarte tc, List<TypePeuple> tp, List<List<Coordonnee>> unites, List<TypeCase> grille)
	{
		throw new System.NotImplementedException();
	}

	public virtual IPartie creerPartie(File p)
	{
		throw new System.NotImplementedException();
	}

	public virtual IPartie creerPartie(TypeCarte tc, List<TypePeuple> tp, string nomPartie)
	{
		throw new System.NotImplementedException();
	}

}

