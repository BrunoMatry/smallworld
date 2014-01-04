#include <time.h>
#include <stdlib.h> 
#include "Api.h"

int* Api::gen_carte(const int nbTypeCase, const int nbCases) const {

	srand(time(NULL));
	int* tab = new int[nbCases];
	for(int i = 0 ; i < nbCases ; i++) {
		tab[i] = (int)((float)rand()/32767*(nbTypeCase-1));
	}
	return tab;
}

Api* Api_new() { return new Api(); }
void Api_delete(Api* a) { delete a; }

int* Api_genCarteApi(Api* a, const int ntc, const int nc) { return a->gen_carte(ntc, nc); } 