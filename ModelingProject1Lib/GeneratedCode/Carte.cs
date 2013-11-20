using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Carte : ICarte
{
    protected virtual List<Case> _cases;
    protected virtual Partie _partie;
    protected virtual IFabriqueCase _fabrique;
	protected virtual TypeCase[][] _grilleCases  { get; }

	public virtual Case getCase(Coordonnee c)
	{
		throw new System.NotImplementedException();
	}

	public abstract List<Coordonnee> getEmplacementUnites(int nbJoueurs);

	public abstract List<Direction> getDirectionsAutorisees(Coordonnee c);

}

