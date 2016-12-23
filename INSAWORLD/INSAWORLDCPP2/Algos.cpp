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
void Algos::suggestMove(int tableTile[49], string retour[], bool race, double moveP)
{
	std::vector<std::string> result;
	// retour: stocke les chemins sous la forme {déplacementX déplacementY,} ex: "0,1,3"
	// déplacement: 0 -> 1 <- 2 î 3 V
	int table[7][7];
	for (int i = 0; i < 49; i++) {
		table[i / 7][i % 7] = tableTile[i];
	}
	result = Algos::suggestMoveAlgo(table, moveP, race, "", result, 3, 3);

	retour[0] = result[0];
	retour[1] = result[1];
	retour[2] = result[2];

};


//string traitement : split on ,
void Algos::split(const std::string &s, char delim, std::vector<std::string> &elems)
{
	std::stringstream ss;
	ss.str(s);
	std::string item;
	while (std::getline(ss, item, delim)) {
		elems.push_back(item);
	}
}

//suggest the 3 best move to the player : algo logic
//oob = out of bounds
std::vector<std::string> Algos::suggestMoveAlgo(int tableTile[7][7], double moveP, bool race, std::string cheminActuel, std::vector<std::string> resultat, int posX, int posY) {
	if (tableTile[posX][posY] = 1 && race) moveP += 0.5;
	// cas d'arrêt: case déjà visitée/occupée/plus de points/oob
	if (moveP - 1 < 0 || tableTile[posX][posY] == 2 || tableTile[posX][posY] == 3 || tableTile[posX][posY] == -1) {
		return setMaximumvector(resultat, cheminActuel);
	}
	tableTile[posX][posY] = 3;
	std::vector<std::string> tmpvector;
	if (posX + 1 < 7) tmpvector = suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "0,", resultat, posX + 1, posY);
	for (int i = 0; i < (int)(tmpvector.size()); i++) {
		resultat = setMaximumvector(resultat, tmpvector[i]);
	}
	if (posX - 1 > 0) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "1,", resultat, posX - 1, posY);
	for (int i = 0; i < (int)(tmpvector.size()); i++) {
		resultat = setMaximumvector(resultat, tmpvector[i]);
	}
	if (posY + 1 < 7) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "2,", resultat, posX, posY + 1);
	for (int i = 0; i < (int)(tmpvector.size()); i++) {
		resultat = setMaximumvector(resultat, tmpvector[i]);
	}
	if (posY - 1 > 0) suggestMoveAlgo(tableTile, moveP - 1, race, cheminActuel + "3,", resultat, posX, posY - 1);
	for (int i = 0; i < (int)(tmpvector.size()); i++) {
		resultat = setMaximumvector(resultat, tmpvector[i]);
	}
	return resultat;

}

//place unit on game start : the first player random, the other as far as possible
int * Algos::placeUnits(int retour[], int taille) {
	srand(time(NULL));
	int x = rand() % taille;
	int y = rand() % taille;
	retour[0] = x;
	retour[1] = y;
	/*int * result = new int[2];
	result[0] = x;
	result[1] = y;
	return result;*/
}

// sert à remplir le vecteur par les trois meilleurs chemins == les trois chemins les plus longs
std::vector<std::string> Algos::setMaximumvector(std::vector<std::string> resultat, std::string cheminActuel) {
	int mini = 0;
	int tailleMin = 100;
	if (cheminActuel == "") return resultat;
	//vire la dernière virgule
	cheminActuel.pop_back();
	std::vector<std::string> tmp;
	//si on n'a pas encore le nombre de chemins requis
	if ((int)(resultat.size()) < 3) {
		resultat.push_back(cheminActuel);
	}
	else {
		for (int i = 0; i < (int)resultat.size(); i++) {
			std::string actual = resultat[i];
			split(actual, ',', tmp);
			if ((int)(tmp.size()) < tailleMin) { tailleMin = (int)(tmp.size()); mini = i; }

		}
		split(cheminActuel, ',', tmp);
		if ((int)(tmp.size()) > tailleMin) {

			resultat[mini] = cheminActuel;
		}
	}
	return resultat;
}
