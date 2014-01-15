using System;
using System.Collections.Generic;
using System.Text;

public class UniteGagnanteException : PartieException {

	private string _message;
	private string _type;

	// Propriétés (en lecture seule)
	public override string Message { get { return this._message; } }
	public string TypeException { get { return this._type; } }

	// Constructeur
	public UniteGagnanteException(string m, int j1, int j2) : base(m) {
		this._message = "L'unite du joueur " + j1 + " a battue celle du joueur " + j2 + " ! " + m;
		this._type = "Resultat du combat";
	}
}