﻿using System;
using System.Collections.Generic;

public class MonteurPetit : StrategiePartie
{
	protected override ICarte monterCarte()
	{
		throw new System.NotImplementedException();
	}

	protected override ICarte monterCarte(List<TypeCase> grille)
	{
		throw new System.NotImplementedException();
	}

	public override IPartie creerPartie(string tc, List<TypePeuple> tp)
	{
		throw new System.NotImplementedException();
	}

	public override IPartie creerPartie(string tp, List<TypePeuple> unites, List<List<Coordonnee>> grille, List<TypeCase> grille)
	{
		throw new System.NotImplementedException();
	}

}

