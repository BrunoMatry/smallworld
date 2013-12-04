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

	public virtual List<IUnite> GetUnites()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Attaque(Direction dir)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Deplacement(Direction dir)
	{
		throw new System.NotImplementedException();
	}

	public virtual void PasserTourUniteCourante()
	{
		throw new System.NotImplementedException();
	}

	public virtual IUnite GetUniteCourante()
	{
		throw new System.NotImplementedException();
	}

	public virtual bool NouveauTour()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<Coordonnee> GetDirectionsAutorisees(Coordonnee c)
	{
		throw new System.NotImplementedException();
	}

	public virtual List<TypeCase> GetGrille()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Enregistrer()
	{
		throw new System.NotImplementedException();
	}

	public virtual void EnregistrerSous()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<int> GetPointsJoueurs()
	{
		throw new System.NotImplementedException();
	}

	public virtual void PasserTourJoueur()
	{
		throw new System.NotImplementedException();
	}

	private void acualiserPointsJoueurs()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Selectionner(IUnite unite)
	{
		throw new System.NotImplementedException();
	}

	private List<IUnite> getUntesCible(Coordonnee c)
	{
		throw new System.NotImplementedException();
	}

}

