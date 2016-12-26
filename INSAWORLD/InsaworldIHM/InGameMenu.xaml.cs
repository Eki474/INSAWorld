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

namespace InsaworldIHM
{
    /// <summary>
    /// Interaction logic for InGameMenu.xaml
    /// </summary>
    public partial class InGameMenu : Grid
    {
        Game game;
        public InGameMenu()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
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
    }
}
