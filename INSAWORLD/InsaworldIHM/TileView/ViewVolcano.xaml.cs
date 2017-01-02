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
    public partial class ViewVolcano : ViewTile
    {
        Uri source; Uri sourceselected;
        public ViewVolcano() : base()
        {
            source = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/volcano_reduced.jpg");
            sourceselected = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/volcano_reduced_selected.jpg");
            Source = new BitmapImage(source);
        }
        override
        public void Select()
        {
            Source = new BitmapImage(sourceselected);
        }
        override
        public void Unselect()
        {
            Source = new BitmapImage(source);
        }


    }
}
