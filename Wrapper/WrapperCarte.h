// Wrapper.h

#pragma once
#include "Api.h"

using namespace System::Collections::Generic;

namespace wrapper {
	public ref class WrapperCarte
	{
		// pointer to the Unmanaged class
		// the constructor will allocate the pointer pu
		public:

			static List<int>^ wrap_gen_carte(const int nbTypeCase, const int nbCases) {
				int* tab = gen_carte(nbTypeCase, nbCases);
				List<int>^ res = gcnew List<int>();
				for (int i = 0 ; i < nbCases ; i++) {
					res->Add(tab[i]);
				}
				return res;
			};

	};
}