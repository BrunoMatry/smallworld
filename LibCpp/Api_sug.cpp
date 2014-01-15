#include "Api_sug.h"

bool Api_sug::valide(const int x, const int y) {
	if(x < 0 || y < 0 || x >= _lg || y >= _ht)
		return false;

	return true;
}

int** Api_sug::suggerer_cases(const int x, const int y, const int pt) {
	// Initialisation du tableau résultat
	int** suggestions = (int**) malloc(NBSUGGESTIONS * sizeof(int *));
	for (int i = 0; i < NBSUGGESTIONS ; i++)
		suggestions[i] = new int[2];

	return suggestions;
}

Api_sug* ApiSug_new(const int l, const int h, int** g, int* i, int nb) { return new Api_sug(l, h, g, i, nb); }
void ApiSug_delete(Api_sug* a) { delete a; }
int** ApiSug_suggerer_cases(Api_sug* api, const int x, const int y, const int pt) { return api->suggerer_cases(x, y, pt); }