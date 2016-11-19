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
        //private int defensePoints; // number of damage the creature can take 
        //private int attackPoints; // number of damages the creature can inflict
        private bool played; // true if the unit as been played this turn, false if not
        private Race race;

        public Unit(Race r)
        {
            race = r;
            movePoints = r.Move;
            lifePoints = r.Life;
            played = false;
        }
           

        public float MovePoints
        {
            get;
            set;
        }

        public int LifePoints
        {
            get;
            set;
        }

       

        public bool Played
        {
            get;
            set;
        }

        public Race Race
        {
            get;
        }
    
        //method : ActionMove the unit on the map
        //return true if another unit is on the Tile false if not

        //method : Attack an other unit
        //return true if the fight is won false if not
        public bool Attack(Coord c)
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
