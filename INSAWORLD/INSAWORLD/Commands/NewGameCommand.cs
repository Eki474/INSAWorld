using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class NewGameCommand : CommandMenu, ToCollect
    {
        private Game game; //game
        private int type; //map type
        private Coord initP1; //initial coord of player1 
        private Coord initP2; //initial coord of player2 
        private String typeName = "NewGameCommand";

        public string TypeName
        {
            get
            {
                return typeName;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="g">game</param>
        /// <param name="t">map type</param>
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
            initP1 = new Coord(p1.UnitsList.First().C.X, p1.UnitsList.First().C.Y);
            initP2 = new Coord(p2.UnitsList.First().C.X, p2.UnitsList.First().C.Y);
            game.Rpz.InitState = this;
        }

        /// <summary>
        /// Do nothing
        /// </summary>
        public void ExecuteReplay() { }

        /// <summary>
        /// do nothing, don't use
        /// </summary>
        /// <returns>true</returns>
        public bool CanExecute()
        {
            return true;
        }

        /// <summary>
        /// for ReplayCollector
        /// </summary>
        /// <returns>init,name(player1),race,coordX,coordY,name(player2),race,coordX,coordY,map_taille</returns>
        override
        public string ToString()
        {
            return "init," + game.Player1.Name + "," + game.Player1.RacePlay.Type + "," + 
               initP1.X + "," + initP1.Y + "," +
                game.Player2.Name + "," + game.Player2.RacePlay.Type + "," + 
                initP2.X + "," + initP2.Y + "," +
                game.Map.Taille;
        }

        /// <summary>
        /// for ReplayCollector
        /// </summary>
        /// <returns>tiles types with , as separator of columns and \n for the lines</returns>
        public string ToStringMap()
        {
            string res = "";
            int i;
            int j;
            Tile t;
            for (i = 0; i < game.Map.Taille; i++)
            {
                for (j = 0; j < game.Map.Taille - 1; j++)
                {
                    t = game.Map.CasesJoueur[new Coord(i, j)];
                    res += t.getType() + ",";
                }
                t = game.Map.CasesJoueur[new Coord(i, j)];
                res += t.getType() + "\n";
            }
            return res;
        }
    }
}
