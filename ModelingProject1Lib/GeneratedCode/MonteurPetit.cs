using System;
using System.Collections.Generic;

public class MonteurPetit : StrategiePartie
{
    protected static int LARGEURCARTE = 10;
    protected static int HAUTEURCARTE = 10;

    public override IPartie CreerPartie(string nomPartie, List<TypePeuple> tp)
    {

        ICarte c = monterCarte();
        Dictionary<int, IJoueur> joueurs = new Dictionary<int, IJoueur>();
        joueurs.Add(0, new Joueur(tp[0], 6));
        joueurs.Add(0, new Joueur(tp[1], 6));
        Random begin = new Random();
        return new Partie(nomPartie, tp, c, joueurs, 20, begin.Next(0, 2));
    }

	public override IPartie CreerPartie(string tp, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
	{
		throw new System.NotImplementedException();
	}

}

