using INSAWORLD;
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
using System.Windows.Shapes;
using System.Media;
using System.Windows.Resources;

namespace InsaworldIHM
{
    /// <summary>
    /// Interaction logic for InGameMenu.xaml
    /// </summary>
    public partial class InGameMenu : Grid
    {
        Game game;
        SoundPlayer player;
        public InGameMenu()
        {

            /*
             Uri uri = new Uri(@"pack://application:,,,/MyAssembly;component/Sounds/10meters.wav");
StreamResourceInfo sri = Application.GetResourceStream(uri);
SoundPlayer simpleSound = new SoundPlayer(sri.Stream);
simpleSound.Play();
             */
            InitializeComponent();
            Uri uri = new Uri(@"pack://application:,,,/InsaworldIHM;component/Ressources/sounds/menu_song.wav");
            StreamResourceInfo sri = Application.GetResourceStream(uri);
            player = new SoundPlayer(sri.Stream);
            //player.Load();
            player.Play();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            player.Stop();
        }

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SaveWindow();
            newWindow.Game = game;
            newWindow.ShowDialog();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            var page = new MainPage();
            Application.Current.MainWindow.Content= page;
        }

        private void saveReplay_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SaveReplayWindow();
            newWindow.Game = game;
            newWindow.ShowDialog();
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
