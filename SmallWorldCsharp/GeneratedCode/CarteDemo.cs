using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarteDemo : Carte {

    public CarteDemo(TypeCase[,] grille, Dictionary<TypeCase, Case> cases) {
        this._grille = grille;
        this._cases = cases;
		LARGEURCARTE = 5;
		HAUTEURCARTE = 5;
    }
}

