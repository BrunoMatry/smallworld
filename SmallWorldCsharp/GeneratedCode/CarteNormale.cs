using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarteNormale : Carte {

    public CarteNormale(TypeCase[,] grille, Dictionary<TypeCase, Case> cases) {
        this._grille = grille;
        this._cases = cases;
		LARGEURCARTE = 15;
		HAUTEURCARTE = 15;
    }
}

