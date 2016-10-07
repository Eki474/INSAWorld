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

        Dictionary<INSAWORLD.Coord, INSAWORLD.Tile> CasesJoueur
        {
            get;
            set;
        }
    }
}
