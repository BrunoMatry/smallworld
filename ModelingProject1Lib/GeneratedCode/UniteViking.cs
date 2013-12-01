using System;
using System.Collections.Generic;

public class UniteViking : Unite
{
	public UniteViking(int j, Coordonnee c) {
		this._joueur = j;
		this._coordonnee = c;
		this._attaque = 2;
		this._defense = 1;
		this._pointsDeVie = 2;
		
		this._pointsDeplacement = 0;
		this._valeur = -1;
	}
	public override void nouveauTour(TypeCase caseActuelle) {
		switch (caseActuelle) {
			case TypeCase.EAU:
				this._valeur = 0;
				break;
			case TypeCase.DESERT:
				this._valeur = 0;
				break;
			default:
				this._valeur = 1;
				break;
		}
		// TODO Verifier la type des cases proches
		this._pointsDeplacement = 1;
	}

	public override void deplacer(Coordonnee caseCible, TypeCase caseActuelle) {
		throw new System.NotImplementedException();
	}
}

