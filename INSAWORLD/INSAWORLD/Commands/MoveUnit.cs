using System;
using System.Collections.Generic;
using System.Linq;

namespace INSAWORLD
{
    public class MoveUnit : CommandMenu, ToCollect
    {
        private string state;

        private Unit unit;
        private Coord dest;

        public MoveUnit(Unit u, Coord c)
        {
            unit = u;
            dest = c;
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }
    
        /// <summary>
        /// move a unit
        /// </summary>
        public void Execute()
        {
            ReplayCollector.Instance.AddStep(this);
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
