using System;

public interface IJoueur {

	int Id { get; }
	int Points { get; } 
	Boolean EnJeu { get; }
	Peuple Peuple { get; set; }
	/**
	 * Methode permetant la mise a jour automatique des points
	 */
	void MAJPoints();
}

