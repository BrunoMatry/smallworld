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

		int** getRandomCorners(const int nb);
		void initCoins();

	public:
		Api(const int l, const int h);
		~Api() {}
		/**
		 * Methode permettant la génération aléatoire de la carte
		 * @param nbtc le nombre de types de cases differents
		 * @return la matrice avec l'ensemble des cases associees a un type case
		 */
		int** gen_carte(const int nbtc) const;
		/**
		 * Methode permettant d'obtenir le placement des unites
		 * @param nbj le nombre de joueurs
		 * @return une matrice de taille nbj * 2,
		 *	avec les coordonnees des unites en fonction des joueurs
		 */
		int** placerUnites(const int nbj);
		/**
		 * Methode permettant d'obtenur le nombre de case que comprend la carte
		 * @return le nombre de cases
		 */
		int getNbCases() { return _lg * _ht; }
};

EXTERNC DLL Api* Api_new(const int l, const int h);
EXTERNC DLL void Api_delete(Api* api);
EXTERNC DLL int** Api_genCarteApi(Api* api, const int ntc);
EXTERNC DLL int** Api_placerUnites(Api* api, const int nbJ);
