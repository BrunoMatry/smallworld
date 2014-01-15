using System;
using System.Collections.Generic;
using System.Text;

public class UniteMorteException : PartieException {

	private string _message;
	private string _type;
	private int _umorte;
	private int _j;

	// Propriétés (en lecture seule)
	public int UniteMorte { get { return this._umorte; } }
	public int JoueurPerdant { get { return this._j; } }
	public override string Message { get { return this._message; } }
	public string TypeException { get { return this._type; } }

	// Constructeur
	public UniteMorteException(string m, int u, int j) : base(m) {
		this._message = "L'unite " + u + " du joueur " + j + " est morte. " + m;
		this._type = "Unite morte";
		this._umorte = u;
		this._j = j;
	}
}