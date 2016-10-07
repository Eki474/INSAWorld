using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public interface Race
    {
        Dictionary<Coord, INSAWORLD.Unit> Units
        {
            get;
            set;
        }

        void VictoryPoints();
    }
}
