using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IMonteurPartie {

	IPartie CreerPartie(string fileName);
	IPartie CreerPartie(TypeCarte tc, List<TypePeuple> tp, string nomPartie);
}

