using System;

namespace INSAWORLD
{
    public class MoveUnit : CommandMenu, ToCollect
    {
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
    
        /// <summary>
        /// move a unit
        /// </summary>
        public Array Execute()
        {
            throw new NotImplementedException();
        }
    }
}
