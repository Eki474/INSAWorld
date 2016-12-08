using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class NewGameCommand : CommandMenu, ToCollect
    {
        private string state;

        private Game game;
        private int type;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public NewGameCommand(Game g, int t)
        {
            game = g;
            type = t;
        }

        /// <summary>
        /// create a new game
        /// </summary>
        public void Execute()
        {
            game.Map = BuilderMap.Instance.BuildMap(type);
            GameMap m = game.Map;
            BuilderMap.Instance.FillMap(ref m);
            Player p1 = game.Player1;
            Player p2 = game.Player2;
            BuilderMap.Instance.setJoueurs(ref p1, ref p2, m.Taille);
            ReplayCollector.Instance.InitState = this;
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
