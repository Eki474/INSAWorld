using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //strategy : several implementations of VictoryPoints in function of the race
    public interface Race
    {

        int Attack
        {
            get;
        }

        int Defense
        {
            get;
        }

        int Life
        {
            get;
        }

        int Move
        {
            get;
        }

        int VictoryPoints(ref Game myGame);

        bool ActionMove(Unit u, Coord c, ref Game myGame);

        void MoveOverride(Unit u, Coord c, ref Game myGame);
    }
}
