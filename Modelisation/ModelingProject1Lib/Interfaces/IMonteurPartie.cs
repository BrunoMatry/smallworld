using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public interface IMonteurPartie 
{
	IPartie CreerPartie(File p);
	IPartie CreerPartie(TypeCarte tc, List<TypePeuple> tp, string nomPartie);
}

