using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public interface ToCollect
    {
        //action collector for replay
        string TypeName
        {
            get;
        }
        string ToString();
        void ExecuteReplay();
    }
}
