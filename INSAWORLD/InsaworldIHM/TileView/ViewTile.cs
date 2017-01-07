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
        /// <summary>
        /// select a tile
        /// </summary>
        public abstract void Select();
        /// <summary>
        /// unselect a tile
        /// </summary>
        public abstract void Unselect();
    }
}
