using System.Collections.Generic;

public interface IStrategiePartie {

	IPartie CreerPartie(string nomPartie, List<TypePeuple> tp);
	IPartie CreerPartie(string nomPartie, List<TypePeuple> tp, List<List<Coordonnee>> unites, List<TypeCase> grille);
}

