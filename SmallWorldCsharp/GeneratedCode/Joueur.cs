using System;

[Serializable]
public class Joueur : IJoueur {

	private int _id;
	private static int NOMBREJOUEUR = 0;
	private Peuple _peuple;
    private int _points, _cptTourJoueurs;

	// Propriétés
	public int Id { get { return this._id; } set { this._id = value; } }
	public int Points { get { return this._points; } set { this._points = value; } }
	public Boolean EnJeu { get { return (this._peuple.NombreUnites > 0); } }
	public Peuple Peuple { get {return this._peuple; } set { this._peuple = value; } }
    public int Ctj { get { return this._cptTourJoueurs; } set { this._cptTourJoueurs = value; } }
	// Constructeur par defaut pour serialisation
	public Joueur() {}

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
        // Mise a zero du compteur de joueurs
        this._cptTourJoueurs = 0;
	}

	public void MAJPoints() {
		int points = 0;
		foreach (IUnite u in this._peuple.Unites)
			points += u.Valeur;
		this._points = points;
	}

	public override bool Equals(object o) {
		if (o == null)
			return false;
		Joueur j = o as Joueur;
		return this._id == j._id;
	}
}

