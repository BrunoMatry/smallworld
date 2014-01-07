using System;
using System.Collections.Generic;
using Wrapper;

public class MonteurNormal : StrategiePartie
{
    protected static int LARGEURCARTE = 15;
    protected static int HAUTEURCARTE = 15;

	public MonteurNormal () {}

    public override IPartie CreerPartie(string nomPartie, List<TypePeuple> tp) {

		// Creation de la fabrique de cases
		FabriqueCase f = new FabriqueCase();
		WrapperLib w = new WrapperLib(LARGEURCARTE, HAUTEURCARTE);

		// Generation de la carte par la fabrique
		Carte c = new CarteNormale(f.CreerGrille(w), f.CreerCases());
		List<Tuple<int, int>> l = w.placer_unites(2);

		// Tirage aleatoire de l'ordre des joueurs
		Random begin = new Random();
		int fst = begin.Next(0, 2);
		int snd = (fst + 1) % 2;

		// Remplissage de la table des joueurs en generant deux nouveaux joueurs
		List<Tuple<int, Joueur>> joueurs = new List<Tuple<int, Joueur>>();
		Tuple<int, Joueur> t1 = new Tuple<int, Joueur>(fst, new Joueur(tp[fst], 8, new Coordonnee(l[fst].Item1, l[fst].Item2)));
		Tuple<int, Joueur> t2 = new Tuple<int, Joueur>(snd, new Joueur(tp[snd], 8, new Coordonnee(l[snd].Item1, l[snd].Item2)));
		joueurs.Add(t1);
		joueurs.Add(t2);

		return new Partie(nomPartie, c, joueurs, 30);
    }

	public override IPartie CreerPartie(string tp, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
	{
		//TODO
		throw new System.NotImplementedException();
	}

}

