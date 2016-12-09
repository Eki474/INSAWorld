using INSAWORLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Player
    {
        private string name; //name of the player 
        private Race racePlay; //race choosen by the player 
        private int points; //points earned by the player 
        List<Unit> unitsList; //units of the player 
        private bool playing; //player currently playing
        private int tailleMap; //taille de la map

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">name of the player</param>
        /// <param name="race">0 if Cyclops - 1 if Cerberus - 2 if Centaurs</param>
        /// <param name="tailleMap">6 Demo - 10 Small - 14 Standard</param>
        public Player(string n, int race, int tailleMap)
        {
            name = n;
            points = 0;
            this.tailleMap = tailleMap;
            racePlay = RaceFactory.Instance.createRace(race);
            UnitsList = UnitsFactory.Instance.createUnits(racePlay, this.tailleMap);
            playing = false;
        }

        public Player(string [] n)
        {
            unitsList = new List<Unit>();
            name = n[1];
            racePlay = RaceFactory.Instance.createRace(n[2]);
            points = 0;
            playing = "True".Equals(n[3]);
            for (int i = 4; i < n.Length; i+=5)
            {
                unitsList.Add(new Unit(n[i], n[i + 1], n[i + 2], n[i + 3], n[i + 4], racePlay));
            }
        }

        public Player(string n, string r, string x, string y, string tm)
        {
            name = n;
            racePlay = RaceFactory.Instance.createRace(r);
            int cx = int.Parse(x);
            int cy = int.Parse(y);
            Coord c = new Coord(cx, cy);
            tailleMap = int.Parse(tm);
            unitsList = UnitsFactory.Instance.createUnits(racePlay, tailleMap, c);
            points = 0;
            playing = false;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int TailleMap
        {
            get { return tailleMap; }
            set { tailleMap = value; }
        }
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Race RacePlay
        {
            get { return racePlay; }
            set { racePlay = value; }
        }

        public bool Playing
        {
            get { return playing; }
            set { playing = value; }
        }

        public List<Unit> UnitsList
        {
            get { return unitsList; }
            set{ unitsList = value; }
        }

        /// <summary>
        /// check if unitsList is empty
        /// </summary>
        /// <returns>true if the game is lost by the player false if not</returns>
        public bool Lost()
        {
            return unitsList.Count == 0;
        }

        /// <summary>
        /// Check if the player still has playing options 
        /// </summary>
        /// <param name="map">reference to the map</param>
        /// <returns>true if the turn has to be ended false if not</returns>
        public bool EndTurn(ref GameMap map)
        {
            foreach(Unit u in unitsList)
            {
                if(!(u.Played && racePlay.NoMoreMoves(u, ref map)))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// begin the turn of a player : playing = true for the current player (while the other is on false thanks to EndTurn)
        /// </summary>
        /// <returns>true if the turn can be started false if not</returns>
        public void StartTurn()
        {
            playing = true;
        }

        public void NextTurn(ref Game g)
        {
            var cmd = new NextTurn(g);
            if (cmd.CanExecute()) cmd.Execute();
        }

        /// <summary>
        /// method compute points earned by the player this turn (attribute points)
        /// </summary>
        /// <param name="map">reference to the map</param>
        public void ComputePoints(ref Game game)
        {
            points = 0;
            var buf = new List<Coord>();
            foreach(Unit u in unitsList)
            {
                if (!buf.Contains(u.C))
                {
                    points += racePlay.VictoryPoints(u, ref game);
                    buf.Add(u.C);
                }
            }
        }

        /// <summary>
        /// call unit attack method and remove life points
        /// </summary>
        /// <param name="u">unit which attack</param>
        /// <param name="d">pair of unit/coord of the attacked unit</param>
        /// <param name="myGame">reference to the game to obtain the map</param>
        /// <returns>true if the attack has been done false if not</returns>
        public bool Attack(Unit u, Unit d, ref Game myGame)
        {
            var cmd = new AttackUnit(u, d, ref myGame);
            if (!cmd.CanExecute()) return false;
            cmd.Execute();
            return true;
        }

        public Unit FindDefender(Coord c, ref Game myGame)
        {
            string n = this.name;
            Player o;
            if (myGame.Player1.Name != n) o = myGame.Player1;
            else o = myGame.Player2;
            int max = 0;
            Unit maxUnit = null;
            foreach(Unit u in o.UnitsList)
            {
                if (u.C.Equals(c))
                {
                    if(u.LifePoints>max)
                    {
                        maxUnit = u;
                        max = u.LifePoints;
                    }
                }
            }
            return maxUnit;
        }

        public bool Move(Unit u, Coord c, ref Game myGame)
        {
            var cmd = new MoveUnit(u, c, ref myGame);
            if (cmd.CanExecute())
            {
                cmd.Execute();
                return true;
            }
            return false;
        }


        public bool Equals(Player p)
        {
            bool b = false;
            foreach(Unit u in p.UnitsList){
                foreach (Unit u2 in unitsList)
                {
                    if (u.Equals(u2)) { b = true; break; }
                }
                if (!b) return false;
                b = false;
            }
            return p.Name.Equals(name) && p.RacePlay.Equals(racePlay);
        }

        public static bool operator ==(Player p1, Player p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Player p1, Player p2)
        {
            return !p1.Equals(p2);
        }

    }
}
