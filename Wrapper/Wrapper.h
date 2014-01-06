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
			List<int>^ generer_carte(const int ntc) {
				int** tab = api->gen_carte(ntc);
				List<int>^ res = gcnew List<int>();
				int lg = api->getLongueur();
				int ht = api->getHauteur();
				for (int i = 0 ; i < ht ; i++)
					for(int j = 0 ; j < lg ; j++)
						res->Add(tab[i][j]);
				return res;
			}

			List<Tuple<int, int>^>^ placer_unites(const int nbJ) {
				int** tab = api->placerUnites(nbJ);
				List<Tuple<int, int>^>^ res = gcnew List<Tuple<int, int>^>();
				if(nbJ <= 0) return res;
				for (int i = 0 ; i < nbJ ; i++) {
					Tuple<int, int>^ tp = gcnew Tuple<int, int>(tab[i][0], tab[i][1]);
					res->Add(tp);
				}
				return res;
			}

			Tuple<int, int>^ get_dimensions() {
				return gcnew Tuple<int, int>(api->getLongueur(), api->getHauteur());
			}
	};
}
#endif

	/*int* tab = api->gen_carte(ntc);
		List<int>^ res = gcnew List<int>();
		int nc = api->getNbCases();
		for (int i = 0 ; i < nc ; i++) {
			res->Add(tab[i]);
		} */