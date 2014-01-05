using System.Collections.Generic;

public class FabriqueUnite : IFabriqueUnite {

	/**
	 * Methode permettant la creation d'un nombre d'unites donne
	 * type Le type du peuple des unites a creer
	 * nb Le nombre d'unites a creer
	 * j Le joueur auquel seront rattachees les unites
	 * c La coordonnee a laquelle sont placees les unites au depart
	 * /!\ Cette case ne doit pas contenir d'unites enemies
	 */
	public virtual List<IUnite> CreerUnites(TypePeuple type, int nb, int j, Coordonnee c)
	{
		List<IUnite> res = new List<IUnite>();
		switch (type) {
			case TypePeuple.GAULOIS:
				for(int i = 0 ; i < nb ; i++)
					res.Add(new UniteGaulois(j, c));
				break;
			case TypePeuple.NAINS:
				for (int i = 0; i < nb; i++)
					res.Add(new UniteNain(j, c));
				break;

			case TypePeuple.VIKING:
				for (int i = 0; i < nb; i++)
					res.Add(new UniteViking(j, c));
				break;

			default:
				break;
		}
		return res;
	}
}

