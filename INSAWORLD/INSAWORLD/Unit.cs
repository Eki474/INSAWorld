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

        //method : Attack an other unit
        //return true if the fight is won false if not
        public bool Attack(Coord c, Unit def)
        {
            bool success = false;
            success = race.ActionMove(this, c);
            if (success)
            {
                double attacker = 0.5;
                double defender = 0.5;
                int ratio = race.Attack / def.Race.Defense;
                if(ratio < 1)
                {
                    attacker = ratio * (100 / (ratio + 1));
                    defender = 100 - attacker;
                }else
                {
                    ratio = def.Race.Defense / race.Attack;
                    attacker += ratio;
                    defender = ratio * (100 / (ratio + 1));
                    attacker = 100 - defender;
                }
                Random prob = new Random();
                if(prob.Next(0,100) < attacker) success = true;
                else success = false;
                played = true;
            }
            return success;
        }

        //method : all points are resetted
        public void Reset()
        {
            lifePoints = race.Life;
            movePoints = race.Move;
            played = false;
        }
    }
}
