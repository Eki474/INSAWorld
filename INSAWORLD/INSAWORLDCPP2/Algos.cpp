#include "Algos.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <stdlib.h>
#include <math.h> 
#include <vector>
#include <sstream>

using namespace std;

//Plain = 0, Swamp = 1, Volcano = 2, Desert = 3
//generate a map with random tile 
//A new map shall be generated for each game.A map shall contain the same number of tiles of each type.
void Algos::fillMap(TileType map[], int size)
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

// action suggest a move of a unit
// race: true si centaure, false sinon
// tableFile: 0 pour case "normale", 1 pour case plaine, 2 pour case occupée, 3 pour case visitée, -1 pour oob
vector<std::string> Algos::suggestMove(int tableTile[7][7], bool race, int moveP)
{
	vector<std::string> result;
	// retour: stocke les chemins sous la forme {déplacementX déplacementY,} ex: "0,1,3"
	// déplacement: 0 -> 1 <- 2 î 3 V

	result = suggestMoveAlgo(tableTile, moveP, race, "", result, 4, 4);

	return result;
}

void Algos::split(const std::string &s, char delim, std::vector<std::string> &elems)
{
	std::stringstream ss;
	ss.str(s);
	std::string item;
	while (std::getline(ss, item, delim)) {
		elems.push_back(item);
	}
}


//oob = out of bounds
vector<std::string> Algos::suggestMoveAlgo(int tableTile[7][7], int moveP, bool race, std::string cheminActuel, vector<std::string> resultat, int posX, int posY) {
	if (tableTile[posX][posY] = 1 && race) moveP += 0.5;
	// cas d'arrêt: case déjà visitée/occupée/plus de points/oob
	if (moveP - 1 < 0 || tableTile[posX][posY] == 2 || tableTile[posX][posY] == 3 || tableTile[posX][posY] == -1) {
		return setMaximumVector(resultat, cheminActuel);
	}
	tableTile[posX][posY] = 3;
	vector<std::string> tmpvector;
	if (posX + 1 < 7) tmpvector = suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "0,", resultat, posX + 1, posY);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posX - 1 > 0) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "1,", resultat, posX - 1, posY);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posY + 1 < 7) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "2,", resultat, posX, posY + 1);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posY - 1 > 0) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "3,", resultat, posX, posY - 1);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	return resultat;

}

int * Algos::placeUnits(int taille) {
	int x = rand() % taille;
	int y = rand() % taille;
	int result[2] = { x, y };
	return result;
}

// sert à remplir le vecteur par les trois meilleurs chemins == les trois chemins les plus longs
vector<std::string> Algos::setMaximumVector(vector<std::string> resultat, std::string cheminActuel) {
	int mini = 0;
	int tailleMin = 100;
	if (cheminActuel == "") return resultat;
	//vire la dernière virgule
	cheminActuel.pop_back;
	std::vector<std::string> tmp;
	//si on n'a pas encore le nombre de chemins requis
	if (resultat.size < 3) {
		resultat.push_back(cheminActuel);
	}
	else {
		for (int i = 0; i < 3; i++) {
			std::string actual = resultat[i];
			split(actual, ',', tmp);
			if (tmp.size < tailleMin) { tailleMin = tmp.size; mini = i; }

		}
		split(cheminActuel, ',', tmp);
		if (tmp.size > tailleMin) {

			resultat[mini] = cheminActuel;
		}
	}
	return resultat;
}

