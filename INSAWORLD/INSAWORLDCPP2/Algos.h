#pragma once
#include <iostream>
#include <algorithm>
#include <time.h>
#include <stdlib.h>
#include <math.h> 
#include <sstream>
#include<vector>

enum TileType {
	Plain = 0,
	Swamp = 1,
	Volcano = 2,
	Desert = 3
};

class Algos {

public:
	Algos() {}
	~Algos() {}

	// You can change the return type and the parameters according to your needs.
	void fillMap(TileType map[], int size);

	// action suggest a move of a unit
	
	std::string * Algos::suggestMove(int tableTile[7][7], bool race, double moveP);
	void split(const std::string &s, char delim, std::vector<std::string> &elems);
	std::vector<std::string> suggestMoveAlgo(int tableTile[7][7], double moveP, bool race, std::string cheminActuel, std::vector<std::string> resultat, int posX, int posY);
	std::vector<std::string> setMaximumvector(std::vector<std::string> resultat, std::string cheminActuel);
	int * Algos::placeUnits(int taille);
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algos_fillMap(Algos* algos, TileType map[], int size) {
	return algos->fillMap(map, size);
}

EXPORTCDECL int* Algos_placeUnits(Algos* algos, int taille) {
	return algos->placeUnits(taille);
}

EXPORTCDECL std::string* Algos_suggestMove(Algos* algos, int tableTile[7][7], bool race, double moveP) {
	return algos->suggestMove(tableTile, race, moveP);
}



EXPORTCDECL Algos* Algos_new() {
	return new Algos();
}

EXPORTCDECL void Algos_delete(Algos* Algos) {
	delete Algos;
}



