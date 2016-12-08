#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 


using namespace std;



void Algo::fillMap(TileType map[], int size)
{
	int cpt[4];
	for (int j = 0; j < 4; j++) {
		cpt[j] = (size / 4);
	}
	int tile = rand() % 4;
	for (int i = 0; i < size; i++) {
		while (cpt[tile] == 0) tile = rand() % 4;
		map[i] = (TileType)(tile);
		cpt[tile]--;
		tile = rand() % 4;
	}
}