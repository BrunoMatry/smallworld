#include <time.h>
#include <stdlib.h>   
#include "api.h"


int* gen_carte(const int nbTypeCase, const int nbCases) {

	srand(time(NULL));
	int* tab = new int[nbCases];
	for(int i = 0 ; i < nbCases ; i++) {
		tab[i] = (int)((float)rand()/32767*(nbTypeCase-1));
	}
	return tab;
}