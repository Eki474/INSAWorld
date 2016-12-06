using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public interface GameMap
    {

        int NbTurn
        {
            get;
            set;
        }

        int Taille
        {
            get;
            set;
        }

        Dictionary<Coord, Tile> CasesJoueur
        {
            get;
            set;
        }

        /// <summary>
        /// decrement nbTurn when a turn is finished. -0.5 for a turn in a two-players game. 
        /// </summary>
        /// <returns>true if nbTurn inferior to 0 false if equals to 0</returns>
        bool TurnPlayed();
    }
}
