using System.Collections.Generic;

public interface IFabriqueCase {

	Dictionary<TypeCase, Case> CreerCases();
	TypeCase[][] CreerGrille();
}

