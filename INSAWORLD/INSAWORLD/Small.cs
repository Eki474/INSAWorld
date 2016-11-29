﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Small : GameMap
    {
        private int taille; //size of the board
        private Dictionary<Coord, Tile> casesJoueur; //to stock the tile
        private int nbTurn; // number of maximum turns before the game ends

        /// <summary>
        /// constructor
        /// </summary>
        public Small()
        {
            taille = 10;
            nbTurn = 20;
            //casesJoueur.generate(); in the C++ part ???
        }

        public int Taille
        {
            get { return taille; }
            set { taille = value; }
        }

        public int NbTurn
        {
            get { return nbTurn; }
            set { nbTurn = value; }
        }

        public Dictionary<Coord, Tile> CasesJoueur
        {
            get { return casesJoueur; }
            set { casesJoueur = value; }
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
