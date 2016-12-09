using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class SaveReplayCommand : CommandMenu
    {
        private string name; //name of the save - to create the file
        private Game game;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">name of the save</param>
        public SaveReplayCommand(string n, ref Game g)
        {
            name = n;
            game = g; 
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        /// <summary>
        /// save all the state of the game in a file
        /// </summary>
        public void Execute()
        {
            string text = game.Rpz.ToString();

            System.IO.StreamWriter file =
               new System.IO.StreamWriter(@Environment.CurrentDirectory + @"\Replay\" + name + ".Game.txt");

            file.Write(text);

            file.Flush();
            file.Close();

            string textMap = game.Rpz.ToStringMap();

            file =
               new System.IO.StreamWriter(@Environment.CurrentDirectory + @"\Replay\" + name + ".Map.txt");

            file.Write(textMap);

            file.Flush();
            file.Close();
        }

        /// <summary>
        /// verify the game has been created
        /// </summary>
        /// <returns>true if the game is not null, false if it does</returns>
        public bool CanExecute()
        {
            return game.Rpz.InitState!=null;
        }
    }
}
