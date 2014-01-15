#ifndef __WRAPPER__
#define __WRAPPER__

#include "../LibCpp/Api_sug.h"
#pragma comment(lib, "../Debug/LibCpp.lib")

using namespace System;
using namespace System::Collections::Generic;

namespace Wrapper {
	public ref class WrapperSug {
		private:
			Api_sug* api;
		public:
			/* 
			 * Methode permettant de 
			 * @param l la longueur de la carte
			 * @param h la hauteur de la carte
			 * @param g la grille (de la carte)
			 * @param inter le tableau contenant la valeur des TypeCase interdits
			 * @param nb le nombre de parametres interdits
			 */
			WrapperSug(const int l, const int h, int** g, List<int>^ inter, int nb) {
				int* it = new int[inter->Count];
				for(int i = 0 ; i < inter->Count ; i++)
					it[i] = inter[i];
				api = ApiSug_new(l, h, g, it, nb);
			}
			~WrapperSug(){ ApiSug_delete(api); }

			/*
			 * Methode permettant de recuperer une liste avec l'ensemble des cases suggerees depuis une case donnee
			 * @param x la coordonnee x de la case donnee
			 * @param y la coordonnee y de la case donnee
			 * @param pt les points de deplacement de l'unite
			 */
			List<Tuple<int, int>^>^ suggerer_cases(const int x, const int y, const int pt) {
				int** tab;
				int nbsugg = api->suggerer_cases(x, y, pt, tab);
				List<Tuple<int, int>^>^ res = gcnew List<Tuple<int, int>^>();
				if(pt <= 0) return res;
				for (int i = 0 ; i < nbsugg ; i++) {
					Tuple<int, int>^ tp = gcnew Tuple<int, int>(tab[i][0], tab[i][1]);
					res->Add(tp);
				}
				
				// Suppression du tableau temporaire
				int max = api->NBMAXSUGGESTIONS;
				for(int i = 0 ; i < max ; i++)
					delete [] tab[i];
				delete [] tab;

				return res;
			}
			// TypeCase
			private int** convGrille(TypeCase** t) {
				int ht = api->getHauteur();
				int lg = api->getLongueur();
				int** res = new int*[ht];
				for(int i = 0 ; i < ht; i++)
					res[i] = new int[lg];

				for (int i = 0; i < ht; i++) {
					for (int j = 0 ; j < lg ; j++){
						switch (t[i][j]) {
						case TypeCase.DESERT:
							res[i][j] = 0;
							break;
						case TypeCase.EAU:
							res[i][j] = 1;
							break;
						case TypeCase.FORET:
							res[i][j] = 2;
							break;
						case TypeCase.MONTAGNE:
							res[i][j] = 3;
							break;
						case TypeCase.PLAINE:
							res[i][j] = 4;
							break;
						default:
							res[i][j] = 4;
							break;
					}
				}
			}
			return res;
			}
	};
}
#endif