using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class LoadCommand : CommandMenu
    {
        private string name;

        public LoadCommand(string n)
        {
            name = n;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        /// <summary>
        /// load a saved game by reading a file from a save
        /// </summary>
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }
    }
}
