﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public abstract class MonteurPartie : IMonteurPartie {

	public static  Partie ChargerPartie(String fileName) {
		Partie p;
		XmlSerializer serializer = new XmlSerializer(typeof(Partie));
		using (StreamReader reader = new StreamReader(fileName)) {
			p = serializer.Deserialize(reader) as Partie;
		}
        p.initGrilleUnite();
		p.miseAJourGilleUnite();
		return p;
		// Penser a recharger les cases de la carte demo
		// Penser a recharger la grilleUnite
	}

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