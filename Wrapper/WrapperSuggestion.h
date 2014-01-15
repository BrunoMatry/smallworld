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
			/* TODO conversion int** */
			WrapperSug(const int l, const int h, int** g, int* i, int nb) { api = ApiSug_new(l, h, g, i, nb); }
			~WrapperSug(){ ApiSug_delete(api); }

			List<Tuple<int, int>^>^ suggerer_cases(const int x, const int y, const int pt) {
				int** tab;
				int nbsugg = api->suggerer_cases(x, y, pt, tab);
				List<Tuple<int, int>^>^ res = gcnew List<Tuple<int, int>^>();
				if(pt <= 0) return res;
				for (int i = 0 ; i < nbsugg ; i++) {
					Tuple<int, int>^ tp = gcnew Tuple<int, int>(tab[i][0], tab[i][1]);
					res->Add(tp);
				}
				return res;
			}
	};
}
#endif