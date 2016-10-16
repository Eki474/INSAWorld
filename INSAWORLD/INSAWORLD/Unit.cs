using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Unit
    {
        private int movePoints; // number of tile the unit can move on
        private int lifePoints; // number of points before the unit dies
        private int defensePoints; // number of damage the creature can take 
        private int attackPoints; // number of damages the creature can inflict
        private bool played; // true if the unit as been played this turn, false if not

        public float MovePoints
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int LifePoints
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int DefensePoints
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int AttackPoints
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool Played
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        //method : move the unit on the map
        public bool Move()
        {
            throw new System.NotImplementedException();
        }

        //method : attack an other unit
        public bool Attack()
        {
            throw new System.NotImplementedException();
        }

        //method : all points are resetted
        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
