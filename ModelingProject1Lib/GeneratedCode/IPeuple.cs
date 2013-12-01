using System.Collections.Generic;

public interface IPeuple {

	List<IUnite> GetUnites();
	int GetNombreUnites();
	void TuerUnite(IUnite unite);
	void CreerUnite(int nb, int idJoueur);
}

