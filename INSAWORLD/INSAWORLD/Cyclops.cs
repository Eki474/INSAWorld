using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Cyclops : Race
    {
        private int attack;
        private int defense;
        private int life;
        private int move;

        public Cyclops()
        {
            attack = 4;
            defense = 6;
            life = 12;
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
