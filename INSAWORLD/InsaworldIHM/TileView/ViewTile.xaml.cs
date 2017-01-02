using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsaworldIHM.TileView
{
    /// <summary>
    /// Logique d'interaction pour TileView.xaml
    /// </summary>
    public abstract partial class ViewTile : Image
    {

        Uri source;
        Uri sourceselected;
        public ViewTile() : base()
        {
            Source = new BitmapImage(source);
        }
        public abstract void Select();
        public abstract void UnSelect();
    }
}
