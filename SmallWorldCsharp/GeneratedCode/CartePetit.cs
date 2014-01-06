using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CartePetit : Carte {

    public CartePetit(TypeCase[,] grille, Dictionary<TypeCase, Case> cases) {
        this._grille = grille;
        this._cases = cases;
		LARGEURCARTE = 10;
		HAUTEURCARTE = 10;
    }
}

