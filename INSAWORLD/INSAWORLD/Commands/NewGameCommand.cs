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
            //TODO check la reference de la game
            ReplayCollector.Instance.InitState = this;
        }

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
                game.Player1.UnitsList.First().C.X + "," + game.Player1.UnitsList.First().C.Y + "," +
                game.Player2.Name + "," + game.Player2.RacePlay.Type + "," + 
                game.Player2.UnitsList.First().C.X + "," + game.Player2.UnitsList.First().C.Y + "," +
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
