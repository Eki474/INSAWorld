using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class SaveReplayCommand : CommandMenu
    {
        private string name;

        /// <summary>
        /// save all the state of the game in a file
        /// </summary>
        public void Execute()
        {
            string text = ReplayCollector.Instance.ToString();

            System.IO.File.WriteAllText(@Environment.CurrentDirectory + @"\Replay\" + DateTime.Today + "-" + name + ".Game.txt", text);

            string textMap = ReplayCollector.Instance.ToStringMap();

            System.IO.File.WriteAllText(@Environment.CurrentDirectory + @"\Replay\" + DateTime.Today + "-" + name + ".Map.txt", textMap);
        }

        public bool CanExecute()
        {
            return ReplayCollector.Instance.InitState != null;
        }
    }
}
