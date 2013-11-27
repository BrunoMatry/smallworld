using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ICarte 
{
    TypeCase[][] GetGrille();
	Case GetCase(Coordonnee c);
	List<Direction> GetDirectionsAutorisees(Coordonnee c);
}

