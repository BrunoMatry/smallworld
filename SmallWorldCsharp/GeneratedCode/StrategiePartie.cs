using System;
using System.Collections.Generic;

public abstract class StrategiePartie : IStrategiePartie {

	public abstract IPartie CreerPartie(string nomPartie, List<TypePeuple> tp);
    public abstract IPartie CreerPartie(string nomPartie, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille);
}

