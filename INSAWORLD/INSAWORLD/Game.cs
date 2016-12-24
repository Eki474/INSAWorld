using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Game
    {
        private Player player1; //launch the game
        private Player player2; //join the game
        private GameMap map; //board
        private ReplayCollector rpz; //ReplayCollector

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="p1">Joueur 1</param>
        /// <param name="p2">Joueur 2</param>
        public Game(ref Player p1, ref Player p2)
        {
            Unit.idGlob = 0;
            player1 = p1;
            player2 = p2;
            Random rdn = new Random();
            if (rdn.Next(1, 3) == 1) player1.Playing = true;
            else player2.Playing = true;
            rpz = new ReplayCollector();
        }

        /// <summary>
        /// constructor for SaveCommand
        /// </summary>
        /// <param name="p1">Player 1</param>
        /// <param name="p2">Player 2</param>
        /// <param name="map">Map</param>
        public Game(ref Player p1, ref Player p2, ref GameMap map)
        {
            Unit.idGlob = 0;
            player1 = p1;
            player2 = p2;
            this.map = map;
            rpz = new ReplayCollector();
        }

        public Player Player1
        {
            get { return player1; }
            set { player1 = value; }
        }

        public Player Player2
        {
            get { return player2; }
            set { player2 = value; }
        }

        public GameMap Map
        {
            get { return map; }
            set { map = value; }
        }

        public ReplayCollector Rpz
        {
            get { return rpz; }
            set { rpz = value; }
        }

        /// <summary>
        /// create map and put units on it
        /// </summary>
        public void Initialize(int type)
        {
            new NewGameCommand(this, type).Execute();

        }

        /// <summary>
        /// verify end of the game
        /// </summary>
        /// <returns>true if the game is win by one of the player, false if not</returns>
        public bool EndGame()
        {
            return player1.Lost() || player2.Lost() || map.NbTurn == 0;
        }

        /// <summary>
        /// operators re-definition
        /// </summary>

        public bool Equals(Game g)
        {
            return player1.Equals(g.player1) && player2.Equals(g.player2) && map.Equals(g.map);
        }

        public static bool operator ==(Game g, Game g2)
        {
            return g2.Equals(g);
        }

        public static bool operator !=(Game g, Game g2)
        {
            return !g2.Equals(g);
        }


        /// <summary>
        /// after each attack remove units with no life points
        /// </summary>
        public void Cleaner()
        {
            Unit unitToRemove = null;
            bool found = false;
            foreach (Unit u in player1.UnitsList)
            {
                if (u.LifePoints == 0)
                {
                    found = true;
                    unitToRemove = u;
                }
            }
            if (found) player1.UnitsList.Remove(unitToRemove);
            else
            {
                foreach (Unit u in player2.UnitsList)
                {
                    if (u.LifePoints == 0)
                    {

                        found = true;
                        unitToRemove = u;
                    }
                }
                if (found) player2.UnitsList.Remove(unitToRemove);
            }
        }
    }
}
