#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
#include <utility>

class DLL Api {
	private:
		struct Triplet {
		  int x_, y_;
		  bool taken_;
		};

		int _lg;
		int _ht;
		Triplet* _coins;

		int* getRandomCorners(const int nb);
		void resetCoinsTaken();

	public:
		Api(const int l, const int h);
		~Api() {}
		/**
		 * Methode permettant la génération aléatoire de la carte
		 * Cette méthode retourne un pointeur vers un tableau de nbCases entiers
		 * compris entre 0 et nbTypeCase - 1
		 */
		int* gen_carte(const int nbTypeCase) const;
		int* placerUnites(const int nbJoueurs);
		int getNbCases() { return _lg * _ht; }
};

EXTERNC DLL Api* Api_new(const int l, const int h);
EXTERNC DLL void Api_delete(Api* api);
EXTERNC DLL int* Api_genCarteApi(Api* api, const int ntc);
EXTERNC DLL int* Api_placerUnites(Api* api, const int nbJ);
