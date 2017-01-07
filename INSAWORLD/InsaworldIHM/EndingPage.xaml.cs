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
    /// Interaction logic for EndingPage.xaml
    /// </summary>
    public partial class EndingPage : Page
    {
        private Game game;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="winner">true : Player 1 wins - false Player 2 wins</param>
        /// <param name="p1">Player 1</param>
        /// <param name="p2">Player 2</param>
        public EndingPage(bool winner, Player p1, Player p2)
        {
            InitializeComponent();
            if (winner)
            {
                winName.Text = p1.Name;
                winPoints.Text = "Points : "+p1.Points;
                lostName.Text = p2.Name;
                lostPoints.Text = "Points : " + p2.Points;
            }else
            {
                winName.Text = p2.Name;
                winPoints.Text = "Points : " + p2.Points;
                lostName.Text = p1.Name;
                lostPoints.Text = "Points : " + p1.Points;
            }

            InsaworldIHM.MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.SoundPlayer.Open(new Uri(@Environment.CurrentDirectory + @"\Ressources\sounds\victory.mp3"));
            mainWindow.SoundPlayer.Play();
        }

        /// <summary>
        /// Game getter and setter
        /// </summary>
        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        /// <summary>
        /// To save replay of the complete game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replaySave_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SaveReplayWindow();
            newWindow.Game = game;
            newWindow.ShowDialog();
        }

        /// <summary>
        /// To go to the main main on the start page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMenu_Click(object sender, RoutedEventArgs e)
        {
            var newPage = new MainPage();
            Application.Current.MainWindow.Content = newPage;
            InsaworldIHM.MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        }
    }
}
