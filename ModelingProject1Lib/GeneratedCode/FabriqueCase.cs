using System.Collections.Generic;

public class FabriqueCase : IFabriqueCase
{
    private static int LARGEURCARTE;
    private static int HAUTEURCARTE;
    private static int NOMBRETYPECASES = 5;

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

    public TypeCase[][] CreerGrille() {
        // TODO Communication avec le wrapper
		throw new System.NotImplementedException();
    }
}

