#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 


using namespace std;



void Algo::fillMap(TileType map[], int size)
{
	int cpt[4];
	for (int j : cpt) {
		j = size / 4;
	}
	int tile = rand() % 4;
	for (int i = 0; i < size; i++) {
		if (cpt[tile] != 0) {
			map[i] = (TileType)(tile);
			cpt[tile]--;
		}
		else {
			tile = rand() % 4;
			i--;
		}
		tile = rand() % 4;
	}
}