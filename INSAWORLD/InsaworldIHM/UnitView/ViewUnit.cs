using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InsaworldIHM.UnitView
{
    public abstract partial class ViewUnit : Image
    {
        public abstract void Select();
        public abstract void Unselect();
    }
}
