using System;
using System.Collections.Generic;

public abstract class Carte : ICarte {

    protected Dictionary<TypeCase, Case> _cases;
    protected TypeCase[][] _grille;
	protected Dictionary<Coordonnee, List<Unite>> _grilleUnites;
	protected  int HAUTEURCARTE;
	protected  int LARGEURCARTE;

	// Propriétés
	public TypeCase[][] Grille { get { return this._grille; } set { this._grille = value; } }
    public int Hauteur { get { return HAUTEURCARTE; } set { HAUTEURCARTE = value; } }
	public int Largeur { get { return LARGEURCARTE; } set { LARGEURCARTE = value; } }
	public Dictionary<Coordonnee, List<Unite>> GrilleUnites { get { return this._grilleUnites; } set { this._grilleUnites = value; } }

	public Case GetCase(Coordonnee c) {
        // On verifie si la coordonnee est dans la carte
        if (this.appartient(c)) {
            // retourne l'instance de la case du bon type
            return _cases[_grille[c.X][c.Y]]; 
        } else {
            return null;
        }
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

	public TypeCase GetTypeCase(Coordonnee c) { return _grille[c.X][c.Y]; }
}

