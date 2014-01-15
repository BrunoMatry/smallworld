#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
#include <utility>

class DLL Api_sug {
	private:
		/* Parametres */
		int _lg, _ht, _nbInterdits;
		int** _grille;
		int* _interdits;

		/* Methodes privees */
		bool valide(const int x, const int y);
		void dovalide(const int tx, const int ty, int& nbsugg, int** suggestions);

	public:
		static const int NBMAXSUGGESTIONS = 30;

		/**
		  * Constructeur de la classe Api_sug
		  * @param l la longueur de la carte
		  * @param h la hauteur de la carte
		  * @param g la grille (de la carte)
		  * @param i le tableau contenant la valeur des TypeCase interdits
		  * @param nb le nombre de parametres interdits
		  */
		Api_sug(const int l, const int h, int** g, int* i, int nb)
			: _lg(l), _ht(h), _grille(g), _interdits(i), _nbInterdits(nb) {}
		~Api_sug() {
			// Nettoyage de la grille
			for(int i = 0 ; i < _ht ; i++)
				delete [] _grille[i];
			// Nettoyage des interdits
			delete [] _interdits;
		}

		int suggerer_cases(const int x, const int y, const int pt, int** sug);

		/* Getters */
		int getLongueur() const;
		int getHauteur() const;
};

inline int Api_sug::getLongueur() const { return _lg; }
inline int Api_sug::getHauteur() const { return _ht; }

EXTERNC DLL Api_sug* ApiSug_new(const int l, const int h, int** g, int* i, int nb);
EXTERNC DLL void ApiSug_delete(Api_sug* api);
EXTERNC DLL int ApiSug_suggerer_cases(Api_sug* api, const int x, const int y, const int pt, int** suggestions);
