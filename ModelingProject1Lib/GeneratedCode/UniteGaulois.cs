﻿using System;
using System.Collections.Generic;

public class UniteGaulois : Unite
{
	public UniteGaulois(int j) {
		this._joueur = j;
	}
	public override void nouveauTour(TypeCase caseActuelle)
	{
		throw new System.NotImplementedException();
	}

	public override void deplacer(Coordonnee caseCible, TypeCase caseActuelle)
	{
		throw new System.NotImplementedException();
	}

}

