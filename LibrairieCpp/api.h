#pragma once

#ifdef WANT_DLL_EXPORT
	#define DLL  __declspec( dllexport )
#else
	#define DLL  __declspec( dllimport )
#endif

DLL int* gen_carte() {

}
