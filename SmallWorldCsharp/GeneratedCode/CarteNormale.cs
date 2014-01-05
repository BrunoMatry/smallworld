using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarteNormale : Carte
{
    private int LARGEURCARTE = 15;
    private int HAUTEURCARTE = 15;

    public CarteNormale(TypeCase[,] grille, Dictionary<TypeCase, Case> cases) {
        this._grille = grille;
        this._cases = cases;
    }
}

