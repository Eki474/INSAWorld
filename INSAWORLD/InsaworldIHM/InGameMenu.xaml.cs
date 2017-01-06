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
            InitializeComponent();

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
