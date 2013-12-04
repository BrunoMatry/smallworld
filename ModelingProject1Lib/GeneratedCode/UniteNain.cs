using System;
using System.Collections.Generic;

public class UniteNain : Unite
{
	private int joueur;

	public UniteNain(int j, Coordonnee c) {
		this._joueur = j;
		this._coordonnee = c;
		this._attaque = 2;
		this._defense = 1;
		this._pointsDeVie = 2;

		this._pointsDeplacement = 0;
		this._valeur = -1;
	}

	public override void NouveauTour(TypeCase caseActuelle) {
		switch (caseActuelle)
		{
			case TypeCase.FORET:
				this._valeur = 2;
				break;
			case TypeCase.PLAINE:
				this._valeur = 0;
				break;
			default:
				this._valeur = 1;
				break;
		}
		this._pointsDeplacement = 1;
	}

	// TODO déplacement vers case montagne
}

