#include "Algos.h"

using namespace std;

//Plain = 0, Swamp = 1, Volcano = 2, Desert = 3
//generate a map with random tile 
//A new map shall be generated for each game.A map shall contain the same number of tiles of each type.
void Algos::fillMap(TileType map[], int size)
{
	srand(time(NULL));
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

// action suggest a move of a unit
// race: true si centaure, false sinon
// tableFile: 0 pour case "normale", 1 pour case plaine, 2 pour case occupée, 3 pour case visitée, -1 pour oob
BSTR  Algos::suggestMove(int tableTile[225] ,  bool race, double moveP)
{
	std::string result[3];
	// retour: stocke les chemins sous la forme {déplacementX déplacementY,} ex: "0,1,3"
	// déplacement: 0 -> 1 <- 2 î 3 V
	int table[15][15];
	for (int i = 0; i < 225; i++) {
		table[i / 15][i % 15] = tableTile[i];
	}
	int  taille = 0;

	Algos::suggestMoveAlgo(table, moveP, race, "", result, &taille, 7, 7);
	std::string tampon = "";
	int i = 0;
	if (taille != 0) {
		for (; i < taille - 1; i++) {
			tampon += result[i] + "/";
		}
		tampon += result[i];
	}
	
	return ::SysAllocString(ANSItoBSTR(tampon.c_str()));
};

BSTR Algos::ANSItoBSTR(const char* input)
{
	BSTR result = NULL;
	int lenA = lstrlenA(input);
	int lenW = ::MultiByteToWideChar(CP_ACP, 0, input, lenA, NULL, 0);
	if (lenW > 0)
	{
		result = ::SysAllocStringLen(0, lenW);
		::MultiByteToWideChar(CP_ACP, 0, input, lenA, result, lenW);
	}
	return result;
}

//string traitement : split on ,
int Algos::split(const std::string &s, char delim)
{
	int i = 0;
	std::stringstream ss;
	ss.str(s);
	std::string item;
	while (std::getline(ss, item, delim)) {
		i++;
	}
	return i;
}

//suggest the 3 best move to the player : algo logic
//oob = out of bounds
void Algos::suggestMoveAlgo(int tableTile[15][15], double moveP, bool race, std::string cheminActuel, std::string * resultat, int * taille, int posX, int posY) {
	if (tableTile[posX][posY] = 1 && race) moveP += 0.5;
	tableTile[posX][posY] = 3;
	// cas d'arrêt: case déjà visitée/occupée/plus de points/oob
	if (moveP - 1 >= 0) {
	if (posX + 1 < 15 && (tableTile[posX+1][posY] != 2 && tableTile[posX+1][posY] != 3 && tableTile[posX+1][posY] != -1)) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "0,", resultat, taille, posX + 1, posY);

	if (posX - 1 > 0 && (tableTile[posX-1][posY] != 2 && tableTile[posX-1][posY] != 3 && tableTile[posX-1][posY] != -1)) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "1,", resultat, taille, posX - 1, posY);

	if (posY + 1 < 15 && (tableTile[posX][posY+1] != 2 && tableTile[posX][posY+1] != 3 && tableTile[posX][posY+1] != -1)) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "2,", resultat, taille, posX, posY + 1);

	if (posY - 1 > 0 && (tableTile[posX][posY-1] != 2 && tableTile[posX][posY-1] != 3 && tableTile[posX][posY-1] != -1)) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "3,", resultat, taille, posX, posY - 1);

	}
	setMaximumvector(resultat, taille, cheminActuel);

}

//place unit on game start : the first player random, the other as far as possible
void Algos::placeUnits(int retour[], int taille) {
	int x = rand() % taille;
	int y = rand() % taille;
	retour[0] = x;
	retour[1] = y;
}

// sert à remplir le vecteur par les trois meilleurs chemins == les trois chemins les plus longs
void Algos::setMaximumvector(std::string * resultat, int * taille, std::string cheminActuel) {
	int mini = 0;
	int tailleMin = 100;
	if (cheminActuel == "") return;
	//vire la dernière virgule
	cheminActuel.pop_back();
	//si on n'a pas encore le nombre de chemins requis
	if (*taille < 3) {
		resultat[*taille] = cheminActuel;
		*taille = *taille + 1;
		return;
	}
	else {
		int size = 0;
		for (int i = 0; i < *taille; i++) {
			std::string actual = resultat[i];
			size = split(actual, ',');
			if (size < tailleMin) { tailleMin = size; mini = i; }

		}
		size = split(cheminActuel, ',');
		if (size > tailleMin) {

			resultat[mini] = cheminActuel;
		}
	}
}