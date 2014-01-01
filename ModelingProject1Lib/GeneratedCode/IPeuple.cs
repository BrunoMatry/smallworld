using System.Collections.Generic;

public interface IPeuple {

	int NombreUnites { get; }
	List<IUnite> Unites { get; set; }
	void TuerUnite(IUnite unite);
}

