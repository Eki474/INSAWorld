using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Standard : GameMap
    {
        private int taille; //size of the board
        private Dictionary<Coord, Tile> casesJoueur; //to stock the tile
        private int nbTurn; // number of maximum turns before the game ends

        public Standard()
        {
            taille = 14;
            nbTurn = 30;
            //casesJoueur.generate(); in the C++ part ???
        }

        public int NbTurn
        {
            get { return nbTurn; }
            set { nbTurn = value; }
        }

        public int Taille
        {
            get { return taille; }
            set { taille = value; }
        }

        public Dictionary<Coord, Tile> CasesJoueur
        {
            get { return casesJoueur; }
            set { casesJoueur = value; }
        }

        public bool TurnPlayed()
        {
            throw new NotImplementedException();
        }
    }
}
