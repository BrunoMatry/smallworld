using System.Collections.Generic;
using Wrapper;

public interface IFabriqueCase {

	Dictionary<TypeCase, Case> CreerCases();
    TypeCase[,] CreerGrille(WrapperLib w);
}

