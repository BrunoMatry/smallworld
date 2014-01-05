﻿using System;
using System.Collections.Generic;

public abstract class Carte : ICarte
{
    protected Dictionary<TypeCase, Case> _cases;
    protected TypeCase[,] _grille;
	protected Dictionary<Coordonnee, List<IUnite>> _grilleUnites;
	protected static int HAUTEURCARTE;
	protected static int LARGEURCARTE;

	// Propriétés
	public TypeCase[,] Grille { get { return this._grille; } }
	public Dictionary<Coordonnee, List<IUnite>> GrilleUnites { get { return this._grilleUnites; } set { this._grilleUnites = value; } }

	public Case GetCase(Coordonnee c) {
        // On verifie si la coordonnee est dans la carte
        if (this.appartient(c)) {
            // retourne l'instance de la case du bon type
            return _cases[_grille[c.X, c.Y]]; 
        } else {
            return null;
        }
	}

	
	public List<Coordonnee> GetEmplacementUnites(int nbJoueurs)	{
		List<Coordonnee> emplacements = new List<Coordonnee>();
		switch (nbJoueurs) {
			case 2:
				emplacements.Add(new Coordonnee(0, 0));
				emplacements.Add(new Coordonnee((HAUTEURCARTE - 1), (LARGEURCARTE - 1)));
				break;
			default:
				emplacements.Add(new Coordonnee(0, 0));
				break;
		}
		return emplacements;
	}

	public List<Direction> GetDirectionsAutorisees(Coordonnee c) {
		int x = c.X;
		int y = c.Y;
		List<Direction> dirAutorisees = new List<Direction>();
		if (y < (HAUTEURCARTE - 1))
			dirAutorisees.Add(Direction.NORD);
		if (x < (LARGEURCARTE - 1))
			dirAutorisees.Add(Direction.EST);
		if (x > 0)
			dirAutorisees.Add(Direction.SUD);
		if (y > 0)
			dirAutorisees.Add(Direction.OUEST);
		return dirAutorisees;
	}

	/**
	 * Methode permettant de savoir si une coordonnee appartient a la carte
	 * @param c La coordonnée a tester
	 * @return true si la coordonnee appartient a la carte, false sinon
	 */
	protected Boolean appartient(Coordonnee c) {
		int x = c.X;
		int y = c.Y;
		return x >= 0 && x < LARGEURCARTE && y >= 0 && y < HAUTEURCARTE;
	}

	public TypeCase GetTypeCase(Coordonnee c) { return _grille[c.X, c.Y]; }
}
