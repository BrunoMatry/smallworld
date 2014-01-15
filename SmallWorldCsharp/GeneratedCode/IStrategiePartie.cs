using System.Collections.Generic;

public interface IStrategiePartie {

	/**
	 * Methode permettant de gerer un objet interface par IPartie
	 * @param nomPartie le nom de la partie
	 * @param tp la liste des peuples choisis par les differents joueurs
	 * @return la partie qui a ete instanciee
	 */
	IPartie CreerPartie(string nomPartie, List<TypePeuple> tp);
}

