using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Unite : IUnite
{
    protected virtual int _attaque;
    protected virtual int _defense;
    protected virtual int _pointsDeVie;
    protected virtual int _pointsDeplacement;
    protected virtual Coordonnee _coordonnee;
    protected virtual int _valeur;
    protected virtual int _joueur;

	public abstract void nouveauTour(TypeCase caseActuelle);

	public virtual void Deplacer(Coordonnee caseCible, TypeCase caseActuelle) {
		// On aura verifie au prealable la validite de la case cible
		this._coordonnee = caseCible;
	}

	public virtual Boolean Attaquer(IUnite uniteCible) {
        // Realiser les calculs d'attaque
		throw new System.NotImplementedException();
	}


	public int GetAttaque() { return this._attaque; }
    public Coordonnee GetCoordonnees() { return this._coordonnee; }
	public int GetDefense() { return this._defense; }
	public int GetValeur() { return this._valeur; }
	public int GetPointsDeVie() { return this._pointsDeVie; }
	public int GetIdJoueur() { return this._joueur; }
	public int GetPointDeplacement() { return this._pointsDeplacement; }
}

