using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IJoueur 
{
	int GetId();
	IPeuple GetPeuple();
	bool EnJeu();
    void NouveauTour();
}

