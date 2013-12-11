using System;
using System.Collections.Generic;
using System.Linq;


public class Partie : IPartie
{
	private ICarte _carte;
	private Dictionary<int, IJoueur> _joueurs;
	private int _toursRestants;
	private IUnite _uniteCourante;
	private List<int> _pointsJoueurs;
	private int _joueurCourant;
    private string _nomPartie;
    private List<TypePeuple> tp;
    private ICarte c;

    public Partie(string nomPartie, 
                    List<TypePeuple> tp, 
                    ICarte c, 
                    Dictionary<int, IJoueur> joueurs, 
                    int nbTours,
                    int joueurCourant) {
        this.c = c;
        this._joueurs = joueurs;
        this._toursRestants = nbTours;        
        this._joueurCourant = joueurCourant;
        this._nomPartie = nomPartie;
        this.tp = tp;

        // TODO: Unite courante + calculer points joueurs
    }

	public virtual List<IUnite> GetUnites() {

        List<IUnite> l = new List<IUnite>();
        foreach (KeyValuePair<int, IJoueur> j in this._joueurs) {
            l.Concat(j.Value.GetPeuple().GetUnites());
        }
        return l;
	}

    public virtual IUnite GetUniteCourante() {
        return this._uniteCourante;
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

	

	public virtual bool NouveauTour()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<Coordonnee> GetDirectionsAutorisees(Coordonnee c)
	{
		throw new System.NotImplementedException();
	}

	public virtual TypeCase[,] GetGrille()
	{
        return this._carte.GetGrille();
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
        return this._pointsJoueurs;
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

