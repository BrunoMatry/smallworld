using System.Collections.Generic;
using Wrapper;

public interface IFabriqueCase {

	Dictionary<TypeCase, Case> CreerCases(WrapperLib w);
	TypeCase[,] CreerGrille();
}

