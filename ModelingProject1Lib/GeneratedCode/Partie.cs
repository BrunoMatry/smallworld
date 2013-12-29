using System;
using System.Collections.Generic;
using System.Linq;


public class Partie : IPartie
{
	private ICarte _carte;
	private Dictionary<int, IJoueur> _joueurs;
	private int _toursRestants;
	private IUnite _uniteCourante;
	private List<int> _pointsJoueurs; // A quoi ca correspond sachant que les joueurs n'ont pas de points mais que ce sont ses unités qui auront des points ?
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
        //On vérifie que une unité est bien séléctionné
        if (this._uniteCourante == null)
            throw new Exception("Aucune unité n'a été séléctionné");
        //On vérifie les points de déplacements
        if (this._uniteCourante.GetPointDeplacement() < 1)
            throw new Exception("Points de déplacement insuffisant !");
        //On vérifie que la direction indiquée appartient bien à la liste des directions autorisées
        List<Direction> dirAutorisees = c.GetDirectionsAutorisees(_uniteCourante.GetCoordonnees());
        if (!(dirAutorisees.Contains(dir)))
            throw new Exception("Directions non autorisées !");
        Coordonnee cible = _uniteCourante.GetCoordonnees() + dir;
        List<IUnite> ciblee = getUnitesCible(cible);
        // On vérifie que la liste ciblee n'est pas vide:
        if (!(ciblee.Any()))
            throw new Exception("Aucune unité cible sur la case séléctionnée");
        // On séléctionne la meilleure unité en défence
        Unite BestDef = null;
        int def = 0;
        foreach (Unite u in ciblee)
        {
            if (u.GetDefense() > def)
                def = u.GetDefense();
                BestDef = u;
        }
       
        /* A BRUNO : Peut etre faudra t il modifier la méthode attaquer de sorte à ce qu'elle prenne l'adresse de l'unité cible 
        afin de pouvoir en modifier les propriétés (points de vie ...) Qu'en penses tu ?
         * Aperemment visual studio n'aime pas trop les pointeurs avec les types managés ... A voir comment on peut gérer sa ...
         * Parce que j'ai peur que l'en prenant BestDef qui n'est qu'une copie de l'unité cible, l'unité cible ne soit jamais touché*/
        // Si il y a victoire
        if (this._uniteCourante.Attaquer(BestDef))
        {
        // On vérifie si l'unité cible est morte
            IJoueur j;
            if (BestDef.GetPointsDeVie() == 0)
                if (_joueurs.TryGetValue(BestDef.GetIdJoueur(), out j))
                {
                j.GetPeuple().TuerUnite(BestDef);
                ciblee.Remove(BestDef);
                }
        // Si il n'y a plus d'unites présentes sur la carte cible on effectue un déplacement
            if (!(ciblee.Any()))
                this._uniteCourante.Deplacer(cible);
        }
       
	}

	public virtual void Deplacement(Direction dir)
	{
		//On vérifie que une unité est bien séléctionné
        if (this._uniteCourante == null)
            throw new Exception("Aucune unité n'a été séléctionné");
        //On vérifie les points de déplacements
        if (this._uniteCourante.GetPointDeplacement() < 1)
            throw new Exception("Points de déplacement insuffisant !");
        //On vérifie que la direction indiquée appartient bien à la liste des directions autorisées
        List<Direction> dirAutorisees = c.GetDirectionsAutorisees(_uniteCourante.GetCoordonnees());
        if (!(dirAutorisees.Contains(dir)))
            throw new Exception("Directions non autorisées !");
        Coordonnee cible = _uniteCourante.GetCoordonnees() + dir;
        List<IUnite> ciblee = getUnitesCible(cible);
        // On vérifie qu'il n'y a pas d'unite sur la case cible:
        if (!(ciblee.Any()))
            this._uniteCourante.Deplacer(cible);

	}

	public virtual void PasserTourUniteCourante()
	{
		throw new System.NotImplementedException();
	}

	

	public virtual bool NouveauTour()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<Coordonnee> GetDirectionsAutorisees(Coordonnee c) // Ne sert à rien je crois car méthode déjà présente dans la care
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
      /*  foreach (KeyValuePair<int, IJoueur> j in this._joueurs)
        {
            this._pointsJoueurs[j.Key] = j.Value.GetPoints();
        }*/
        throw new System.NotImplementedException();
    }

	public virtual void Selectionner(IUnite unite)
	{
        this._uniteCourante = unite;
    }

	private List<IUnite> getUnitesCible(Coordonnee c)
	{
         List<IUnite> l = new List<IUnite>();
        foreach (KeyValuePair<int, IJoueur> j in this._joueurs)
        {
            if (j.Key != _joueurCourant)
            {
                foreach (Unite u in j.Value.GetPeuple().GetUnites())
                {
                    if (u.GetCoordonnees() == c)
                        l.Add(u);
                }
            }

        }
        return l;
	}

}

