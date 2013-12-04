using System;
using System.Collections.Generic;

public abstract class StrategiePartie : IStrategiePartie
{
	public abstract IPartie CreerPartie(string tc, List<TypePeuple> tp);
	protected abstract ICarte MonterCarte();
	protected abstract ICarte MonterCarte(List<TypeCase> grille);
	public abstract IPartie CreerPartie(string tp, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille);
}

