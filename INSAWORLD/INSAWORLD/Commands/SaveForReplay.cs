using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class SaveReplayCommand : CommandMenu
    {
        private ReplayCollector replayCollector;

        public ReplayCollector ReplayCollector
        {
            get { return replayCollector; }
            set { replayCollector = value; }
        }

        /// <summary>
        /// save all the state of the game in a file
        /// </summary>
        public Array Execute()
        {
            throw new NotImplementedException();
        }
    }
}
