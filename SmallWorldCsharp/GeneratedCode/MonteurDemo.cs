using System;
using System.Collections.Generic;

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
        joueurs.Add(0, new Joueur(tp[0], 4, new Coordonnee(0, 0)));
        joueurs.Add(1, new Joueur(tp[1], 4, new Coordonnee(4, 4)));
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

