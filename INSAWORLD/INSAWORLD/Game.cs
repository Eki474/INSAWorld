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

        public ~Game()
        {
            player1 = null;
            player2 = null;
            map = null;
        }

        public Player Player1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Player Player2
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public GameMap Map
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void Launch()
        {
            throw new System.NotImplementedException();
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
