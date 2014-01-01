using System;

public interface IJoueur {

	int Id { get; }
	Boolean EnJeu { get; }
	IPeuple Peuple { get; set; }
}

