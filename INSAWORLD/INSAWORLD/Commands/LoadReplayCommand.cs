using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace INSAWORLD
{
    public class LoadReplayCommand : CommandMenu
    {
        private string name; //name of the save - to find the file
        private Game game;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">name of the save</param>
        public LoadReplayCommand(string n)
        {
            name = n;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Game Game
        {
            get { return game; }
            private set { game = value; }
        }

        /// <summary>
        /// load a file for a replay
        /// </summary>
        public void Execute()
        {
            string line;
            string[] linesplit;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(@Environment.CurrentDirectory + @"\Replay\" + name + ".Game.txt");

            line = file.ReadLine();
            linesplit = line.Split(',');
            Player p1 = new Player(linesplit[1], linesplit[2], linesplit[3], linesplit[4]);


        }

        /// <summary>
        /// verify if the file exists
        /// </summary>
        /// <returns>return true if file exists, false if not</returns>
        public bool CanExecute()
        {
            if (File.Exists(@Environment.CurrentDirectory + @"\Replay\" + name + ".txt"))
            {
                return true;
            }
            return false;
        }
    }
}
