#pragma once

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
	vector<string> suggestMove(int tableTile[7][7], bool race, int moveP);
	void split(const std::string &s, char delim, std::vector<std::string> &elems);
	vector<string> suggestMoveAlgo(int tableTile[7][7], int moveP, bool race, string cheminActuel, vector<string> resultat, int posX, int posY);
	vector<string> setMaximumVector(vector<string> resultat, string cheminActuel);
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algos_fillMap(Algos* algos, TileType map[], int size) {
	return algos->fillMap(map, size);
}

EXPORTCDECL vector<std::string> Algos_suggestMove(Algos* algos, int tableTile[7][7], bool race, int moveP) {
	return algos->suggestMove(tableTile, race, moveP);
}

EXPORTCDECL Algos* Algos_new() {
	return new Algos();
}

EXPORTCDECL void Algos_delete(Algos* Algos) {
	delete Algos;
}
