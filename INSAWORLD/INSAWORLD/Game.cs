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
        public Game(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
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

        /// <summary>
        /// launch a game  : contain of the steps of the game
        /// </summary>
        public void Launch()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// create map and put units on it
        /// C++ dll call
        /// </summary>
        public void Initialize(int type)
        {
            BuilderMap.Instance.BuildMap(type);
            BuilderMap.Instance.FillMap(map.Taille);
        }

        /// <summary>
        /// verify end of the game
        /// </summary>
        /// <returns>true if the game is win by one of the player, false if not</returns>
        public bool EndGame()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// after each attack remove units with no life points
        /// </summary>
        public void Cleaner()
        {
            throw new NotImplementedException();
        }
    }
}
