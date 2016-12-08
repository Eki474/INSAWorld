using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class NewGameCommand : CommandMenu, ToCollect
    {
        private string initState;
        private string state;

        public string InitState
        {
            get { return initState; }
            set { initState = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// create a new game
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
