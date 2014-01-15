using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlInclude(typeof(CarteDemo))]
[XmlInclude(typeof(CarteNormale))]
[XmlInclude(typeof(CartePetit))]
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
	[XmlIgnoreAttribute]
	public Dictionary<Coordonnee, List<Unite>> GrilleUnites { get { return this._grilleUnites; } set { this._grilleUnites = value; } }

	// Constructeur par defaut pour serialisation
	public Carte() {}

	public Case GetCase(Coordonnee c) {
        // On verifie si la coordonnee est dans la carte
        if (this.appartient(c)) {
            // retourne l'instance de la case du bon type
            return _cases[_grille[c.X][c.Y]]; 
        } else {
            return null;
        }
	}

	/*
	 * Methode permettant de recuperer la liste des directions autorisees depuis une case donnee
	 * @param c les coordonnees de la case donnee
	 * @return la liste des directions autorisees
	 */
	public List<Direction> GetDirectionsAutorisees(Coordonnee c) {
		int x = c.X;
		int y = c.Y;
		Coordonnee ctmp;
		List<Direction> dirAutorisees = new List<Direction>();
		if (y < (HAUTEURCARTE - 1)) {
			ctmp = c + Direction.NORD;
			if(_grille[ctmp.X][ctmp.Y] != TypeCase.EAU)
				dirAutorisees.Add(Direction.NORD);
		}
		if (x < (LARGEURCARTE - 1)) {
			ctmp = c + Direction.EST;
			if (_grille[ctmp.X][ctmp.Y] != TypeCase.EAU)
				dirAutorisees.Add(Direction.EST);
		}
		if (y > 0) {
			ctmp = c + Direction.SUD;
			if (_grille[ctmp.X][ctmp.Y] != TypeCase.EAU)
				dirAutorisees.Add(Direction.SUD);
		}
		if (x > 0) {
			ctmp = c + Direction.OUEST;
			if (_grille[ctmp.X][ctmp.Y] != TypeCase.EAU)
				dirAutorisees.Add(Direction.OUEST);
		}
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

