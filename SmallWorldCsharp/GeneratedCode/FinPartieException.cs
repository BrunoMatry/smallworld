using System;
using System.Collections.Generic;
using System.Text;

class FinPartieException : PartieException
{

	private string _message;
	private string _type;

	// Propriétés (en lecture seule)
	public override string Message { get { return this._message; } }
	public string TypeException { get { return this._type; } }

	// Constructeur
	public FinPartieException(string m) : base(m) {
		this._message = "La partie est terminee : " + m;
		this._type = "Fin de partie";
	}
}

