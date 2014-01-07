using System;
using System.Collections.Generic;

[Serializable]
public class UniteViking : Unite {
	
	// Constructeur par defaut pour serialisation
	public UniteViking() : base() {}

	public UniteViking(int j, Coordonnee c) : base(j, c) {}

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

