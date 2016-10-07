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

        KeyValuePair<Coord, Tile> CasesJoueur
        {
            get;
            set;
        }
    }
}
