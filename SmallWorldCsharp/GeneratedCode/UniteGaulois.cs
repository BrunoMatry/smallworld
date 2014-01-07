using System;
using System.Collections.Generic;

[Serializable]
public class UniteGaulois : Unite {

	// Constructeur par defaut pour serialisation
	public UniteGaulois() : base() {}

	public UniteGaulois(int j, Coordonnee c) : base(j, c) {}

	public override void NouveauTour(TypeCase caseActuelle) {
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
}

