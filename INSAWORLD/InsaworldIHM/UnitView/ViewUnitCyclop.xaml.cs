using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace InsaworldIHM.UnitView
{
    /// <summary>
    /// Logique d'interaction pour ViewUnitCentaurs.xaml
    /// </summary>

    partial class ViewUnitCyclop : ViewUnit
    {
        Uri source; //image of the unit
        Uri sourceselected; //image when the unit is selected
        SoundPlayer player;//attack sound for the unit
        SoundPlayer deathplayer;//death sound for the unit

        /// <summary>
        /// constructor
        /// </summary>
        public ViewUnitCyclop() : base()
        {
            source = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png");
            sourceselected = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclopselected.jpg");
            Source = new BitmapImage(source);
            player = new SoundPlayer(InsaworldIHM.Properties.Resources.cyclops);
            deathplayer = new SoundPlayer(InsaworldIHM.Properties.Resources.cyclopDeath);
        }

        /// <summary>
        /// select unit
        /// </summary>
        override
        public void Select()
        {
            Source = new BitmapImage(sourceselected);
        }

        /// <summary>
        /// unselect unit
        /// </summary>
        override
        public void Unselect()
        {
            Source = new BitmapImage(source);
        }

        /// <summary>
        /// attack sound play
        /// </summary>
        public override void Play()
        {
            player.Play();
        }

        /// <summary>
        /// death sound play
        /// </summary>
        public override void DeathPlay()
        {
            deathplayer.Play();
        }
    }
}



