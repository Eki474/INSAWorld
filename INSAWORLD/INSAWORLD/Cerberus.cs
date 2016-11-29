using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Cerberus : Race
    {
        private int attack;
        private int defense;
        private int life;
        private int move;

        public Cerberus()
        {
            attack = 6;
            defense = 4;
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
