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
            get;
            set;
        }

        public Player Player2
        {
            get;
            set;
        }

        public GameMap Map
        {
            get;
            set;
        }

        //launch a game
        public void Launch()
        {
            throw new System.NotImplementedException();
        }

        //create map and put units on it
        //C++ dll call
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        //verify end of the game
        public bool EndGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
