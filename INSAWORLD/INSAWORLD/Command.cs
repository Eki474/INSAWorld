using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //command to link the rules to the UI
    public abstract class Command
    {
        //method : to save the game before it ends
        public bool Save()
        {
            throw new System.NotImplementedException();
        }
        //method : to reload a saved game
        public bool Load()
        {
            throw new System.NotImplementedException();
        }
        //method : to start a new game
        public bool NewGame()
        {
            throw new System.NotImplementedException();
        }
        //method : to exit the game
        public bool Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
