using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace INSAWORLD
{
    public class ReplayCollector
    {
        //collect actions for replay
        private ICollection<ToCollect> step = new List<ToCollect>(); //list of step
        private ToCollect initState; //creation of the game

        

        public ReplayCollector()
        {
            step = new List<ToCollect>();
            Directory.CreateDirectory(@Environment.CurrentDirectory + @"\Save");
            Directory.CreateDirectory(@Environment.CurrentDirectory + @"\Replay");
        }

        public ICollection<ToCollect> Step
        {
            get { return step; }
            set { step = value; }
        }

        public ToCollect InitState
        {
            get { return initState; }
            set { initState = value; }
        }

        /// <summary>
        /// collect a step
        /// </summary>
        public void AddStep(ToCollect c)
        {
            step.Add(c);
        }

        /// <summary>
        /// generate the text to save for the replay
        /// </summary>
        /// <returns>concat all string seen in ToCollect implem</returns>
        override
        public string ToString()
        {
            string res = initState.ToString(); //NewGameCommand string
            foreach(ToCollect tc in step) res += "\n" + tc.ToString(); //MoveUnit - AttackUnit - NextTurn strings
            return res;
        }

        /// <summary>
        /// generate text for the map
        /// </summary>
        /// <returns>same string as in NewGameCommand.ToStringMap</returns>
        public string ToStringMap()
        {
            return ((NewGameCommand) initState).ToStringMap();
        }

        /// <summary>
        /// execute all steps contained in step
        /// </summary>
        public void Replay()
        {
            foreach(ToCollect cmd in step)
            {
                cmd.ExecuteReplay();
            }
        }
    }
}
