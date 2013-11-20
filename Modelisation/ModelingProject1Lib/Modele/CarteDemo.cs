using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarteDemo : Carte
{
    protected override static int HAUTEUR = 5;
    protected override static int LARGEUR = 5;

    public CarteDemo() {
        _fabrique = new FabriqueCase();
        _cases = _fabrique.InitialiserCases();
        _grilleCases = _fabrique.CreerGrille(HAUTEUR * LARGEUR);
    }

    public CarteDemo(TypeCase[][] g) {
        _fabrique = new FabriqueCase();
        _cases = _fabrique.InitialiserCases();
        _grilleCases = g;
    }
}