#ifndef __WRAPPER__
#define __WRAPPER__

#include "../LibCpp/Api.h"
#pragma comment(lib, "../Debug/LibCpp.lib")

using namespace System;
using namespace System::Collections::Generic;

namespace Wrapper {
	public ref class WrapperLib {
		private:
			Api* api;
		public:
			WrapperLib(const int l, const int h){ api = Api_new(l, h); }
			~WrapperLib(){ Api_delete(api); }
			/**
			 * Methode permettant de recupérer la valeur de la fonction gen_carte de l'API (librairie C++)
			 */
			List<int>^ gen_carte(const int ntc) {
				int* tab = api->gen_carte(ntc);
				List<int>^ res = gcnew List<int>();
				int nc = api->getNbCases();
				for (int i = 0 ; i < nc ; i++) {
					res->Add(tab[i]);
				}
				return res;
			};

			List<int>^ placer_unites(const int nbJ) {
				int* tab = api->placerUnites(nbJ);
				List<int>^ res = gcnew List<int>();
				for(int i = 0 ; i < (nbJ * 2) ; i++) {
					res->Add(tab[i]);
				}
				return res;
			}
	};
}
#endif