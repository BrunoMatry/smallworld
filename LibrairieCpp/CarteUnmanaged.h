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
		int _pt_vie;

    public:
		DLL int nbPtVie() { return _pt_vie; };

		DLL CarteUnmanaged(): _pt_vie(10) {};

		DLL ~CarteUnmanaged() {};
};