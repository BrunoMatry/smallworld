using System;

public class Joueur : IJoueur
{
	private int _id;
	private static int NOMBREJOUEUR = 0;
	private IPeuple _peuple;

	public Joueur(TypePeuple t, int nbUnites) {
		this._id = NOMBREJOUEUR++;
		this._peuple = new Peuple(t, nbUnites);
	}

	public int GetId() { return this._id; }
	public IPeuple GetPeuple() { return this._peuple; }
	public Boolean EnJeu() { return (this._peuple.GetNombreUnites() <= 0); }
}

