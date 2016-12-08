using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class LoadReplayCommand : CommandMenu
    {
        private string name;

        public LoadReplayCommand(string n)
        {
            name = n;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        /// <summary>
        /// load a file for a replay
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
