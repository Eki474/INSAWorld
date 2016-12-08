using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class ReplayCollector
    {
        private static ReplayCollector instance; 
        //collect actions for replay
        private ICollection<ToCollect> step = new List<ToCollect>();
        private ToCollect initState;

        public static ReplayCollector Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReplayCollector();
                }
                return instance;
            }
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
        /// add a step to collect
        /// </summary>
        public void AddStep(ToCollect c)
        {
            step.Add(c);
        }


    }
}
