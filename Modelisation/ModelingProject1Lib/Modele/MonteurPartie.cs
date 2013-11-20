using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class MonteurPartie : IMonteurPartie
{
	private IStrategiePartie _strategie;

	private IPartie lancerCreation(string nomPartie, TypeCarte tc, List<TypePeuple> tp)
	{
        /* TODO */
		throw new System.NotImplementedException();
	}

	private IPartie lancerCreation(string nomPartie, TypeCarte tc, List<TypePeuple> tp, List<List<Coordonnee>> unites, TypeCase[][] grille)
	{
        /* TODO */
		throw new System.NotImplementedException();
	}

	public IPartie CreerPartie(File p)
	{
        /* TODO */
		throw new System.NotImplementedException();
	}

	public IPartie CreerPartie(TypeCarte tc, List<TypePeuple> tp, string nomPartie)
	{
        /* TODO */
		throw new System.NotImplementedException();
	}

}

