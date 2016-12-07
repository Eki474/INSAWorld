using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class NextTurn : CommandMenu, ToCollect
    {

        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// end the player turn and go to the next turn
        /// </summary>
        public Array Execute()
        {
            throw new NotImplementedException();
        }
    }
}
