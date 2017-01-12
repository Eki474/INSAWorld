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
        /// select a tile to attack
        /// </summary>
        public abstract void SelectAttack();

        /// <summary>
        /// select a tile to move to
        /// </summary>
        public abstract void SelectMove();

        /// <summary>
        /// unselect a tile
        /// </summary>
        public abstract void Unselect();
    }
}
