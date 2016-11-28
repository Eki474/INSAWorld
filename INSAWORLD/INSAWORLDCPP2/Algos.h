#pragma once

enum TileType {
	Plain = 0,
	Moutain = 1,
	Forest = 2,
	Water = 3
};

class Algos {

public:
	Algos() {}
	~Algos() {}

	// You can change the return type and the parameters according to your needs.
	bool fillMap(TileType map[], int size);

	// action suggest a move of a unit
	bool suggestMove(int tableTile[], int race, int moveP);
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL bool Algos_fillMap(Algos* Algos, TileType map[], int size) {
	return Algos->fillMap(map, size);
}

EXPORTCDECL Algos* Algos_new() {
	return new Algos();
}

EXPORTCDECL void Algos_delete(Algos* Algos) {
	delete Algos;
}
