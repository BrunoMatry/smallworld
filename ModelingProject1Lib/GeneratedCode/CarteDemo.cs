using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarteDemo : Carte
{
    private int LARGEURCARTE = 5;
    private int HAUTEURCARTE = 5;

    public CarteDemo(TypeCase[][] grille, Dictionary<TypeCase, Case> cases) {
        this._grille = grille;
        this._cases = cases;
    }

	public override List<Coordonnee> GetEmplacementUnites(int nbJoueurs)
	{
		throw new System.NotImplementedException();
	}

	public override List<Direction> GetDirectionsAutorisees(Coordonnee c)
	{
		throw new System.NotImplementedException();
	}

    protected override Boolean appartient(Coordonnee c) {
        int x = c.GetX();
        int y = c.GetY();
        return x >= 0 && x < LARGEURCARTE && y >= 0 && y < HAUTEURCARTE;
    }
}

