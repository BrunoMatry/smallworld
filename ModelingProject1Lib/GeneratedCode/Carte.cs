using System;
using System.Collections.Generic;

public abstract class Carte : ICarte
{
    protected Dictionary<TypeCase, Case> _cases;
    protected TypeCase[][] _grille;

    public virtual TypeCase[][] GetGrille() {
		return _grille;
	}

	public virtual Case GetCase(Coordonnee c)
	{
        // On verifie si la coordonnee est dans la carte
        if (this.appartient(c)) {
            // retourne l'instance de la case du bon type
            return _cases[_grille[c.GetX()][c.GetY()]]; 
        } else {
            return null;
        }
	}

	public abstract List<Coordonnee> GetEmplacementUnites(int nbJoueurs);
	public abstract List<Direction> GetDirectionsAutorisees(Coordonnee c);
    protected abstract Boolean appartient(Coordonnee c);
}

