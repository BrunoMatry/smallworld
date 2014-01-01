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

	/* Accesseurs */
	public int GetAttaque() { return this._attaque; }
	public Coordonnee GetCoordonnees() { return this._coordonnee; }
	public int GetDefense() { return this._defense; }
	public int GetValeur() { return this._valeur; }
	public int GetPointsDeVie() { return this._pointsDeVie; }
	public int GetIdJoueur() { return this._joueur; }
	public int GetPointDeplacement() { return this._pointsDeplacement; }
}

