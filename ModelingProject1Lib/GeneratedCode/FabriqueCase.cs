using System.Collections.Generic;
using wrapper;

public class FabriqueCase : IFabriqueCase
{
    private static int LARGEURCARTE;
    private static int HAUTEURCARTE;

    public FabriqueCase(int l, int h) {
        LARGEURCARTE = l;
        HAUTEURCARTE = h;
    }

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

    public TypeCase[,] CreerGrille() {
        List<int> lcases = WrapperCarte.wrap_gen_carte((int)TypeCase.NB_VAL, (LARGEURCARTE * HAUTEURCARTE));
        TypeCase[,] grille = new TypeCase[LARGEURCARTE, HAUTEURCARTE];
        for(int i = 0 ; i < LARGEURCARTE ; i++) {
            for (int j = 0; j < HAUTEURCARTE; j++) {
                TypeCase t;
                switch (lcases[((i * LARGEURCARTE) + j)]) {
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
                grille[i, j] = t;
            }
        }
        return grille;
    }
}

