#pragma once
#include <iostream>
#include <algorithm>
#include <time.h>
#include <stdlib.h>
#include <math.h> 
#include <sstream>
#include<vector>
#include <comutil.h>

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

	///fill map with random tiles, result contains same number of each tile type
	BSTR Algos::suggestMove(int tableTile[49], bool race, double moveP);
	///string traitement : split on ,
	int split(const std::string &s, char delim);
	///suggest the 3 best move to the player
	void Algos::suggestMoveAlgo(int tableTile[7][7], double moveP, bool race, std::string cheminActuel, std::string * resultat, int * taille, int posX, int posY);
	/// sert à remplir le vecteur par les trois meilleurs chemins == les trois chemins les plus longs
	void Algos::setMaximumvector(std::string * resultat, int * taille, std::string cheminActuel);
	///place unit on game start : the first player random, the other as far as possible
	void Algos::placeUnits(int retour[], int taille);
	BSTR Algos::ANSItoBSTR(const char* input);
};




#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way

///fill map with random tiles, result contains same number of each tile type
EXPORTCDECL void Algos_fillMap(Algos* algos, TileType map[], int size) {
	return algos->fillMap(map, size);
}

///place unit on game start : the first player random, the other as far as possible
EXPORTCDECL void Algos_placeUnits(Algos* algos, int retour[], int taille) {
	return algos->placeUnits(retour, taille);
}

///suggest the 3 best move to the player
EXPORTCDECL BSTR Algos_suggestMove(Algos* algos, int tableTile[49], bool race, double moveP) {
	return algos->suggestMove(tableTile, race, moveP);
}


///memory management : create
EXPORTCDECL Algos* Algos_new() {
	return new Algos();
}

///memory management : delete
EXPORTCDECL void Algos_delete(Algos* Algos) {
	delete Algos;
}



