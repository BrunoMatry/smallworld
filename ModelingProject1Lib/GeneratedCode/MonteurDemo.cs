using System;
using System.Collections.Generic;

public class MonteurDemo : StrategiePartie
{
    protected static int LARGEURCARTE = 5;
    protected static int HAUTEURCARTE = 5;

	protected override ICarte monterCarte(List<TypeCase> grille) {
		throw new System.NotImplementedException();
	}

	public override IPartie CreerPartie(string nomPartie, List<TypePeuple> tp) {

        ICarte c = monterCarte();
        Dictionary<int, IJoueur> joueurs = new Dictionary<int, IJoueur>();
        joueurs.Add(0, new Joueur(tp[0],4));
        joueurs.Add(0, new Joueur(tp[1], 4));
        Random begin = new Random();
        return new Partie(nomPartie, tp, c, joueurs, 5, begin.Next(0, 2));
	}

    public override IPartie CreerPartie(string nomPartie, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
    {
		throw new System.NotImplementedException();
	}

}

