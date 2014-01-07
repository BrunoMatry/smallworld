using System;
using System.Collections.Generic;
using Wrapper;

public class FabriqueCase : IFabriqueCase {

    public FabriqueCase() {}

	/**
	 * Methode retournant les instances (singleton) des classes Case associees a leur type
	 */
	public Dictionary<TypeCase, Case> CreerCases() {
        Dictionary<TypeCase, Case> res = new Dictionary<TypeCase, Case>();
        // Ajout des differents types de case
        res.Add(TypeCase.DESERT, new CaseDesert());
        res.Add(TypeCase.EAU, new CaseEau());
        res.Add(TypeCase.FORET, new CaseForet());
        res.Add(TypeCase.MONTAGNE, new CaseMontagne());
        res.Add(TypeCase.PLAINE, new CasePlaine());
        return res;
	}

	/**
	 * Methode permettant de generer une nouvelle grille en utilisant le wrapper
	 */
	public TypeCase[][] CreerGrille(WrapperLib w) {
        List<int> lcases =  w.generer_carte((int) TypeCase.NB_VAL);
		Tuple<int, int> dim = w.get_dimensions();
		TypeCase[][] grille = new TypeCase[dim.Item1][];
		for (int i = 0; i < dim.Item1; i++) {
			grille[i] = new TypeCase[dim.Item2];
			for (int j = 0 ; j < dim.Item2 ; j++){
                TypeCase t;
				switch (lcases[((i * dim.Item1) + j)]) {
                    case 0:
                        t = TypeCase.DESERT;
                        break;
                    case 1:
                        t = TypeCase.EAU;
                        break;
                    case 2:
                        t = TypeCase.FORET;
                        break;
                    case 3:
                        t = TypeCase.MONTAGNE;
                        break;
                    case 4:
                        t = TypeCase.PLAINE;
                        break;
                    default:
                        t = TypeCase.FORET;
                        break;
                }
                grille[i][j] = t;
            }
        }
        return grille;
    }
}

