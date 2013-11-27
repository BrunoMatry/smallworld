using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IFabriqueUnite 
{
	List<IUnite> CreerUnites(TypePeuple type, int nbUnites, int joueur);

}

