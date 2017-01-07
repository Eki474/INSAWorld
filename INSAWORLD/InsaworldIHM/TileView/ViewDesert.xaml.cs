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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsaworldIHM.TileView
{
    /// <summary>
    /// Logique d'interaction pour DesertView.xaml
    /// </summary>
    public partial class ViewDesert : ViewTile
    {
        Uri source;
        Uri sourceselected;


        /// <summary>
        /// constructor
        /// </summary>
        public ViewDesert() : base()
        {
            source = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/desert_reduced.jpg");
            sourceselected = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/desert_reduced_selected.jpg");
            Source = new BitmapImage(source);
        }

        /// <summary>
        /// to select a tile (give the good image to display)
        /// </summary>
        override
        public void Select()
        {
            Source = new BitmapImage(sourceselected);
        }

        /// <summary>
        /// to select a tile (give the good image to display)
        /// </summary>
        override
        public void Unselect()
        {
            Source = new BitmapImage(source);
        }

    }
}
