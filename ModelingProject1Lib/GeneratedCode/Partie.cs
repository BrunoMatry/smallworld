using System;
using System.Collections.Generic;


public class Partie : IPartie
{
	private ICarte _carte;
	private Dictionary<int, IJoueur> _joueurs;
	private int _toursRestants;
	private IUnite _uniteCourante;
	private string _nom;
	private List<int> _pointsJoueurs;
	private IJoueur _joueurCourant;

	public virtual List<IUnite> getUnites()
	{
		throw new System.NotImplementedException();
	}

	public virtual void attaque(Direction Direction dir)
	{
		throw new System.NotImplementedException();
	}

	public virtual void deplacement(Direction dir)
	{
		throw new System.NotImplementedException();
	}

	public virtual void passerTour()
	{
		throw new System.NotImplementedException();
	}

	public virtual IUnite getUniteCourante()
	{
		throw new System.NotImplementedException();
	}

	public virtual bool nouveauTour()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<Coordonnee> getDirectionsAutorisees(Coordonnee c)
	{
		throw new System.NotImplementedException();
	}

	public virtual List<TypeCase> getGrille()
	{
		throw new System.NotImplementedException();
	}

	public virtual void enregistrer()
	{
		throw new System.NotImplementedException();
	}

	public virtual void enregistrerSous()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<int> getPointsJoueurs()
	{
		throw new System.NotImplementedException();
	}

	public virtual void passerTourJoueur()
	{
		throw new System.NotImplementedException();
	}

	private void acualiserPointsJoueurs()
	{
		throw new System.NotImplementedException();
	}

	public virtual void selectionner(IUnite unite)
	{
		throw new System.NotImplementedException();
	}

	private List<IUnite> getUntesCible(Coordonnee c)
	{
		throw new System.NotImplementedException();
	}

}

