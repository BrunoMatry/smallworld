using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CartePetit : Carte
{
    private int LARGEURCARTE = 10;
    private int HAUTEURCARTE = 10;

    public CartePetit(TypeCase[,] grille, Dictionary<TypeCase, Case> cases) {
        this._grille = grille;
        this._cases = cases;
    }

}

