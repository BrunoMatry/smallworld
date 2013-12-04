#pragma once

#ifdef WANT_DLL_EXPORT
	#define DLL  __declspec(dllexport)
#else
	#define DLL  __declspec(dllimport)
#endif

//extern "C" {
		DLL int* gen_carte(const int nbTypeCase, const int nbCases);
//}