using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Unit
    {
        private int movePoints; // number of tile the unit can ActionMove on
        private int lifePoints; // number of points before the unit dies
        private int defensePoints; // number of damage the creature can take 
        private int attackPoints; // number of damages the creature can inflict
        private bool played; // true if the unit as been played this turn, false if not

        public Unit(int race)
        {
            movePoints = 3;
            played = false;
            switch (race)
            {
                case -1:
                    break;
                case 0:
                    //Centaurs
                    lifePoints = 10;
                    defensePoints = 2;
                    attackPoints = 8;
                    break;
                case 1:
                    //Cerberus
                    lifePoints = 10;
                    defensePoints = 4;
                    attackPoints = 6;
                    break;
                case 2:
                    //Cyclops
                    lifePoints = 12;
                    defensePoints = 6;
                    attackPoints = 4;
                    break;
            }
        }

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

        public Race Race
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        //method : ActionMove the unit on the map
        //return true if another unit is on the Tile false if not

        //method : Attack an other unit
        //return true if the fight is won false if not
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
