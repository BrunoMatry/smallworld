using System;
using System.Collections.Generic;

public class UniteGaulois : Unite
{
	public UniteGaulois(int j, Coordonnee c) {
		this._joueur = j;
		this._coordonnee = c;
		this._attaque = 2;
		this._defense = 1;
		this._pointsDeVie = 2;

		this._pointsDeplacement = 0;
		this._valeur = -1;
	}

	public override void nouveauTour(TypeCase caseActuelle) {
		switch (caseActuelle)
		{
			case TypeCase.PLAINE:
				this._valeur = 2;
				this._pointsDeplacement = 2;
				break;
			case TypeCase.MONTAGNE:
				this._valeur = 0;
				this._pointsDeplacement = 1;
				break;
			default:
				this._valeur = 1;
				this._pointsDeplacement = 1;
				break;
		}
	}

	public override void deplacer(Coordonnee caseCible, TypeCase caseActuelle) {

		throw new System.NotImplementedException();
	}
}

