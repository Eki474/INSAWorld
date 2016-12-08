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

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="p1">Joueur 1</param>
        /// <param name="p2">Joueur 2</param>
        public Game(ref Player p1, ref Player p2)
        {
            player1 = p1;
            player2 = p2;
            Random rdn = new Random();
            if (rdn.Next(1, 3) == 1) player1.Playing = true;
            else player2.Playing = true;
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

        //TODO nextturn verifier endgame

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
        /// after each attack remove units with no life points
        /// </summary>
        public void Cleaner()
        {
            foreach(Unit u in player1.UnitsList)
            {
                if (u.LifePoints == 0)
                {
                    player1.UnitsList.Remove(u);
                }
            }
            foreach(Unit u in player2.UnitsList)
            {
                if (u.LifePoints == 0)
                {
                    player2.UnitsList.Remove(u);
                }
            }
        }
    }
}
