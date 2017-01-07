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

namespace InsaworldIHM
{
    /// <summary>
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        /// <summary>
        /// constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            mainWindow.SoundPlayer.Open(new Uri(@Environment.CurrentDirectory + @"\Ressources\sounds\start.mp3"));
            mainWindow.SoundPlayer.Play();
        }

        /// <summary>
        /// to create a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            RaceChoice page = new RaceChoice(this);
            mainWindow.Content = page;
        }

        /// <summary>
        /// to exit the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// to read a replay of a game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replay_Click(object sender, RoutedEventArgs e)
        {
            var page = new ReplayChoice(this);
            mainWindow.Content = page;
        }

        /// <summary>
        /// to load a game saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load_Click(object sender, RoutedEventArgs e)
        {
            var page = new SaveChoice(this);
            mainWindow.Content = page;
        }
    }
}
