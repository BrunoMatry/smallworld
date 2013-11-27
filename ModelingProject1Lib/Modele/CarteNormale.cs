using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarteNormale : Carte
{
    protected override static int HAUTEUR = 15;
    protected override static int LARGEUR = 15;

    public CarteNormale() {
        _fabrique = new FabriqueCase();
        _cases = _fabrique.InitialiserCases();
        _grilleCases = _fabrique.CreerGrille(HAUTEUR * LARGEUR);
    }

    public CarteNormale(TypeCase[][] g) {
        _fabrique = new FabriqueCase();
        _cases = _fabrique.InitialiserCases();
        _grilleCases = g;
    }
}

