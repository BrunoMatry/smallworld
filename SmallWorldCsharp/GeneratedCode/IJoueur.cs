using System;

public interface IJoueur {

	int Id { get; }
	int Points { get; } 
	Boolean EnJeu { get; }
	IPeuple Peuple { get; set; }
	void MAJPoints();
}

