using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //flyweight
    public interface Tile
    {
        string getType();
        bool Equals(Tile t);
    }
}
