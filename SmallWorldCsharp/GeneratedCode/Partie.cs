using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;


public class Partie : IPartie {

	private string _nomPartie;
	private ICarte _carte;
	private IUnite _uniteCourante;
	private List<Tuple<int, IJoueur>> _joueurs;
	private int _toursRestants, _nbJoueursRestants, _joueurCourant, _cptTourJoueurs;
	private static int NBMAXJOUEURS;
	
	// Propriétés
    public int Hauteur { get { return this._carte.Hauteur; } }
    public int Largeur { get { return this._carte.Largeur; } }
	public IUnite UniteCourante { get { return this._uniteCourante; } }
	public TypeCase[,] Grille { get { return this._carte.Grille; } }
	public Dictionary<Coordonnee, List<IUnite>> GrilleUnites { get { return this._carte.GrilleUnites; } }
	public List<Tuple<int, IJoueur>> Joueurs { get { return this._joueurs; } }

	/**
	 * Constructeur de la classe Partie
	 * nomPartie Le nom de la partie
	 * c La carte associee a la partie
	 * joueurs Les joueurs deja initialises associes a leurs numeros respectifs
	 * nbTours Le nombre de tour a realiser ou restant a la partie
	 * joueurCourant Le joueur courant
	 */
    public Partie(string nomPartie, ICarte c, List<Tuple<int, IJoueur>> joueurs, int nbTours) {
        this._carte = c;
        this._joueurs = joueurs;
        this._toursRestants = nbTours;        
        this._nomPartie = nomPartie;

		// Selection de la premiere unite courante
		this._uniteCourante = this._joueurs[0].Item2.Peuple.Unites[0];

		// Mise a zero du compteur de joueurs
		this._cptTourJoueurs = 0;

        // Calcul des points de joueurs
		this.recalculerPoints();
		NBMAXJOUEURS = joueurs.Count;
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
        // On séléctionne la meilleure unité en défense
        IUnite meilleurDef = null;
        int def = -1;
        foreach (IUnite u in ciblee) {
            if (u.Defense > def)
                def = u.Defense;
			meilleurDef = u;
        }
        
		if (this._uniteCourante.Attaquer(meilleurDef)) { // S'il y a victoire
			// On verifie si l'unite cible est morte
			if (meilleurDef.PointsDeVie <= 0) {
					_joueurs[meilleurDef.Joueur].Item2.Peuple.TuerUnite(meilleurDef);
					this._carte.GrilleUnites[cible].Remove(meilleurDef);
					ciblee.Remove(meilleurDef);
            }
			// S'il n'y a plus d'unites présentes sur la carte cible on effectue un déplacement
			if (ciblee.Count <= 0)
                this._uniteCourante.Deplacer(cible, this._carte.GetTypeCase(courante));
        } else { // S'il y a defaite
			// On verifie si l'unite courante est morte
			if (this._uniteCourante.PointsDeVie <= 0) {
				this._joueurs[0].Item2.Peuple.TuerUnite(this._uniteCourante);
				this._carte.GrilleUnites[courante].Remove(this._uniteCourante);
				if(this._joueurs[0].Item2.EnJeu)
					this._uniteCourante = this._joueurs[0].Item2.Peuple.Unites[0];
			}
		}
		if(!_joueurs[meilleurDef.Joueur].Item2.EnJeu) {
			Tuple<int, IJoueur> t = this._joueurs.Find(x => x.Item1 == meilleurDef.Joueur);
			if(t == null)
				throw new Exception("Erreur element non trouve");
			this._joueurs.Remove(t);
			this._nbJoueursRestants--;
			throw new PartieException("Le joueur " + meilleurDef.Joueur + " a perdu !");
		} else if(!_joueurs[0].Item2.EnJeu) {
			Tuple<int, IJoueur> t = this._joueurs[0];
			this._joueurs.Remove(t);
			this._nbJoueursRestants--;
			this.changerJoueur();
			throw new PartieException("Le joueur " + this._joueurs[0].Item1 + " a perdu !");
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
		IPeuple p = this._joueurs[0].Item2.Peuple;
		int id = p.Unites.IndexOf(this._uniteCourante);

        // Correspond à la place de l'unite courante dans la list Unites du peuple courant (numéroté de 0 à n-1)
        if (id < p.NombreUnites - 1) 
            this._uniteCourante = p.Unites[id + 1];
        else
			this._uniteCourante = p.Unites[0];
	}

	
	public void Enregistrer() {
		this.EnregistrerSous(this._nomPartie + ".xml");
	}

	
	public void EnregistrerSous(string fileName) {
		//TODO
		XmlSerializer xs = new XmlSerializer(typeof(Unite));
		using (StreamWriter wr = new StreamWriter(fileName)) {

			xs.Serialize(wr, new UniteGaulois(1, new Coordonnee(2, 2)));
		} 
		// throw new System.NotImplementedException();
	}

	public void PasserTourJoueur() { changerJoueur(); }
	public void Selectionner(IUnite unite) { this._uniteCourante = unite; }

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

		Tuple<int, IJoueur> t = this._joueurs[0];
		// Suppression du joueur courant (t) de la file
		this._joueurs.Remove(t);
		// Ajout de l'ancien joueur courant en fin de file
		this._joueurs.Add(t);
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
		foreach (Tuple<int, IJoueur> t in this._joueurs)
			t.Item2.MAJPoints();
	}

	/**
	 * Mise a jour de la grille d'unites
	 */
	private void miseAJourCarte() {
		Dictionary<Coordonnee, List<IUnite>> res = new Dictionary<Coordonnee, List<IUnite>>();
		foreach (Tuple<int, IJoueur> t in this._joueurs)	{
			foreach (Unite u in t.Item2.Peuple.Unites) {
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
			if(u.Joueur != this._joueurs[0].Item1)
				res.Add(u);
		}
		return res;
	}
}