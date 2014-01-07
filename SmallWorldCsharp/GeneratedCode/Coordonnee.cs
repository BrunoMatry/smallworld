public class Coordonnee
{
    private int _x;
    private int _y;

	// Propriétés (en lecture seule)
	public int X { get { return this._x; } set { this._x = value; } }
	public int Y { get { return this._y; } set { this._y = value; } }

	public Coordonnee() {
		// Constructeur par defaut pour la serialisation
	}

	public Coordonnee(int x, int y) {
        this._x = x;
        this._y = y;
	}

    public static bool operator ==(Coordonnee c1, Coordonnee c2) {
        return c1._x == c2._x && c1._y == c2._y;
    }

	public static bool operator !=(Coordonnee c1, Coordonnee c2) {
		return c1._x != c2._x || c1._y != c2._y;
	}

    public static Coordonnee operator +(Coordonnee c1, Coordonnee c2) {
        return new Coordonnee((c1._x + c2._x), (c1._y + c2._y));
    }

    public static Coordonnee operator -(Coordonnee c1, Coordonnee c2) {
        return new Coordonnee((c1._x - c2._x), (c1._y - c2._y));
    }
    public static Coordonnee operator +(Coordonnee c1, Direction dir) {
        switch (dir) {
			case Direction.NORD: return new Coordonnee(c1._x, c1._y + 1);
            case Direction.SUD: return new Coordonnee(c1._x, c1._y - 1);
			case Direction.EST: return new Coordonnee(c1._x + 1, c1._y);
            case Direction.OUEST: return new Coordonnee(c1._x - 1, c1._y);
            default: return c1;
        }
    }

	public override bool Equals(object o) {
       if (o == null)
            return false;
       Coordonnee c = o as Coordonnee;
	   return this._x == c.X && this._y == c.Y;
	}

	public override int GetHashCode() {	
		return _x.GetHashCode() ^ _y.GetHashCode();
	}
}