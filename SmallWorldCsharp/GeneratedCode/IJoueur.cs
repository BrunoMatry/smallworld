﻿using System;

public interface IJoueur {

	int Id { get; }
	int Points { get; } 
	Boolean EnJeu { get; }
	Peuple Peuple { get; set; }
	void MAJPoints();
}

