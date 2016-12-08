using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public interface CommandMenu
    {

        void Execute();
        bool CanExecute();
    }
}
