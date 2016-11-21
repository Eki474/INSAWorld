using System;

namespace INSAWORLD
{
    public class Centaurs : Race
    {
        //contains units of the race (so player) and their coordinates on the map

        public Centaurs()
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

        public bool ActionMove(Unit u, Coord c)
        {
            throw new NotImplementedException();
        }
    }
}
