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
    public partial class ViewSwamp : ViewTile
    {
        Uri source; Uri sourceselected; Uri sourceselectedCanMove; Uri sourceselectedAttack;

        /// <summary>
        /// constructor
        /// </summary>
        public ViewSwamp() : base()
        {
            source = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/swamp_reduced.png");
            sourceselected = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/swamp_reduced_selected.jpg");
            sourceselectedCanMove = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/swamp_reduced_selected_can_move.jpg");
            sourceselectedAttack = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/swamp_reduced_selected_attack.jpg");
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

        public override void SelectAttack()
        {
            Source = new BitmapImage(sourceselectedAttack);
        }

        public override void SelectMove()
        {
            Source = new BitmapImage(sourceselectedCanMove);
        }


    }
}
