using System;

public class Joueur : IJoueur
{
	private int _id;
	private static int NOMBREJOUEUR = 0;
	private IPeuple _peuple;

	// Propriétés
	public int Id { get { return this._id; } }
	public Boolean EnJeu { get { return (this._peuple.NombreUnites <= 0); } }
	public IPeuple Peuple { get {return this._peuple; } set { this._peuple = value; } }

	/**
	 * Constructeur de la classe Joueur
	 * t Le type du peuple
	 * nb Le nombre d'unites a creer
	 * c La coordonnee a laquelle seront placees les unites au depart
	 * /!\ Cette case ne doit pas contenir d'unites enemies
	 */
	public Joueur(TypePeuple t, int nb, Coordonnee c) {
		this._id = NOMBREJOUEUR++;
		this._peuple = new Peuple(t, nb, this._id, c);
	}
}

