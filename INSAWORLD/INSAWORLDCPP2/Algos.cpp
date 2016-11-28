#include "Algos.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 


using namespace std;



bool Algos::fillMap(TileType map[], int size)
{
	//TODO : init map tiles with a better algorithm
	for (int i = 0; i < size; i++)
		map[i] = (TileType)(i % 4);

	return true;
}

// action suggest a move of a unit
// 
bool Algos::suggestMove(int tableTile[], int race, int moveP)
{

}