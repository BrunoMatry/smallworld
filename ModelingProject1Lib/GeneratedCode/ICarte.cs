using System.Collections.Generic;

public interface ICarte {
    TypeCase GetTypeCase(Coordonnee c);
    TypeCase[,] GetGrille();
	Case GetCase(Coordonnee c);
	List<Coordonnee> GetEmplacementUnites(int nbJoueurs);
	List<Direction> GetDirectionsAutorisees(Coordonnee c);
}

