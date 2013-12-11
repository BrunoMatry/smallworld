using System;
using System.Collections.Generic;

public abstract class StrategiePartie : IStrategiePartie
{
    protected static int LARGEURCARTE;
    protected static int HAUTEURCARTE;

	public abstract IPartie CreerPartie(string nomPartie, List<TypePeuple> tp);
    public abstract IPartie CreerPartie(string nomPartie, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille);
    
    protected ICarte monterCarte()  {
        FabriqueCase f = new FabriqueCase(LARGEURCARTE, HAUTEURCARTE);
        ICarte c = new CarteDemo(f.CreerGrille() ,f.CreerCases());
        return c;
	}

    protected abstract ICarte monterCarte(TypeCase[,] grille) {
        FabriqueCase f = new FabriqueCase(LARGEURCARTE, HAUTEURCARTE);
        ICarte c = new CarteDemo(grille, f.CreerCases());
        return c;
    }
}

