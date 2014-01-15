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
		int _lg, _ht, _nbInterdits;
		int** _grille;
		int* _interdits;

		bool valide(const int x, const int y);
		bool dovalide(const int tx, const int ty, int& nbsugg, int** suggestions);

	public:
		static const int NBSUGGESTIONS = 3;
		Api_sug(const int l, const int h, int** g, int* i, int nb)
			: _lg(l), _ht(h), _grille(g), _interdits(i), _nbInterdits(nb) {}
		~Api_sug() {}

		int** suggerer_cases(const int x, const int y, const int pt);

		/* Getters */
		int getLongueur() const;
		int getHauteur() const;
};

inline int Api_sug::getLongueur() const { return _lg; }
inline int Api_sug::getHauteur() const { return _ht; }

EXTERNC DLL Api_sug* ApiSug_new(const int l, const int h, int** g, int* i, int nb);
EXTERNC DLL void ApiSug_delete(Api_sug* api);
EXTERNC DLL int** ApiSug_suggerer_cases(Api_sug* api, const int x, const int y, const int pt);
