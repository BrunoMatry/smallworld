using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class CartePetit : Carte {

	// Constructeur par defaut pour serialisation
	public CartePetit() {}

	public CartePetit(TypeCase[][] grille, Dictionary<TypeCase, Case> cases) {
        this._grille = grille;
        this._cases = cases;
		LARGEURCARTE = 10;
		HAUTEURCARTE = 10;
    }
}

