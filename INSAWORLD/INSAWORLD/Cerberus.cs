using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Cerberus : Race
    {
        //contains units of the race (so player) and their coordinates on the map

        public Cerberus()
        {
            //add base units of the race
        }

        //method : compute points earned by the race, this turn

        public int Attack
        {
            get;
            set;
        }

        public int Defense
        {
            get;
            set;
        }

        public int Life
        {
            get;
            set;
        }

        public int Move
        {
            get;
            set;
        }

        public int VictoryPoints()
        {
            throw new NotImplementedException();
        }

        public void ActionMove()
        {
            throw new NotImplementedException();
        }

        public void ActionMove(Unit u, Coord c)
        {
            throw new NotImplementedException();
        }
    }
}
