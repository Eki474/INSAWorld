using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //strategy : several implementations of VictoryPoints in function of the race
    public interface Race
    {
        Dictionary<Coord, INSAWORLD.Unit> Units
        {
            get;
            set;
        }

        int VictoryPoints();
    }
}
