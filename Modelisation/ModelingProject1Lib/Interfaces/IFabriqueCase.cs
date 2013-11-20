using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IFabriqueCase 
{
    Dictionary<TypeCase, Case> InitialiserCases();
    TypeCase[][] CreerGrille(int nbCases);
}

