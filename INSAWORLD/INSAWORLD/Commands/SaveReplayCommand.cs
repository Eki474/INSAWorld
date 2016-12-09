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

            System.IO.File.WriteAllText(@Environment.CurrentDirectory + @"\Replay\" + name + ".Game.txt", text);

            string textMap = game.Rpz.ToStringMap();

            System.IO.File.WriteAllText(@Environment.CurrentDirectory + @"\Replay\" + name + ".Map.txt", textMap);
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
