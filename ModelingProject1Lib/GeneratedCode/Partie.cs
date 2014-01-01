using System;
using System.Collections.Generic;
using System.Linq;


public class Partie : IPartie {

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

        IJoueur j;
        if (_joueurs.TryGetValue(this._joueurCourant, out j))
        {
            this._uniteCourante = j.GetPeuple().GetUnites()[0];
        }


        // TODO: Unite courante (FAIT)+ calculer points joueurs (???)
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
        Coordonnee courante = _uniteCourante.GetCoordonnees();
        Coordonnee cible = courante + dir;
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
                this._uniteCourante.Deplacer(cible,c.GetTypeCase(courante));
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
        Coordonnee courante = _uniteCourante.GetCoordonnees();
        Coordonnee cible = courante + dir;
        List<IUnite> ciblee = getUnitesCible(cible);
        // On vérifie qu'il n'y a pas d'unite sur la case cible:
        if (!(ciblee.Any()))
            this._uniteCourante.Deplacer(cible,c.GetTypeCase(courante));

	}

	public virtual void PasserTourUniteCourante()
	{
        // On récupére le joueur courant du dictionnaire
        IJoueur j;
        if (_joueurs.TryGetValue(this._joueurCourant, out j))
        {
            int idUniteCourante = j.GetPeuple().GetUnites().IndexOf(this._uniteCourante); 
            // Correspond à la place de l'unite courante dans la list Unites du peuple courant (numéroté de 0 à n-1)
            if (idUniteCourante < j.GetPeuple().GetNombreUnites()-1)
            {
                this._uniteCourante = j.GetPeuple().GetUnites()[idUniteCourante +1];
            }
            else
            {
                this._uniteCourante = j.GetPeuple().GetUnites()[0];
            }
        }
	}

	

	public virtual bool NouveauTour()
	{
        if(_toursRestants > 0)
        {
            _joueurCourant = (_joueurCourant +1) % 2;
            _toursRestants--;
            return true;
	    }
            return false;
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

	public virtual void EnregistrerSous(string )
	{
		throw new System.NotImplementedException();
	}

	public virtual List<int> GetPointsJoueurs()
	{
        return this._pointsJoueurs;
	}

	public virtual void PasserTourJoueur()
	{
        NouveauTour();
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

