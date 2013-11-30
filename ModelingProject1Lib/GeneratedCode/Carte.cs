using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Carte : ICarte
{
    protected virtual Dictionary<TypeCase, Case> _cases;
    protected virtual IFabriqueCase _fabrique;
    protected virtual TypeCase[][] _grille;

    public virtual TypeCase[][] GetGrille() {
		return _grille;
	}

	public virtual Case GetCase(Coordonnee c)
	{
        // On verifie si la coordonnee est dans la carte
        if (this.appartient(c)) {
            // retourne l'instance de la case du bon type
            return _cases[_grille[c.getX()][c.getY()]]; 
        } else {
            return null;
        }
	}

	public abstract List<Coordonnee> GetEmplacementUnites(int nbJoueurs);

	public abstract List<Direction> GetDirectionsAutorisees(Coordonnee c);

    protected Boolean appartient(Coordonnee c);
}

