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

        public Game(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            BuilderMap.Instance.BuildMap();
            BuilderMap.Instance.FillMap();
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

        //launch a game
        public void Launch()
        {
            throw new NotImplementedException();
        }

        //create map and put units on it
        //C++ dll call
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        //verify end of the game
        public bool EndGame()
        {
            throw new NotImplementedException();
        }

        //after each attack remove units with no life points
        public static void Cleaner()
        {
            throw new NotImplementedException();
        }
    }
}
