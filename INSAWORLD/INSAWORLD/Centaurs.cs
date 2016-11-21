using System;

namespace INSAWORLD
{
    public class Centaurs : Race
    {

        private int attack;
        private int defense;
        private int life;
        private int move;

        public Centaurs()
        {
            attack = 8;
            defense = 2;
            life = 10;
            move = 3;
        }

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
