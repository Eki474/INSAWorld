using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InsaworldIHM.TileView
{
    public abstract class ViewTile : Image
    {
        public abstract void Select();
        public abstract void Unselect();


    }
}
