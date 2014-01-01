using System;
using System.Collections.Generic;

public class MonteurPetit : StrategiePartie
{
    protected static int LARGEURCARTE = 10;
    protected static int HAUTEURCARTE = 10;

    public override IPartie CreerPartie(string nomPartie, List<TypePeuple> tp) {
		FabriqueCase f = new FabriqueCase(LARGEURCARTE, HAUTEURCARTE);
		ICarte c = new CartePetit(f.CreerGrille(), f.CreerCases());
        Dictionary<int, IJoueur> joueurs = new Dictionary<int, IJoueur>();
        joueurs.Add(0, new Joueur(tp[0], 6, new Coordonnee(0, 0)));
        joueurs.Add(0, new Joueur(tp[1], 6, new Coordonnee (9, 9)));
        Random begin = new Random();
        return new Partie(nomPartie, tp, c, joueurs, 20, begin.Next(0, 2));
    }

	public override IPartie CreerPartie(string tp, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
	{
		//TODO
		throw new System.NotImplementedException();
	}

}

