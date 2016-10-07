using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public abstract class Command
    {
        public bool Save()
        {
            throw new System.NotImplementedException();
        }

        public bool Load()
        {
            throw new System.NotImplementedException();
        }

        public bool NewGame()
        {
            throw new System.NotImplementedException();
        }

        public bool Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
