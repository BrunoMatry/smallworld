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
			WrapperLib(){ api = Api_new(); }
			~WrapperLib(){ Api_delete(api); }
			List<int>^ gen_carte(const int ntc, const int nc) {
				int* tab = api->gen_carte(ntc, nc);
				List<int>^ res = gcnew List<int>();
				for (int i = 0 ; i < nc ; i++) {
					res->Add(tab[i]);
				}
				return res;
			};
	};
}
#endif