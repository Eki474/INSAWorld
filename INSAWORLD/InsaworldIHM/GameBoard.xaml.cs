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
using INSAWORLD;

namespace InsaworldIHM
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Page
    {
        Game g;

        public GameBoard(ref Player p1, ref Player p2, int map)
        {
            InitializeComponent();
            g = new Game(ref p1, ref p2);
            g.Initialize(map);
        }

        private void next_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
