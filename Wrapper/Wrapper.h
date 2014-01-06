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
			int** generer_carte(const int ntc) { return Api_genCarteApi(api, ntc); }
			int** placer_unites(const int nbJ) { return Api_placerUnites(api, nbJ); }
	};
}
#endif

	/*int* tab = api->gen_carte(ntc);
		List<int>^ res = gcnew List<int>();
		int nc = api->getNbCases();
		for (int i = 0 ; i < nc ; i++) {
			res->Add(tab[i]);
		} */