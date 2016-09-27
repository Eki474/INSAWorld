using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public interface Map
    {
        int Taille
        {
            get;
            set;
        }

        int NbTurn
        {
            get;
            set;
        }

        INSAWORLD.Tile** CasesJoueur
        {
            get;
            set;
        }
    }
}
