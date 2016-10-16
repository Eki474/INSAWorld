using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //factory

    //problem : nombre d'unités par joueur change en fonction du type de map
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
