using System;

namespace INSAWORLD
{
    public class Unit
    {
        private float movePoints; // number of tile the unit can ActionMove on
        private int lifePoints; // number of points before the unit dies
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
            get { return movePoints; }
            set { movePoints = value; }
        }

        public int LifePoints
        {
            get { return lifePoints; }
            set { lifePoints = value; }
        }

        public bool Played
        {
            get { return played; }
            set { played = value; }
        }

        public Race Race
        {
            get { return race; }
            set { race = value; }
        }

        //method : Attack an other unit
        //return true if the fight is won false if not
        public int Attack(Coord c, Unit def)
        {
            bool success = false;
            int lifeP = 0;
            success = race.ActionMove(this, c);
            if (success)
            {
                double attacker = 0.5;
                double defender = 0.5;
                int ratio = (race.Attack * (lifePoints / race.Life)) / (def.Race.Defense * (def.LifePoints / def.Race.Life));
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
                Random lostPoints = new Random();
                //if random between 0 and attacker --> the attacker wins
                //if random superior to attacker --> the defenser wins
                if (prob.Next(0, 100) < attacker)
                {
                    success = true;
                    //if attacker wins --> return a positive value of the defenser life points lost
                    lifeP = lostPoints.Next(1, race.Attack);
                }
                else
                {
                    success = false;
                    //if attacker wins --> return a negative value of the defenser life points lost
                    lifeP = -lostPoints.Next(1, def.race.Attack);
                }
                played = true;
            }
            return lifeP;
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
