// Wrapper.h

#pragma once
#include "carteUnmanaged.h"
//#include <vector.h>

//using namespace System;

public ref class WrapperCarte
{
	// pointer to the Unmanaged class
	// the constructor will allocate the pointer pu
	public:
		CarteUnmanaged *c;
		
		WrapperCarte() : c(new CarteUnmanaged()) {};

		int nbPtVie() {
			return c->nbPtVie();
		};

		[]int genererCarte(int lar, int lg) {

		};

};