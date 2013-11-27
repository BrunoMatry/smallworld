using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CartePetit : Carte
{
    protected override static int HAUTEUR = 10;
    protected override static int LARGEUR = 10;

    public CartePetit() {
        _fabrique = new FabriqueCase();
        _cases = _fabrique.InitialiserCases();
        _grilleCases = _fabrique.CreerGrille(HAUTEUR * LARGEUR);
    }

    public CartePetit(TypeCase[][] g) {
        _fabrique = new FabriqueCase();
        _cases = _fabrique.InitialiserCases();
        _grilleCases = g;
    }
}

