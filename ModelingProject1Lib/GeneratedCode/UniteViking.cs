using System;
using System.Collections.Generic;

public class UniteViking : Unite
{
	public UniteViking(int j) {
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

