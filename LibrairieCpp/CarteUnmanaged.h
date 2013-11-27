#pragma once
#define WANT_DLL_EXPORT

#ifdef WANT_DLL_EXPORT
	#define DLL  __declspec( dllexport )
#else
	#define DLL	 //standard
#endif

class CarteUnmanaged
{
	private:
		int _nb_type_case;

    public:
		DLL int* gen_carte() {
			int carte[] = {1,2,3};
			return carte;
		};

		DLL CarteUnmanaged(int nb_type_case): _nb_type_case(nb_type_case) {};

		DLL ~CarteUnmanaged() {};
};