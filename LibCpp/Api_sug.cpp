#include "Api_sug.h"

bool Api_sug::valide(const int x, const int y) {
	if(x < 0 || y < 0 || x >= _lg || y >= _ht)
		return false;
	for(int i = 0 ; i < _nbInterdits ; i++) {
		if(_grille[x][y] == _interdits[i])
			return false;
	}
	return true;
}

void Api_sug::dovalide (const int tx, const int ty, int& nbsugg, int** suggestions) {
	if(valide(tx, ty)) {
		suggestions[nbsugg][0] = tx;
		suggestions[nbsugg][1] = ty;
		nbsugg++;
	}
}

int Api_sug::suggerer_cases(const int x, const int y, const int pt, int** sug) {
	int nbsugg = 0;
	int tx, ty;
	// Initialisation du tableau résultat
	int** suggestions = new int*[NBMAXSUGGESTIONS];
	for (int i = 0; i < NBMAXSUGGESTIONS ; i++)
		suggestions[i] = new int[2];

	ty = y;
	for(int dx = 1 ; dx <= pt ; dx++) {
		tx = x + dx;
		dovalide (tx, ty, nbsugg, suggestions);
		tx = x - dx;
		dovalide (tx, ty, nbsugg, suggestions);
	}
	tx = x;
	for(int dy = 1 ; dy <= pt ; dy++) {
		ty = y + dy;
		dovalide (tx, ty, nbsugg, suggestions);
		ty = y - dy;
		dovalide (tx, ty, nbsugg, suggestions);
	}
	for(int dx = 1 ; dx < pt ; dx++) {
		tx = x + dx;
		for(int dy = 1 ; dy < (pt - dx) ; dy++) {
			ty = y + dy;
			dovalide (tx, ty, nbsugg, suggestions);
		}
		tx = x - dx;
		for(int dy = 1 ; dy < (pt - dx) ; dy++) {
			ty = y - dy;
			dovalide (tx, ty, nbsugg, suggestions);
		}
	}
	sug = suggestions;
	return nbsugg;
}

Api_sug* ApiSug_new(const int l, const int h, int** g, int* i, int nb) { return new Api_sug(l, h, g, i, nb); }
void ApiSug_delete(Api_sug* a) { delete a; }
int ApiSug_suggerer_cases(Api_sug* api, const int x, const int y, const int pt, int** sug) { return api->suggerer_cases(x, y, pt, sug); }