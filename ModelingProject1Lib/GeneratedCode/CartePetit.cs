using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CartePetit : Carte
{
    private int LARGEURCARTE = 10;
    private int HAUTEURCARTE = 10;

    public CartePetit(TypeCase[][] grille, Dictionary<TypeCase, Case> cases) {
        this._grille = grille;
        this._cases = cases;
    }

    public override List<Coordonnee> getEmplacementUnites(int nbJoueurs)
    {
        throw new System.NotImplementedException();
    }

    public override List<Direction> getDirectionsAutorisees(Coordonnee c)
    {
        throw new System.NotImplementedException();
    }

    protected override Boolean appartient(Coordonnee c) {
        int x = c.GetX();
        int y = c.GetY();
        return x >= 0 && x < LARGEURCARTE && y >= 0 && y < HAUTEURCARTE;
    }
}

