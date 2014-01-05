using System;
using System.Collections.Generic;

public abstract class Unite : IUnite
{
    protected int _attaque;
    protected int _defense;
    protected int _pointsDeVie;
    protected int _pointsDeplacement;
    protected Coordonnee _coordonnee;
    protected int _valeur;
    protected int _joueur;

	public int Attaque { get { return this._attaque; } }
	public Coordonnee Coordonnees { get { return this._coordonnee; } }
	public int Defense { get { return this._defense; } }
	public int Valeur { get { return this._valeur; } }
	public int PointsDeVie { get { return this._pointsDeVie; } }
	public int Joueur { get { return this._joueur; } }
	public int PointsDeplacement { get { return this._pointsDeplacement; } }

	/**
	 * Methode permettant la mise a jour des attributs de l'unite
	 * avant de commencer un nouveau tour
	 */
	public abstract void NouveauTour(TypeCase caseActuelle);

	public virtual void Deplacer(Coordonnee caseCible, TypeCase caseActuelle) {
		// On aura verifie au prealable la validite de la case cible
		this._coordonnee = caseCible;
	}

	public virtual Boolean Attaquer(IUnite uniteCible) {
        // TODO calculs d'attaque
		throw new System.NotImplementedException();
	}
}

