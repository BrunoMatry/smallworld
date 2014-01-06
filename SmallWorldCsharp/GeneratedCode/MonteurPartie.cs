using System;
using System.Collections.Generic;

public abstract class MonteurPartie : IMonteurPartie {

	private IStrategiePartie _strategie;

	//TODO
	public IPartie CreerPartie(String file)	{ throw new System.NotImplementedException(); }

	/**
	 * Methode permettant la creation d'une partie
	 * tc Le type de la carte
	 * tp Les peuples choisis par les joueurs
	 * nomPartie Le nom de la partie
	 */
	public static IPartie CreerPartie(TypeCarte tc, List<TypePeuple> tp, string nomPartie) {
		StrategiePartie s;
		switch (tc) {
			case TypeCarte.DEMO:
				s = new MonteurDemo();
				break;
			case TypeCarte.PETIT:
				s = new MonteurPetit();
				break;
			case TypeCarte.NORMAL:
				s = new MonteurNormal();
				break;
			default:
				s = new MonteurDemo();
				break;
		}
		return s.CreerPartie(nomPartie, tp);
	}
}