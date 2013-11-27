#pragma once

class CarteUnmanaged
{
	private:
		int _nb_type_case;

    public:
		CarteUnmanaged(int nb_type_case): _nb_type_case(nb_type_case) {};		

		int* gen_carte() {
			int carte[] = {1,2,3};
			return carte;
		};


		~CarteUnmanaged() {};
};
