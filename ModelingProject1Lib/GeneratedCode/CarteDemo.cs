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

}

