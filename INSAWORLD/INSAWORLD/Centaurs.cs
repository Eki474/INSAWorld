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
            get { return attack; }
            set { attack = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public int Move
        {
            get { return move; }
            set { move = value; }
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
