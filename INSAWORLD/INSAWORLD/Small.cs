using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Small : GameMap
    {
        private int taille; //size of the board
        private List<Tile> casesJoueur; //to stock the tile
        private int nbTurn; // number of maximum turns before the game ends

        public Small()
        {
            taille = 10;
            nbTurn = 20;
            //casesJoueur.generate(); in the C++ part ???
        }

        public int Taille
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Array CasesJoueur
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int NbTurn
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Dictionary<Coord, Tile> GameMap.CasesJoueur
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool TurnPlayed()
        {
            throw new NotImplementedException();
        }
    }
}
