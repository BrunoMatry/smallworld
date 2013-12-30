using System;
using System.Collections.Generic;

public class MonteurNormal : StrategiePartie
{
    protected static int LARGEURCARTE = 15;
    protected static int HAUTEURCARTE = 15;

    public override IPartie CreerPartie(string nomPartie, List<TypePeuple> tp)
    {

        ICarte c = monterCarte();
        Dictionary<int, IJoueur> joueurs = new Dictionary<int, IJoueur>();
        joueurs.Add(0, new Joueur(tp[0], 8));
        joueurs.Add(1, new Joueur(tp[1], 8));
        Random begin = new Random();
        return new Partie(nomPartie, tp, c, joueurs, 30, begin.Next(0, 2));
    }

	public override IPartie CreerPartie(string tp, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
	{
		throw new System.NotImplementedException();
	}

}

