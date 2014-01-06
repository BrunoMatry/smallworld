﻿using System;
using System.Collections.Generic;
using Wrapper;

public class MonteurDemo : StrategiePartie
{
    protected static int LARGEURCARTE = 5;
    protected static int HAUTEURCARTE = 5;

	public MonteurDemo () {}

	public override IPartie CreerPartie(string nomPartie, List<TypePeuple> tp) {

		// Creation de la fabrique de cases
		FabriqueCase f = new FabriqueCase();
		WrapperLib w = new WrapperLib(LARGEURCARTE, HAUTEURCARTE);

		// Generation de la carte par la fabrique
		ICarte c = new CarteDemo(f.CreerGrille(w), f.CreerCases());
		List<Tuple<int, int>> l = w.placer_unites(2);

		// Tirage aleatoire de l'ordre des joueurs
		Random begin = new Random();
		int fst = begin.Next(0, 2);
		int snd = (fst + 1) % 2;

		// Remplissage de la table des joueurs en generant deux nouveaux joueurs
		List<Tuple<int, IJoueur>> joueurs = new List<Tuple<int, IJoueur>>();
		Tuple<int, IJoueur> t1 = new Tuple<int, IJoueur>(fst, new Joueur(tp[fst], 4, new Coordonnee(l[fst].Item1, l[fst].Item2)));
		Tuple<int, IJoueur> t2 = new Tuple<int, IJoueur>(snd, new Joueur(tp[snd], 4, new Coordonnee(l[snd].Item1, l[snd].Item2)));
        joueurs.Add(t1);
		joueurs.Add(t2);    

        return new Partie(nomPartie, c, joueurs, 5);
	}

    public override IPartie CreerPartie(string nomPartie, List<TypePeuple> joueurs, List<List<Coordonnee>> unites, List<TypeCase> grille)
    {
		//TODO
		throw new System.NotImplementedException();
	}

}

