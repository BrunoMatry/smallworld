using System.Collections.Generic;

public interface IMonteurPartie {

	IPartie CreerPartie(string fileName);
	IPartie CreerPartie(TypeCarte tc, List<TypePeuple> tp, string nomPartie);
}

