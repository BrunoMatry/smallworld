using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IStrategiePartie {

	IPartie CreerPartie(string nomPartie, List<TypePeuple> tp);
	IPartie CreerPartie(string nomPartie, List<TypePeuple> tp, List<List<Coordonnee>> unites, List<TypeCase> grille);
}

