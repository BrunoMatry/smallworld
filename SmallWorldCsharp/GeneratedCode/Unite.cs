using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlInclude(typeof(UniteGaulois))]
[XmlInclude(typeof(UniteNain))]
[XmlInclude(typeof(UniteViking))]
public abstract class Unite : IUnite {
	protected static int NBUNITES = 0;
    protected int _attaque;
    protected int _defense;
    protected int _pointsDeVie;
    protected int _pointsDeplacement;
    protected Coordonnee _coordonnee;
    protected int _valeur;
    protected int _joueur;
	protected int _id;

	public int Id { get { return this._id; } set { this._id = value; } }
	public int Joueur { get { return this._joueur; } set { this._joueur = value; } }
	public int Valeur { get { return this._valeur; } set { this._valeur = value; } }
	public int Attaque { get { return this._attaque; } set { this._attaque = value; } }
	public int Defense { get { return this._defense; } set { this._defense = value; } }
	public int PointsDeVie { get { return this._pointsDeVie; } set { this._pointsDeVie = value; } }
	public int PointsDeplacement { get { return this._pointsDeplacement; } set { this._pointsDeplacement = value; } }
	public Coordonnee Coordonnees { get { return this._coordonnee; } set { this._coordonnee = value; } }

	// Constructeur par defaut pour serialisation
	public Unite() {}

	public Unite(int j, Coordonnee c) {
		NBUNITES++;
		this._id = NBUNITES;
		this._joueur = j;
		this._coordonnee = c;
		this._attaque = 2;
		this._defense = 1;
		this._pointsDeVie = 2;
		this._pointsDeplacement = 0;
		this._valeur = -1;
	}

	/**
	 * Methode permettant la mise a jour des attributs de l'unite
	 * avant de commencer un nouveau tour
	 */
	public abstract void NouveauTour(TypeCase caseActuelle);

	public virtual void Deplacer(Coordonnee caseCible, TypeCase caseActuelle) {
		// On aura verifie au prealable la validite de la case cible
		this._coordonnee = caseCible;
		this._pointsDeplacement--;
	}

	public virtual Boolean Attaquer(IUnite u) {
		if(u.Defense == 0) {
			// u meurt imediatement
			u.PointsDeVie = 0;
			return true;
		}

		// Tirage d'un nombre entre 3 et le nombre de points de vie de l’unite ayant le plus de points de vie + 2 points
		int maxNbCombats = (Math.Max(this._pointsDeVie, u.PointsDeVie) + 2);
		Random random = new Random();
		int nbCombats = random.Next(3, (maxNbCombats + 1));
	
		// Calcul du rapport de force avec la formule ((((a - d) / max(a, d)) / 2) + 0.5)	
		double rapportDeForce = rapportDeForce = (((this._attaque - u.Defense) / (Math.Max(this._attaque, u.Defense) * 2)) + 0.5);

		// Le combat s’arrête lorsque ce nombre est atteint ou lorsque l’une ou autre des unités n’a plus de vie
		for (int i = 0 ; ((u.PointsDeVie == 0) || (this._pointsDeVie == 0) || (i < maxNbCombats)); i++) {		
			if(random.NextDouble() <= rapportDeForce) {
				// Victoire de l'attaquant
				u.PointsDeVie--;
			} else {
				// Defaite de l'attaquant
				this._pointsDeVie--;
			}
		}
		if(this._pointsDeVie <= 0) { return false; }
				
		return true;
	}
}

