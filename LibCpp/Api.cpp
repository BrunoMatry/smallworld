#include <time.h>
#include <stdlib.h>
#include <cstdlib>
#include "Api.h"

using namespace std;

Api::Api(const int l, const int h) : _lg(l), _ht(h) {
	Api::Triplet* coins = new Api::Triplet[4];
	this->initCoins();
}

int** Api::getRandomCorners(const int nbj) {

	// Initialisation de la matrice resultat
	int** coins = (int**) malloc(nbj * sizeof(int *));
	for (int i = 0; i < nbj ; i++)
		coins[i] = new int[2];

	int c;
	for(int i = 0 ; i < nbj ; i++) {
		do {
			// entier aleatoire entre 0 et 3
			c = rand() % 4;
		} while(_coins[c].taken_);
		coins[i][0] = _coins[c].x_;
		coins[i][1] = _coins[c].y_;
		_coins[c].taken_ = true;
	}
	this->initCoins();
	return coins;
}

int** Api::gen_carte(const int nbtc) const {

	// Initialisation de la matrice resultat
	int** res = (int**) malloc(_ht * sizeof(int *));
	for (int i = 0; i < _ht ; i++)
		res[i] = (int*) malloc(_lg * sizeof(int));

	srand(time(NULL));

	for(int i = 0 ; i <_ht ; i++)
		for(int j = 0 ; j < _lg ; j++)
			res[i][j] = rand() % nbtc;

	return res;
}

int** Api::placerUnites(const int nbJoueurs) {
	// S'il y a 0 joueur ou moins et si le nombre de joueur est superieur au nombre de cases
	if((nbJoueurs <= 0) || (nbJoueurs > (_ht * _lg))) return 0;

	// Initialisation de la matrice resultat
	int** emplacements = (int**) malloc(nbJoueurs * sizeof(int *));
	for (int i = 0; i < nbJoueurs ; i++)
		emplacements[i] = new int[2];
	
	if(nbJoueurs <= 4) { // S'il y a quatre joueurs ou moins, il seront mis dans les coins au hasard
		emplacements = this->getRandomCorners(nbJoueurs);
	} else { // S'il y a cinq joueurs ou plus, ils seront mis cote a cote
		for (int i = 0 ; i < nbJoueurs ; i++ ) {
			emplacements[i][0] = i % _lg;
			emplacements[i][1] = i / _lg;
		}
	}
	return emplacements;
}

void Api::initCoins() {
	Api::Triplet* coins = new Api::Triplet[4];
	coins[0].x_ = 0;
	coins[0].y_ = 0;
	coins[0].taken_ = false;
	coins[1].x_ = (_lg - 1);
	coins[1].y_ = 0;
	coins[1].taken_ = false;
	coins[2].x_ = 0;
	coins[2].y_ = (_ht - 1);
	coins[2].taken_ = false;
	coins[3].x_ = (_lg - 1);
	coins[3].y_ = (_ht - 1);
	coins[3].taken_ = false;
	_coins = coins;
}

Api* Api_new(const int l, const int h) { return new Api(l, h); }
void Api_delete(Api* a) { delete a; }
int** Api_genCarteApi(Api* a, const int ntc) { return a->gen_carte(ntc); }
int** Api_placerUnites(Api* a, const int nbJ) { return a->placerUnites(nbJ); }