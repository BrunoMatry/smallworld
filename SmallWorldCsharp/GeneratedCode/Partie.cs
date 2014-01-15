using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

[Serializable]
public class Partie : IPartie {

	private string _nomPartie;	
	private Unite _uniteCourante;
	private List<Joueur> _joueurs;
	private Carte _carte;
	private int _toursRestants, _nbJoueursRestants, _cptTourJoueurs;
	private static int NBMAXJOUEURS;
	
	// Propriétés
	public string Nom { get { return this._nomPartie; } set { this._nomPartie = value; } }
	public int Tr { get { return this._toursRestants; } set { this._toursRestants = value; } }
	public int Nbjr { get { return this._nbJoueursRestants; } set { this._nbJoueursRestants = value; } }
	public int Ctj { get { return this._cptTourJoueurs; } set { this._cptTourJoueurs = value; } }
	public Unite UniteCourante { get { return this._uniteCourante; } set { this._uniteCourante = value; } }
	public List<Joueur> Joueurs { get { return this._joueurs; } set { this._joueurs = value; } }
	public Carte Carte { get { return this._carte; } set { this._carte = value; } }
	
	
	public int Hauteur { get { return this._carte.Hauteur; } }
    public int Largeur { get { return this._carte.Largeur; } }
	public TypeCase[][] Grille { get { return this._carte.Grille; } }
	[XmlIgnoreAttribute]
	public Dictionary<Coordonnee, List<Unite>> GrilleUnites { get { return this._carte.GrilleUnites; } }
	
	

	// Constructeur par defaut pour serialisation
	public Partie() {}

	/**
	 * Constructeur de la classe Partie
	 * nomPartie Le nom de la partie
	 * c La carte associee a la partie
	 * joueurs Les joueurs deja initialises associes a leurs numeros respectifs
	 * nbTours Le nombre de tour a realiser ou restant a la partie
	 * joueurCourant Le joueur courant
	 */
    public Partie(string nomPartie, Carte c, List<Joueur> joueurs, int nbTours) {
        this._carte = c;
        this._joueurs = joueurs;
        this._toursRestants = nbTours;        
        this._nomPartie = nomPartie;

		// Selection de la premiere unite courante
		this._uniteCourante = this._joueurs[0].Peuple.Unites[0];

		// Mise a zero du compteur de joueurs
		this._cptTourJoueurs = 0;

        // Calcul des points de joueurs
		this.recalculerPoints();
		NBMAXJOUEURS = joueurs.Count;
		this._nbJoueursRestants = joueurs.Count;
		this.initUnites();
		this._carte.GrilleUnites = new Dictionary<Coordonnee,List<Unite>>();
		this.miseAJourGilleUnite();
		this.recalculerPoints();
    }

	

	public void Attaque(Direction dir) {
		// Verification de la validite du deplacement
		this.mouvementValide(dir);

        Coordonnee courante = this._uniteCourante.Coordonnees;
        Coordonnee cible = courante + dir;
        List<Unite> ciblee = unitesEnemiesSurCase(cible);
        // On vérifie que la liste ciblee n'est pas vide:
        if (ciblee.Count <= 0)
            throw new PartieException("Aucune unite cible sur la case séléctionnee");
        // On séléctionne la meilleure unité en défense
        Unite meilleurDef = null;
        int def = -1;
        foreach (Unite u in ciblee) {
            if (u.Defense > def)
                def = u.Defense;
			meilleurDef = u;
        }
		Joueur defenseur = trouverJoueur(meilleurDef.Joueur);
        try {
			if (this._uniteCourante.Attaquer(meilleurDef)) { // S'il y a victoire
				// On verifie si l'unite cible est morte
				if (meilleurDef.PointsDeVie <= 0) {
					defenseur.Peuple.TuerUnite(meilleurDef);
					this._carte.GrilleUnites[cible].Remove(meilleurDef);
					ciblee.Remove(meilleurDef);
				}
				// S'il n'y a plus d'unites présentes sur la carte cible on effectue un déplacement
				if (ciblee.Count <= 0)
					this._uniteCourante.Deplacer(cible, this._carte.GetTypeCase(courante));

				throw new UniteGagnanteException("", this._joueurs[0].Id, defenseur.Id);
			}
			else { // S'il y a defaite
				// On verifie si l'unite courante est morte
				if (this._uniteCourante.PointsDeVie <= 0) {
					this._joueurs[0].Peuple.TuerUnite(this._uniteCourante);
					this._carte.GrilleUnites[courante].Remove(this._uniteCourante);
					if(this._joueurs[0].EnJeu)
						this._uniteCourante = this._joueurs[0].Peuple.Unites[0];
				}
				throw new UniteGagnanteException("", defenseur.Id, this._joueurs[0].Id);
			}
		} catch (UniteGagnanteException uge) {
			throw uge;
		} finally {
			if (!defenseur.EnJeu) {
				this._joueurs.Remove(defenseur);
				this._nbJoueursRestants--;
				throw new PartieException("Le joueur " + defenseur.Id + " a perdu !");
			} else if(!_joueurs[0].EnJeu) {
				this._joueurs.Remove(this._joueurs[0]);
				this._nbJoueursRestants--;
				this.changerJoueur();
				throw new PartieException("Le joueur " + this._joueurs[0].Id + " a perdu !");
		}
		}
	}

	public void Deplacement(Direction dir) {
		// Verification de la validite du deplacement
		this.mouvementValide(dir);

        Coordonnee courante = this._uniteCourante.Coordonnees;
        Coordonnee cible = courante + dir;
        // On vérifie qu'il n'y a pas d'unite sur la case cible
		if (!this.unitesEnemiesSurCase(cible).Any()) {
			// On appelle la methode deplacer de l'unite courante
            this._uniteCourante.Deplacer(cible, this._carte.GetTypeCase(courante));
			// On retire l'unite de son ancien emplacement sur la grille
			this._carte.GrilleUnites[courante].Remove(this._uniteCourante);
			// S'il n'yavait jamais eu d'unite sur cette case
			if (!this._carte.GrilleUnites.ContainsKey(cible))
				// Initialisation de la liste d'unite associee aux coordonnees "cible"
				this._carte.GrilleUnites[cible] = new List<Unite>();
			// On ajoute l'unite courante a sa nouvelle place
			this._carte.GrilleUnites[cible].Add(this._uniteCourante);
		} else {
			throw new PartieException("Il y a des unités ennemies sur la case cible\n Souhaitez vous attaquer ?", "attaque");
		}
	}
   
	public void PasserTourUniteCourante() {
        // On recupere le numero de l'unite courante dans les unites du joueur
		IPeuple p = this._joueurs[0].Peuple;
		int id = p.Unites.IndexOf(this._uniteCourante);

        // Correspond à la place de l'unite courante dans la list Unites du peuple courant (numéroté de 0 à n-1)
        if (id < p.NombreUnites - 1) 
            this._uniteCourante = p.Unites[id + 1];
        else
			this._uniteCourante = p.Unites[0];
	}

	
	public void Enregistrer() {
		this.EnregistrerSous(this._nomPartie + ".sav");
	}

	
	public void EnregistrerSous(string fileName) {

		XmlSerializer serializer = new XmlSerializer(this.GetType());
		using (StreamWriter writer = new StreamWriter(fileName)) {
			serializer.Serialize(writer, this);
		}
		// Penser a recharger les cases de la carte demo
		// Penser a recharger la grilleUnite
	}

	public void PasserTourJoueur() { changerJoueur();
    initUnites();
    }
	public void Selectionner(Unite unite) { this._uniteCourante = unite; }

	/**
	 * Methode permettant de changer de joueur et de recompter les points
	 */
	private void changerJoueur() {

		// Recomptage des points des joueurs
		this.recalculerPoints();

		// Cas fin de partie par manque de tours
		if (this._toursRestants <= 0)
			throw new FinPartieException("il ne reste plus de tours à jouer");

		this._cptTourJoueurs++;

		// Cas fin de boucle
		if(this._cptTourJoueurs >= this._nbJoueursRestants) { 
			this._cptTourJoueurs = 0;
			this._toursRestants--;
		}

		Joueur j = this._joueurs[0];
		// Suppression du joueur courant (t) de la file
		this._joueurs.Remove(j);
		// Ajout de l'ancien joueur courant en fin de file
		this._joueurs.Add(j);
		// Mise a jour de l'unite courante
		this._uniteCourante = this.Joueurs[0].Peuple.Unites[0];
	}

	/**
	 * Methode permettant la verification de la validite du deplacement dans une direction donnee
	 * /!\ ne verifie pas la presence d'unites enemies dans la case cible
	 */
	private void mouvementValide(Direction dir) {
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
		foreach (Joueur j in this._joueurs)
			j.MAJPoints();
	}

	/**
	 * Mise a jour de la grille d'unites
	 */
	private void miseAJourGilleUnite() {
		this._carte.GrilleUnites.Clear();
		this.initGilleUnite();
		foreach (Joueur j in this._joueurs) {
			foreach (Unite u in j.Peuple.Unites) {
				this._carte.GrilleUnites[u.Coordonnees].Add(u);		
			}
		}
	}

	private List<Unite> unitesEnemiesSurCase(Coordonnee c) {
		List<Unite> res = new List<Unite>();
		foreach(Unite u in this._carte.GrilleUnites[c]) {
			if(u.Joueur != this._joueurs[0].Id)
				res.Add(u);
		}
		return res;
	}

	private void initUnites() {
		foreach(Joueur j in this._joueurs) {
			foreach (Unite u in j.Peuple.Unites) {
				u.NouveauTour(this._carte.GetTypeCase(u.Coordonnees));
			}
		}
	}

	private void initGilleUnite() {
		Dictionary<Coordonnee, List<Unite>> res = new Dictionary<Coordonnee, List<Unite>>();
		int lg = this._carte.Largeur;
		int ht = this._carte.Hauteur;
		for(int i = 0 ; i < lg ; i++) {
			for(int j = 0 ; j < ht ; j++) {
				res.Add(new Coordonnee(i, j), new List<Unite>());
			}
		}
		this._carte.GrilleUnites = res;
	}

	private Joueur trouverJoueur(int p) {
		foreach(Joueur j in this._joueurs) {
			if(j.Id == p)
				return j;
		}
		throw new Exception("Joueur non trouve");
	}
}