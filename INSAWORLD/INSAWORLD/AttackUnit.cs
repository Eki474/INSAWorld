using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class AttackUnit : CommandMenu, ToCollect
    {
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
    
        /// <summary>
        /// a unit attack an other unit
        /// </summary>
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
