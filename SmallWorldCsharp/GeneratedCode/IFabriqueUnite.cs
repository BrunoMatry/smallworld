using System.Collections.Generic;

public interface IFabriqueUnite {

	List<Unite> CreerUnites(TypePeuple type, int nbUnites, int joueur, Coordonnee c);
}

