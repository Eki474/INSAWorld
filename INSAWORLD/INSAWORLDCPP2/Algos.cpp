#include "Algos.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 
#include <vector>
#include <sstream>

using namespace std;



bool Algos::fillMap(TileType map[], int size)
{
	//TODO : init map tiles with a better algorithm
	for (int i = 0; i < size; i++)
		map[i] = (TileType)(i % 4);

	return true;
}

// action suggest a move of a unit
// race: true si centaure, false sinon
// tableFile: 0 pour case "normale", 1 pour case plaine, 2 pour case occup�e, 3 pour case visit�e, -1 pour oob
vector<string> Algos::suggestMove(int tableTile[7][7], bool race, int moveP)
{
	vector<string> result;
	// retour: stocke les chemins sous la forme {d�placementX d�placementY,} ex: "0,1,3"
	// d�placement: 0 -> 1 <- 2 � 3 V
	if (!race) {
		// /!\ il faut d�j� avoir la case actuelle � 3 pour ne pas retourner 

		result = suggestMoveNormal(tableTile, moveP, "", result, 4, 4);
	}
	else {

		result = suggestMoveCentaur(tableTile[7][7], moveP, 4, 4);
	}
	return result;
}

void split(const std::string &s, char delim, std::vector<std::string> &elems) {
	std::stringstream ss;
	ss.str(s);
	std::string item;
	while (std::getline(ss, item, delim)) {
		elems.push_back(item);
	}
}

vector<string> suggestMoveNormal(int tableTile[7][7], int moveP, string cheminActuel, vector<string> resultat, int posX, int posY) {
	// cas d'arr�t: case d�j� visit�e/occup�e/plus de points/oob
	if (moveP == 0 || tableTile[posX][posY] == 2 || tableTile[posX][posY] == 3 || tableTile[posX][posY] == -1) {
		return setMaximumVector(resultat, cheminActuel);
	}
	tableTile[posX][posY] = 3;
	vector<string> tmpvector;
	if (posX + 1 < 7) tmpvector = suggestMoveNormal(tableTile, moveP - 1, cheminActuel + "0,", resultat, posX + 1, posY);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posX - 1 > 0) suggestMoveNormal(tableTile, moveP - 1, cheminActuel + "1,", resultat, posX - 1, posY);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posY + 1 < 7) suggestMoveNormal(tableTile, moveP - 1, cheminActuel + "2,", resultat, posX, posY + 1);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posY - 1 > 0) suggestMoveNormal(tableTile, moveP - 1, cheminActuel + "3,", resultat, posX, posY - 1);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	return resultat;

}

vector<string> suggestMoveCentaur(int tableTile[7][7], int moveP, string cheminActuel, vector<string> resultat, int posX, int posY) {
	if (tableTile[posX][posY] = 1) moveP += 0.5;
	// cas d'arr�t: case d�j� visit�e/occup�e/plus de points/oob
	if (moveP == 0 || tableTile[posX][posY] == 2 || tableTile[posX][posY] == 3 || tableTile[posX][posY] == -1) {
		return setMaximumVector(resultat, cheminActuel);
	}
	tableTile[posX][posY] = 3;
	vector<string> tmpvector;
	if (posX + 1 < 7) tmpvector = suggestMoveNormal(tableTile, moveP - 1, cheminActuel + "0,", resultat, posX + 1, posY);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posX - 1 > 0) suggestMoveNormal(tableTile, moveP - 1, cheminActuel + "1,", resultat, posX - 1, posY);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posY + 1 < 7) suggestMoveNormal(tableTile, moveP - 1, cheminActuel + "2,", resultat, posX, posY + 1);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	if (posY - 1 > 0) suggestMoveNormal(tableTile, moveP - 1, cheminActuel + "3,", resultat, posX, posY - 1);
	for (int i = 0; i < tmpvector.size; i++) {
		resultat = setMaximumVector(resultat, tmpvector[i]);
	}
	return resultat;

}


// sert � remplir le vecteur par les trois meilleurs chemins
vector<string> setMaximumVector(vector<string> resultat, string cheminActuel) {
	int mini = 0;
	int tailleMin = 100;
	cheminActuel.pop_back;
	std::vector<std::string> tmp;
	//si on n'a pas encore le nombre de chemins requis
	if (resultat.size < 3) {
		resultat.push_back(cheminActuel);
	}
	else {
		for (int i = 0; i < 3; i++) {
			string actual = resultat[i];
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