using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Carte : ICarte
{
    protected virtual Dictionary<TypeCase, Case> _cases;
    protected virtual IFabriqueCase _fabrique;
    protected virtual TypeCase[][] _grilleCases;
    protected virtual static int HAUTEUR;
    protected virtual static int LARGEUR;

    public TypeCase[][] GetGrille () {
        return _grilleCases;
    }

	public Case GetCase(Coordonnee c) {
        TypeCase t = _grilleCases[c.GetX()][c.GetY()];
        return _cases[t];
	}

    public List<Direction> GetDirectionsAutorisees(Coordonnee c)
    {
        List<Direction> res = new List<Direction>();
        if (c.GetX() > 0)
            res.Add(Direction.OUEST);
        if (c.GetY() > 0)
            res.Add(Direction.SUD);
        if (c.GetX() < (LARGEUR - 1))
            res.Add(Direction.EST);
        if (c.GetY() < (HAUTEUR - 1))
            res.Add(Direction.NORD);
        return res;
    }
}

