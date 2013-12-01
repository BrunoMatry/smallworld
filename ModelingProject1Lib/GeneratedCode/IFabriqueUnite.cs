using System.Collections.Generic;

public interface IFabriqueUnite {

	List<IUnite> CreerUnites(TypePeuple type, int nbUnites, int joueur);
}

