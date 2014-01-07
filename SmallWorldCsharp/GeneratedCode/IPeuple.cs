using System.Collections.Generic;

public interface IPeuple {

	int NombreUnites { get; }
	List<Unite> Unites { get; set; }
	void TuerUnite(Unite unite);
}

