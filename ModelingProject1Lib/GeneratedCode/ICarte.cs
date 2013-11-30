using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ICarte 
{
    TypeCase[][] GetGrille();
	Case GetCase(Coordonnee c);
	List<Coordonnee> GetEmplacementUnites(int nbJoueurs);
	List<Direction> GetDirectionsAutorisees(Coordonnee c);
}

