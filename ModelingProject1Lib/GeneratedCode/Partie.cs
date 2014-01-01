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
	public Dictionary<Coordonnee, List<IUnite>> GrilleUnites { get { return this._carte.GrilleUnites; } }

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
		this.miseAJourCarte();
    }

	

	public void Attaque(Direction dir) {
		// Verification de la validite du deplacement
		this.mouvement(dir);

        Coordonnee courante = _uniteCourante.Coordonnees;
        Coordonnee cible = courante + dir;
        List<IUnite> ciblee = unitesEnemiesSurCase(cible);
        // On vérifie que la liste ciblee n'est pas vide:
        if (ciblee.Count <= 0)
            throw new PartieException("Aucune unite cible sur la case séléctionnee");
        // On séléctionne la meilleure unité en défence
        IUnite meilleurDef = null;
        int def = -1;
        foreach (IUnite u in ciblee) {
            if (u.Defense > def)
                def = u.Defense;
			meilleurDef = u;
        }
       
        /* A BRUNO : Peut etre faudra t il modifier la méthode attaquer de sorte à ce qu'elle prenne l'adresse de l'unité cible 
        afin de pouvoir en modifier les propriétés (points de vie ...) Qu'en penses tu ?
         * Apparemment visual studio n'aime pas trop les pointeurs avec les types managés ... A voir comment on peut gérer sa ...
         * Parce que j'ai peur que l'en prenant BestDef qui n'est qu'une copie de l'unité cible, l'unité cible ne soit jamais touché
		 * -> Je vois ce que tu veux dire, ce sera effectivement a surveiller
		 * -> J'ai cree un objet qui contiendra une association entre une coordonne et 
		 */
        
		if (this._uniteCourante.Attaquer(meilleurDef)) { // S'il y a victoire
        // On vérifie si l'unité cible est morte
            IJoueur j;
			if (meilleurDef.PointsDeVie == 0)
				if (_joueurs.TryGetValue(meilleurDef.Joueur, out j))
                {
					j.Peuple.TuerUnite(meilleurDef);
					ciblee.Remove(meilleurDef);
                }
        // Si il n'y a plus d'unites présentes sur la carte cible on effectue un déplacement
			if (ciblee == null || ciblee.Count <= 0)
                this._uniteCourante.Deplacer(cible, this._carte.GetTypeCase(courante));
        }
       
	}

	public void Deplacement(Direction dir) {
		// Verification de la validite du deplacement
		this.mouvement(dir);

        Coordonnee courante = this._uniteCourante.Coordonnees;
        Coordonnee cible = courante + dir;
        // On vérifie qu'il n'y a pas d'unite sur la case cible
		if (!this.unitesEnemiesSurCase(cible).Any()) {
			// On appelle la methode deplacer de l'unite courante
            this._uniteCourante.Deplacer(cible, this._carte.GetTypeCase(courante));
			// On retire l'unite de son ancien emplacement sur la grille
			this._carte.GrilleUnites[courante].Remove(this._uniteCourante);
			// S'il n'yavait jamais eu d'unite sur cette case
			if (this._carte.GrilleUnites[cible] == null)
				// Initialisation de la liste d'unite associee aux coordonnees "cible"
				this._carte.GrilleUnites[cible] = new List<IUnite>();
			// On ajoute l'unite courante a sa nouvelle place
			this._carte.GrilleUnites[cible].Add(this._uniteCourante);
		} else {
			throw new PartieException("Il y a des unites enemies sur la case cible", "Case cible occupee");
		}
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
	 * Methode permettant la verification de la validite du deplacement dans une direction donnee
	 * /!\ ne verifie pas la presence d'unites enemies dans la case cible
	 */
	private void mouvement(Direction dir) {
		// On vérifie que une unité est bien séléctionné
		if (this._uniteCourante == null)
			throw new PartieException("Aucune unité n'a été séléctionné");
		// On vérifie les points de déplacements
		if (this._uniteCourante.PointsDeplacement < 1)
			throw new PartieException("Points de déplacement insuffisant");
		// On vérifie que la direction indiquée appartient bien à la liste des directions autorisées
		List<Direction> dirAutorisees = this._carte.GetDirectionsAutorisees(_uniteCourante.Coordonnees);
		if (!(dirAutorisees.Contains(dir)))
			throw new PartieException("Directions non autorisées");
	}

	/**
	 * Methode permettant le recalcul automatique des points de l'ensemble des joueurs
	 */
	private void recalculerPoints() {
		foreach(KeyValuePair<int, IJoueur> j in this._joueurs) {
			int points = 0;
			foreach(IUnite u in j.Value.Peuple.Unites) {
				points += u.Valeur;
			}
			this._pointsJoueurs[j.Key] = points;
		}
	}

	/**
	 * Mise a jour de la grille d'unites
	 */
	private void miseAJourCarte() {
		Dictionary<Coordonnee, List<IUnite>> res = new Dictionary<Coordonnee, List<IUnite>>();
		foreach (KeyValuePair<int, IJoueur> j in this._joueurs)	{
			foreach (Unite u in j.Value.Peuple.Unites) {
				if(res.ContainsKey(u.Coordonnees)) {
					res[u.Coordonnees].Add(u);
				} else {
					List<IUnite> l = new List<IUnite>();
					l.Add(u);
					res.Add(u.Coordonnees, l);
				}			
			}
		}
		this._carte.GrilleUnites = res;
	}

	private List<IUnite> unitesEnemiesSurCase(Coordonnee c) {
		List<IUnite> res = new List<IUnite>();
		foreach(IUnite u in this._carte.GrilleUnites[c]) {
			if(u.Joueur != this._joueurCourant)
				res.Add(u);
		}
		return res;
	}
}