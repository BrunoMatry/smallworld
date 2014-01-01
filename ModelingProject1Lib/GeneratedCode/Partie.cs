using System;
using System.Collections.Generic;
using System.Linq;


public class Partie : IPartie {

	private ICarte _carte;
	private Dictionary<int, IJoueur> _joueurs;
	private int _toursRestants;
	private IUnite _uniteCourante;
	private List<int> _pointsJoueurs;
	// A quoi ca correspond ?
	// -> a eviter de recalculer a chaque fois la somme des points des joueurs de chaque adversaire
	private int _nbJoueursRestants;
	private int _joueurCourant;
    private string _nomPartie;

	// Propriétés
	public IUnite UniteCourante { get { return this._uniteCourante; } }
	public TypeCase[,] Grille { get { return this._carte.GetGrille(); } }
	public List<int> PointsJoueurs { get { return this._pointsJoueurs; } }

	/**
	 * Constructeur de la classe Partie
	 * nomPartie Le nom de la partie
	 * c La carte associee a la partie
	 * joueurs Les joueurs deja initialises associes a leurs numeros respectifs
	 * nbTours Le nombre de tour a realiser ou restant a la partie
	 * joueurCourant Le joueur courant
	 */
    public Partie(string nomPartie, ICarte c, Dictionary<int, IJoueur> joueurs, int nbTours, int joueurCourant) {
        this._carte = c;
        this._joueurs = joueurs;
        this._toursRestants = nbTours;        
        this._joueurCourant = joueurCourant;
        this._nomPartie = nomPartie;

		// Selection de la premiere unite courante
		this._uniteCourante = this._joueurs[this._joueurCourant].Peuple.Unites[0];

        // Calcul des points de joueurs
		this.recalculerPoints();
		this._nbJoueursRestants = joueurs.Count;
    }

	public Dictionary<Coordonnee, IUnite> GetUnitesGrille() {
		Dictionary<Coordonnee, IUnite> res = new Dictionary<Coordonnee, IUnite>();
		foreach (KeyValuePair<int, IJoueur> j in this._joueurs) {
			foreach (Unite u in j.Value.Peuple.Unites) {
				res.Add(u.GetCoordonnees(), u);
			}
		}
        return res;
	}

	public virtual void Attaque(Direction dir) {
        //On vérifie que une unité est bien séléctionné
        if (this._uniteCourante == null)
            throw new PartieException("Aucune unité n'a été séléctionné", "Selection d'unité");

        //On vérifie les points de déplacements
        if (this._uniteCourante.GetPointDeplacement() < 1)
            throw new PartieException("Points de déplacement insuffisants", "Deplacement invalide");

        //On vérifie que la case ciblee appartient bien à la liste des cases autorisées
        List<Direction> dirAutorisees = this._carte.GetDirectionsAutorisees(_uniteCourante.GetCoordonnees());
        if (!(dirAutorisees.Contains(dir)))
			throw new PartieException("Deplacement non autorisé", "Deplacement invalide");
        Coordonnee courante = _uniteCourante.GetCoordonnees();
        Coordonnee cible = courante + dir;
        List<IUnite> ciblee = getUnitesCible(cible);
        // On vérifie que la liste ciblee n'est pas vide:
        if (!(ciblee.Any()))
            throw new PartieException("Aucune unité cible sur la case séléctionnée");
        // On séléctionne la meilleure unité en défence
        Unite BestDef = null;
        int def = 0;
        foreach (Unite u in ciblee) {
            if (u.GetDefense() > def)
                def = u.GetDefense();
                BestDef = u;
        }
       
        /* A BRUNO : Peut etre faudra t il modifier la méthode attaquer de sorte à ce qu'elle prenne l'adresse de l'unité cible 
        afin de pouvoir en modifier les propriétés (points de vie ...) Qu'en penses tu ?
         * Apparemment visual studio n'aime pas trop les pointeurs avec les types managés ... A voir comment on peut gérer sa ...
         * Parce que j'ai peur que l'en prenant BestDef qui n'est qu'une copie de l'unité cible, l'unité cible ne soit jamais touché*/
        // Si il y a victoire
        if (this._uniteCourante.Attaquer(BestDef))
        {
        // On vérifie si l'unité cible est morte
            IJoueur j;
            if (BestDef.GetPointsDeVie() == 0)
                if (_joueurs.TryGetValue(BestDef.GetIdJoueur(), out j))
                {
                j.Peuple.TuerUnite(BestDef);
                ciblee.Remove(BestDef);
                }
        // Si il n'y a plus d'unites présentes sur la carte cible on effectue un déplacement
            if (!(ciblee.Any()))
                this._uniteCourante.Deplacer(cible, this._carte.GetTypeCase(courante));
        }
       
	}

	public virtual void Deplacement(Direction dir)
	{
		// On vérifie que une unité est bien séléctionné
        if (this._uniteCourante == null)
            throw new PartieException("Aucune unité n'a été séléctionné");
        // On vérifie les points de déplacements
        if (this._uniteCourante.GetPointDeplacement() < 1)
			throw new PartieException("Points de déplacement insuffisant !");
        // TODO On vérifie que la direction indiquée appartient bien à la liste des directions autorisées
        List<Direction> dirAutorisees = this._carte.GetDirectionsAutorisees(_uniteCourante.GetCoordonnees());
        if (!(dirAutorisees.Contains(dir)))
			throw new PartieException("Directions non autorisées !");
        Coordonnee courante = _uniteCourante.GetCoordonnees();
        Coordonnee cible = courante + dir;
        List<IUnite> ciblee = getUnitesCible(cible);
        // On vérifie qu'il n'y a pas d'unite sur la case cible:
        if (!(ciblee.Any()))
            this._uniteCourante.Deplacer(cible, this._carte.GetTypeCase(courante));

	}

	public void PasserTourUniteCourante() {
        // On recupere le numero de l'unite courante dans les unites du joueur
		IPeuple p = this._joueurs[this._joueurCourant].Peuple;
		int id = p.Unites.IndexOf(this._uniteCourante);

        // Correspond à la place de l'unite courante dans la list Unites du peuple courant (numéroté de 0 à n-1)
        if (id < p.NombreUnites - 1) 
            this._uniteCourante = p.Unites[id + 1];
        else
			this._uniteCourante = p.Unites[0];
	}

	//TODO
	public void Enregistrer() { throw new System.NotImplementedException(); }
	//TODO
	public void EnregistrerSous(string s) {	throw new System.NotImplementedException(); }

	public void PasserTourJoueur() { changerJoueur(); }
	public void Selectionner(IUnite unite) { this._uniteCourante = unite; }

	/**
	 * Methode permettant de changer de joueur et de recompter les points
	 */
	private void changerJoueur()
	{
		this.recalculerPoints();
		if (_toursRestants > 0)
			throw new PartieException("La partie est terminé, il ne reste plus de tours à jouer", "Fin de partie");
		
		// TODO changement de joueur sans decrementer les tours restants
		_joueurCourant = (_joueurCourant + 1) % 2;
		_toursRestants--;
	}

	/**
	 * Methode permettant d'obtenir les unites adverses sur la case de coordonnees c
	 */
	private List<IUnite> getUnitesCible(Coordonnee c) {
		List<IUnite> l = new List<IUnite>();
        foreach (KeyValuePair<int, IJoueur> j in this._joueurs) {
            if (j.Key != _joueurCourant) {
                foreach (Unite u in j.Value.Peuple.Unites) {
                    if (u.GetCoordonnees() == c)
                        l.Add(u);
                }
            }

        }
        return l;
	}

	/**
	 * Methode permettant le recalcul automatique des points de l'ensemble des joueurs
	 */
	private void recalculerPoints() {
		foreach(KeyValuePair<int, IJoueur> j in this._joueurs) {
			int points = 0;
			foreach(IUnite u in j.Value.Peuple.Unites) {
				points += u.GetValeur();
			}
			this._pointsJoueurs[j.Key] = points;
		}
	}
}