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
        }

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        private void replaySave_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SaveReplayWindow();
            newWindow.Game = game;
            newWindow.ShowDialog();
        }

        private void mainMenu_Click(object sender, RoutedEventArgs e)
        {
            var newPage = new MainPage();
            Application.Current.MainWindow.Content = newPage;
        }
    }
}
