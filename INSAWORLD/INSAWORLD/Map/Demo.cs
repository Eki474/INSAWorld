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

        /// <summary>
        /// constructor
        /// </summary>
        public Demo()
        {
            taille = 6;
            nbTurn = 5;
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

        /// <summary>
        /// decrement nbTurn when a turn is finished. -0.5 for a turn in a two-players game. 
        /// </summary>
        /// <returns>true if nbTurn inferior to 0 false if equals to 0</returns>
        public bool TurnPlayed()
        {
            throw new NotImplementedException();
        }
    }
}
