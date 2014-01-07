using System;
using System.Collections.Generic;

public abstract class StrategiePartie : IStrategiePartie {

	public abstract IPartie CreerPartie(string nomPartie, List<TypePeuple> tp);
}

