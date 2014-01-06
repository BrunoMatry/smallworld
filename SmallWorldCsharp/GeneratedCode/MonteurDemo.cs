using System;
using System.Collections.Generic;
using Wrapper;

public class MonteurDemo : StrategiePartie
{
    protected static int LARGEURCARTE = 5;
    protected static int HAUTEURCARTE = 5;

	public MonteurDemo () {}

	public override IPartie CreerPartie(string nomPartie, List<TypePeuple> tp) {
		// Creation de la fabrique de cases
		FabriqueCase f = new FabriqueCase(LARGEURCARTE, HAUTEURCARTE);
		// Generation de la carte par la fabrique
		ICarte c = new CarteDemo(f.CreerGrille(), f.CreerCases());
		// Remplissage de la table des joueurs en generant deux nouveaux joueurs
        Dictionary<int, IJoueur> joueurs = new Dictionary<int, IJoueur>();
		WrapperLib w = new WrapperLib(LARGEURCARTE, HAUTEURCARTE);
		List<Tuple<int,int>> l = w.placer_unites(2);
        joueurs.Add(0, new Joueur(tp[0], 4, new Coordonnee(l[0].Item1, l[0].Item2)));
		joueurs.Add(1, new Joueur(tp[1], 4, new Coordonnee(l[1].Item1, l[1].Item2)));
		// Choix aleatoire du joueur qui commencera
        Random begin = new Random();
        return new Partie(nomPartie, c, joueurs, 5, begin.Next(0, 2));
	}

    public override IPartie CreerPartie(string nomPartie, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
    {
		//TODO
		throw new System.NotImplementedException();
	}

}

