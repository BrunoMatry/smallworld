#include <time.h>
#include <stdlib.h>
#include <cstdlib>
#include "Api.h"

using namespace std;

Api::Api(const int l, const int h) : _lg(l), _ht(h) {
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

void Api::resetCoinsTaken() {
	for(int i = 0 ; i < 4 ; i++)
		_coins[i].taken_ = false;	
}

int* Api::getRandomCorners(const int nb) {
	int* res = new int[nb * 2];
	int c;
	for(int i = 0 ; i < nb ; i++) {
		do {
			// entier aleatoire entre 0 et 3
			c = rand() % 4;
		} while(_coins[c].taken_);
		res[(i*2)] = _coins[c].x_;
		res[(i*2) + 1] = _coins[c].y_;
		_coins[c].taken_ = true;
	}
	this->resetCoinsTaken();
	return res;
}

int* Api::gen_carte(const int nbTypeCase) const {

	srand(time(NULL));
	int nbCases = _lg * _ht;
	int* tab = new int[nbCases];
	for(int i = 0 ; i < nbCases ; i++) {
		tab[i] = (int)((float)rand()/32767*(nbTypeCase-1));
	}
	return tab;
}

int* Api::placerUnites(const int nbJoueurs) {
	int* tab = new int[nbJoueurs * 2];
	// S'il y a 0 joueur ou moins et si le nombre de joueur est superieur au nombre de cases
	if((nbJoueurs <= 0) || (nbJoueurs > (_ht * _lg))) return 0;
	
	if(nbJoueurs <= 4) { // S'il y a quatre joueurs ou moins, il seront mis dans les coins au hasard
		tab = this->getRandomCorners(nbJoueurs);
	} else { // S'il y a cinq joueurs ou plus, ils seront mis cote a cote
		for (int i = 0 ; i < nbJoueurs ; i++ ) {
			tab[(i*2)] = i % _lg;
			tab[(i*2) + 1] = i / _lg;
		}
	}
	return tab;
}

Api* Api_new(const int l, const int h) { return new Api(l, h); }
void Api_delete(Api* a) { delete a; }
int* Api_genCarteApi(Api* a, const int ntc) { return a->gen_carte(ntc); }
int* Api_placerUnites(Api* a, const int nbJ) { return a->placerUnites(nbJ); }