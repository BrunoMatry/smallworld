using System;
using System.Collections.Generic;
using System.Text;

class PartieException : Exception {

    private string _message;
	private string _type;
 
    // Propriétés (en lecture seule)
	public override string Message { get { return this._message; } }
	public string Type { get { return this._type; } }
 
    // Constructeur
	public PartieException(string m) : base(m) {
        this._message = m;
		this._type = "Smallworld";
    }

	public PartieException(string m, string t) : base(m) {
		this._message = m;
		this._type = t;
	}
}
