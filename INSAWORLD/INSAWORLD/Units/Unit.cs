using System;

namespace INSAWORLD
{
    public class Unit
    {
        public static int idGlob = 0;
        private int id; //identifiant unique d'une unité
        private double movePoints; // number of tile the unit can ActionMove on
        private int lifePoints; // number of points before the unit dies
        private bool played; // true if the unit as been played this turn, false if not
        private Race race; // unit race
        private Coord c; // unit coordinates on the map

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="r">race of the unit</param>
        public Unit(ref Race r)
        {
            race = r;
            movePoints = r.Move;
            lifePoints = r.Life;
            played = false;
            id = idGlob;
            idGlob++;
        }

        /// <summary>
        /// copnstructor for SaveCommand
        /// </summary>
        /// <param name="id">id unit</param>
        /// <param name="coordX">coord X for a unit</param>
        /// <param name="coordY">coord Y for a unit</param>
        /// <param name="movePoint">move points remaining</param>
        /// <param name="lifePoint">life points remaining</param>
        /// <param name="r">race</param>
        public Unit(string id, string coordX, string coordY, string movePoint, string lifePoint, Race r)
        {
            this.id = int.Parse(id);
            this.c = new Coord(int.Parse(coordX), int.Parse(coordY));
            this.movePoints = int.Parse(movePoint);
            this.lifePoints = int.Parse(lifePoint);
            race = r;
        }

        /// <summary>
        /// constructor for SaveReplayCommand
        /// </summary>
        /// <param name="r">race</param>
        /// <param name="co">coord</param>
        public Unit(ref Race r, ref Coord co)
        {
            race = r;
            movePoints = r.Move;
            lifePoints = r.Life;
            played = false;
            c=co;
            id = idGlob;
            idGlob++;
        }

        /// <summary>
        /// copy
        /// </summary>
        /// <param name="u"></param>
        public Unit(Unit u)
        {
            movePoints = u.movePoints;
            lifePoints = u.lifePoints;
            played = u.played;
            race = u.race;
            c = u.c;
        }

        /// <summary>
        /// copy by ref
        /// </summary>
        /// <param name="u"></param>
        public Unit(ref Unit u)
        {
            movePoints = u.movePoints;
            lifePoints = u.lifePoints;
            played = u.played;
            race = u.race;
            c = u.c;
        }


        public double MovePoints
        {
            get { return movePoints; }
            set { movePoints = value; }
        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
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

        public Coord C
        {
            get { return c; }
            set { c = value; }
        }

        /// <summary>
        /// Attack an other unit
        /// </summary>
        /// <param name="c">coord of the attacked unit</param>
        /// <param name="def">unit which defend the tile on coord</param>
        /// <param name="myGame">reference to game to use information from map</param>
        /// <returns>true if the fight is won false if not</returns>
        public int Attack(Coord c, Unit def, ref Game myGame)
        {
            int lifeP = 0;
            double attacker = 0.5;
            double defender = 0.5;
            int ratio = (race.Attack * (lifePoints / race.Life)) / (def.Race.Defense * (def.LifePoints / def.Race.Life));
            if (ratio < 1)
            {
                attacker = ratio * (100 / (ratio + 1));
                defender = 100 - attacker;
            }
            else
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
                //if attacker wins --> return a positive value of the defenser life points lost
                lifeP = lostPoints.Next(1, race.Attack);
            }
            else
            {
                //if attacker wins --> return a negative value of the defenser life points lost
                lifeP = -lostPoints.Next(1, def.race.Attack);
            }
            played = true;

            return lifeP;
        }

        /// <summary>
        /// All points are resetted + life regen 
        /// </summary>
        public void Reset()
        {
            if (!played && movePoints == race.Move && lifePoints<race.Life) lifePoints++; //life regen
            movePoints = race.Move;
            played = false;
        }

        public bool Equals(Unit u)
        {
            return u.C.Equals(c) && u.id == id && u.LifePoints == lifePoints && u.movePoints == movePoints;
        }
        public static bool operator ==(Unit u, Unit u2)
        {
            return u.Equals(u2);
        }

        public static bool operator !=(Unit u, Unit u2)
        {
            return !u.Equals(u2);
        } 
    }
}
