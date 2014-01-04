#ifndef __WRAPPER__
#define __WRAPPER__

#include "../LibCpp/Api.h"
#pragma comment(lib, "../Debug/LibCpp.lib")

using namespace System;

namespace Wrapper {
	public ref class Wrapper {
		private:
			Api* api;
		public:
			Wrapper(){ api = Api_new(); }
			~Wrapper(){ Api_delete(api); }
			int* gen_carte(const int ntc, const int nc) { return api->gen_carte(ntc, nc); }
	};
}
#endif