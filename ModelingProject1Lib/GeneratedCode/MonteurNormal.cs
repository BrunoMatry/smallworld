﻿using System;
using System.Collections.Generic;

public class MonteurNormal : StrategiePartie
{
	protected override ICarte MonterCarte()
	{
		throw new System.NotImplementedException();
	}

	protected override ICarte MonterCarte(List<TypeCase> grille)
	{
		throw new System.NotImplementedException();
	}

	public override IPartie CreerPartie(string tc, List<TypePeuple> tp)
	{
		throw new System.NotImplementedException();
	}

	public override IPartie CreerPartie(string tp, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
	{
		throw new System.NotImplementedException();
	}

}

