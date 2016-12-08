using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class SaveCommand : CommandMenu
    {

        private Game game; //current game
        private string name; //name of the save - to create the file

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="g">current game</param>
        /// <param name="n">name of the save</param>
        public SaveCommand(ref Game g, string n)
        {
            game = g;
            name = n;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        /// <summary>
        /// save the state of the game in a file
        /// </summary>
        public void Execute()
        {
            int i;
            int j;

            //Save player 1 state
            var p1 = game.Player1;
            string text = "player1," + p1.Name + "," + p1.RacePlay.Type+","+p1.Playing+",";
            var l1 = p1.UnitsList;
            for (i= 0; i < l1.Count - 1; i++){
                text += l1[i].Id + "," + l1[i].C.X + "," + l1[i].C.Y + ",";
            }
            if(l1.Count>0) text += l1[l1.Count-1].Id + "," + l1[l1.Count - 1].C.X + "," + l1[l1.Count - 1].C.Y + "\n";

            //Save player 2 state
            var p2 = game.Player2;
            text += "player2," + p2.Name + "," + p2.RacePlay.Type + "," + p2.Playing + ",";
            var l2 = p2.UnitsList;
            for (i = 0; i < l2.Count - 1; i++)
            {
                text += l2[i].Id + "," + l2[i].C.X + "," + l2[i].C.Y + ",";
            }
            if (l2.Count > 0) text += l2[l2.Count - 1].Id + "," + l2[l2.Count - 1].C.X + "," + l2[l2.Count - 1].C.Y + "\n";

            //Save map state
            text += "map," + game.Map.Taille + "\n";

            Tile t;
            for (i = 0; i < game.Map.Taille; i++)
            {
                for (j = 0; j < game.Map.Taille - 1; j++)
                {
                    t = game.Map.CasesJoueur[new Coord(i, j)];
                    text += t.getType() + ",";
                }
                t = game.Map.CasesJoueur[new Coord(i, j)];
                text += t.getType() + "\n";
            }

            System.IO.File.WriteAllText(@Environment.CurrentDirectory+@"\Save\"+name+".txt", text);
        }

        /// <summary>
        /// verify the game has been created
        /// </summary>
        /// <returns>true if the game is not null, false if it does</returns>
        public bool CanExecute()
        {
            return ReplayCollector.Instance.InitState != null;
        }
    }
}
