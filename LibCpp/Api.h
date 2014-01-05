#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

class DLL Api {
	public:
		Api() {}
		~Api() {}
		/**
		 * Methode permettant la génération aléatoire de la carte
		 * Cette méthode retourne un pointeur vers un tableau de nbCases entiers
		 * compris entre 0 et nbTypeCase - 1
		 */
		int* gen_carte(const int nbTypeCase, const int nbCases) const;
};

EXTERNC DLL Api* Api_new();
EXTERNC DLL void Api_delete(Api* api);
EXTERNC DLL int Api_genCarteApi(Api* api);
