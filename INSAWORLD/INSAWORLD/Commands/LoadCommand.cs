using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class LoadCommand : CommandMenu
    {
        private string name; //name of the save - to find the file
        private Game game;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">name of the save</param>
        public LoadCommand(string n)
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
        /// load a saved game by reading a file from a save
        /// </summary>
        public void Execute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// verify if the file exists
        /// </summary>
        /// <returns>return true if file exists, false if not</returns>
        public bool CanExecute()
        {
            throw new NotImplementedException();
        }
    }
}
