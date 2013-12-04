public class Coordonnee
{
    private int _x;
    private int _y;

	public Coordonnee(int x, int y) {
        this._x = x;
        this._y = y;
	}

	public int GetX() {
        return this._x;
	}

	public int GetY() {
        return this._y;
	}

    public static bool operator ==(Coordonnee c1, Coordonnee c2) {
        return c1._x == c2._x && c1._y == c2._y;
    }

		public static bool operator !=(Coordonnee c1, Coordonnee c2)
		{
			return c1._x != c2._x || c1._y != c2._y;
		}
    public static Coordonnee operator +(Coordonnee c1, Coordonnee c2) {
        return new Coordonnee((c1._x + c2._x), (c1._y + c2._y));
    }

    public static Coordonnee operator -(Coordonnee c1, Coordonnee c2) {
        return new Coordonnee((c1._x - c2._x), (c1._y - c2._y));
    }
}

