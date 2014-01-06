using System;
using System.Collections.Generic;
using Wrapper;

public class MonteurPetit : StrategiePartie
{
    protected static int LARGEURCARTE = 10;
    protected static int HAUTEURCARTE = 10;

	public MonteurPetit () {}

    public override IPartie CreerPartie(string nomPartie, List<TypePeuple> tp) {
		/* Meme methode que pour la classe MonteurDemo */
		FabriqueCase f = new FabriqueCase();
		WrapperLib w = new WrapperLib(LARGEURCARTE, HAUTEURCARTE);
		ICarte c = new CartePetit(f.CreerGrille(w), f.CreerCases());
        Dictionary<int, IJoueur> joueurs = new Dictionary<int, IJoueur>();
		List<Tuple<int, int>> l = w.placer_unites(2);
		joueurs.Add(0, new Joueur(tp[0], 6, new Coordonnee(l[0].Item1, l[0].Item2)));
		joueurs.Add(0, new Joueur(tp[1], 6, new Coordonnee(l[1].Item1, l[1].Item2)));
        Random begin = new Random();
        return new Partie(nomPartie, c, joueurs, 20, begin.Next(0, 2));
    }

	public override IPartie CreerPartie(string tp, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
	{
		//TODO
		throw new System.NotImplementedException();
	}

}

