using System;
using System.Collections.Generic;

[Serializable]
public class UniteNain : Unite {

	// Constructeur par defaut pour serialisation
	public UniteNain() : base() {}

	public UniteNain(int j, Coordonnee c) : base(j, c) {}

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
}

