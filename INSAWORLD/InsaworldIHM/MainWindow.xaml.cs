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
using INSAWORLD;

namespace InsaworldIHM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {

        private MediaPlayer soundPlayer = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            Content = new MainPage();
            soundPlayer.MediaEnded += new EventHandler(Media_Ended);
        }

        public MediaPlayer SoundPlayer
        {
            get { return soundPlayer; }
            set { soundPlayer = value; }
        }

        /// <summary>
        /// loops the music when ended
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Media_Ended(object sender, EventArgs e)
        {
            var media = (MediaPlayer)sender;
            media.Position = TimeSpan.Zero;
            media.Play();
        }
    }
}
