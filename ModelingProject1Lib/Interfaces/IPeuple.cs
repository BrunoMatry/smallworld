using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IPeuple 
{
	List<IUnite> GetUnites();
	int GetNombreUnites();
	void TuerUnite(IUnite unite);
	void CreerUnite(int nb, int idJoueur);
    void NouveauTour();
}

