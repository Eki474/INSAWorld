using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Demo : GameMap
    {
        private int taille; //size of the board
        private Dictionary<Coord, Tile> casesJoueur; //to stock the tile
        private int nbTurn; // number of maximum turns before the game ends

        public Demo()
        {
            taille = 6;
            nbTurn = 5;
            //casesJoueur.generate(); in the C++ part ???
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

        public int NbTurn
        {
            get { return nbTurn; }
            set { nbTurn = value; }
        }

        public bool TurnPlayed()
        {
            throw new NotImplementedException();
        }
    }
}
