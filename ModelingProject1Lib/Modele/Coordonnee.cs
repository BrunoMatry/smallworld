using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Coordonnee
{
	private int _x;
    private int _y;

    public int GetX() {
        return _x;
    }

    public int GetY() {
        return _y;
    }

	public Coordonnee(int x, int y) {
        _x = x;
        _y = y;
	}

	public bool Equal(Coordonnee c) {
        return (c.GetX() == _x) && (c.GetY() == _y);
	}
}

