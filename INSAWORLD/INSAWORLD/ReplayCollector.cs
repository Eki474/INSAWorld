using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class ReplayCollector
    {
        //collect actions for replay
        private ICollection<ToCollect> step;
        private ToCollect initState;

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
        /// add a step to collect
        /// </summary>
        /// <returns>true if the step can be added, false if not</returns>
        public bool AddStep()
        {
            throw new NotImplementedException();
        }
    }
}
