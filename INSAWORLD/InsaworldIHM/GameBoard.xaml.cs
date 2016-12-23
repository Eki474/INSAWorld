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
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        Game g;
        Grid map_view = new Grid();
        double maxTurn;

        public GameBoard(ref Player p1, ref Player p2, int map)
        {
            InitializeComponent();
            g = new Game(ref p1, ref p2);
            var cmd = new NewGameCommand(g, map);
            if (cmd.CanExecute()) cmd.Execute();
            Grid.SetColumn(map_view, 1);
            board.Children.Add(map_view);
            GenerateMapView();
            UnitsInitialization();
            GenerateLeftSideView();
            mainWindow.Content = board;
        }

        private void GenerateMapView()
        {
            int map_size = g.Map.Taille;
            for (int i = 0; i < map_size; i++)
            {
                var c = new ColumnDefinition();
                c.Width = new GridLength(1, GridUnitType.Star);
                map_view.ColumnDefinitions.Add(c);
                var r = new RowDefinition();
                r.Height = new GridLength(1, GridUnitType.Star);
                map_view.RowDefinitions.Add(r);
            }

            for (int j = 0; j < map_size; j++)
            {
                for (int k = 0; k < map_size; k++)
                {
                    string t = g.Map.CasesJoueur[new Coord(j, k)].getType();
                    Image img = new Image();
                    img.Stretch = Stretch.UniformToFill;
                    switch (t)
                    {
                        case "plain":
                            img.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/plain_reduced.png"));
                            break;
                        case "volcano":
                            img.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/volcano_reduced.jpg"));
                            break;
                        case "swamp":
                            img.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/swamp_reduced.png"));
                            break;
                        case "desert":
                            img.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/desert_reduced.jpg"));
                            break;
                    }
                    Grid.SetColumn(img, j);
                    Grid.SetRow(img, k);
                    map_view.Children.Add(img);
                }
            }
        }

        private void UnitsInitialization()
        {
            var c1 = g.Player1.UnitsList.First();
            string r1 = g.Player1.RacePlay.Type;
            var c2 = g.Player2.UnitsList.First();
            string r2 = g.Player2.RacePlay.Type;
            for (int i = 0; i < g.Player1.UnitsList.Count; i++)
            {
                Image u1 = new Image();
                u1.Stretch = Stretch.Uniform;
                switch (r1)
                {
                    case "Centaurs":
                        u1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaur.png"));
                        break;
                    case "Cyclops":
                        u1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png"));
                        break;
                    case "Cerberus":
                        u1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberus.png"));
                        break;
                }
                Grid.SetColumn(u1, c1.C.X);
                Grid.SetRow(u1, c1.C.Y);
                map_view.Children.Add(u1);

                Image u2 = new Image();
                u2.Stretch = Stretch.Uniform;
                switch (r2)
                {
                    case "Centaurs":
                        u2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaur.png"));
                        break;
                    case "Cyclops":
                        u2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png"));
                        break;
                    case "Cerberus":
                        u2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberus.png"));
                        break;
                }
                Grid.SetColumn(u2, c2.C.X);
                Grid.SetRow(u2, c2.C.Y);
                map_view.Children.Add(u2);
            }
        }

        private void GenerateLeftSideView()
        {
            maxTurn = g.Map.NbTurn;
            if (g.Player1.Playing)
            {
                current_player_name.Text = g.Player1.Name;
                nb_unit.Text = "Number of units available : " + g.Player1.UnitsList.Count;
                nb_points.Text = "Number of points : 0";
                adversary_name.Text = g.Player2.Name;
                adversary_points.Text = "Points : 0";
            }else if (g.Player2.Playing)
            {
                current_player_name.Text = g.Player2.Name;
                nb_unit.Text = "Number of units available : " + g.Player2.UnitsList.Count;
                nb_points.Text = "Number of points : 0";
                adversary_name.Text = g.Player1.Name;
                adversary_points.Text = "Points : 0";
            }
        }

        private void next_button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            InGameMenu page = new InGameMenu();
            mainWindow.Content = page;
        }
    }
}
