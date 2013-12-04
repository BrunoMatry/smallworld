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

			static List<int>^ gencarte() {
				int* tab = gen_carte();
				List<int>^ res = gcnew List<int>();
				for (int i = 0 ; i < 3 ; i++) {
					res->Add(tab[i]);
				}
				return res;
			};

	};
}