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

        /// <summary>
        /// constructor
        /// </summary>
        public InGameMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// handler for abck button (back to game)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// game getter / setter
        /// </summary>
        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        /// <summary>
        /// handler for save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SaveWindow();
            newWindow.Game = game;
            newWindow.ShowDialog();
        }

        /// <summary>
        /// handler for the main menu button (go back to title screen)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load_Click(object sender, RoutedEventArgs e)
        {
            var page = new MainPage();
            Application.Current.MainWindow.Content= page;
            InsaworldIHM.MainWindow m =(MainWindow)Application.Current.MainWindow;
        }

        /// <summary>
        /// handler for save a replay button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveReplay_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SaveReplayWindow();
            newWindow.Game = game;
            newWindow.ShowDialog();
        }

        /// <summary>
        /// handler to quit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
