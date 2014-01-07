﻿using System;
using System.Collections.Generic;

public class UniteViking : Unite {

	public UniteViking(int j, Coordonnee c) : base() {
		this._joueur = j;
		this._coordonnee = c;
		this._attaque = 2;
		this._defense = 1;
		this._pointsDeVie = 2;
		this._pointsDeplacement = 0;
		this._valeur = -1;
	}

	public override void NouveauTour(TypeCase caseActuelle) {
		switch (caseActuelle) {
			case TypeCase.DESERT:
				// si l'unite se trouve sur une case de type desert elle ne rapporte pas de point
				this._valeur = 0;
				break;
			default:
				// sinon elle rapporte un point
				this._valeur = 1;
				break;
		}
		this._pointsDeplacement = 1;
	}
}

