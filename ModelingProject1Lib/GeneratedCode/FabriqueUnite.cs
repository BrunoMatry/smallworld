using System.Collections.Generic;

public class FabriqueUnite : IFabriqueUnite
{
	public virtual List<IUnite> CreerUnites(TypePeuple type, int nbUnites, int joueur, Coordonnee c)
	{
		List<IUnite> res = new List<IUnite>();
		switch (type) {
			case TypePeuple.GAULOIS:
				for(int i = 0 ; i < nbUnites ; i++)
					res.Add(new UniteGaulois(joueur, c));
				break;
			case TypePeuple.NAINS:
				for (int i = 0; i < nbUnites; i++)
					res.Add(new UniteNain(joueur, c));
				break;

			case TypePeuple.VIKING:
				for (int i = 0; i < nbUnites; i++)
					res.Add(new UniteViking(joueur, c));
				break;

			default:
				break;
		}
		return res;
	}
}

