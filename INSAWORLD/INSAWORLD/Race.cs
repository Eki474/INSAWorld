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
            set;
        }

        int Defense
        {
            get;
            set;
        }

        int Life
        {
            get;
            set;
        }

        int Move
        {
            get;
            set;
        }

        int VictoryPoints();

        void ActionMove();
    }
}
