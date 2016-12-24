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
using System.Windows.Controls.Primitives;

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
        int turn;
        Unit selected = null;
        Dictionary<Unit,Image> unitToImage;
        Grid container;
        List<Unit> unitsToSelect;

        public GameBoard(ref Player p1, ref Player p2, int map)
        {
            InitializeComponent();
            turn = 1;
            g = new Game(ref p1, ref p2);
            new NewGameCommand(g, map).Execute();
            Grid.SetColumn(map_view, 1);
            board.Children.Add(map_view);
            GenerateMapView();
            map_view.MouseDown += map_viewMouseDown;
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
            unitToImage = new Dictionary<Unit, Image>();
            var c1 = g.Player1.UnitsList.First();
            string r1 = g.Player1.RacePlay.Type;
            var c2 = g.Player2.UnitsList.First();
            string r2 = g.Player2.RacePlay.Type;
            for (int i = 0; i < g.Player1.UnitsList.Count; i++)
            {
                Image u1 = new Image();
                unitToImage.Add(g.Player1.UnitsList[i], u1);
                u1.Stretch = Stretch.Uniform;
                u1.Source = selectImageRace(r1);
                Grid.SetColumn(u1, c1.C.Y);
                Grid.SetRow(u1, c1.C.X);
                map_view.Children.Add(u1);

                Image u2 = new Image();
                unitToImage.Add(g.Player2.UnitsList[i], u2);
                u2.Stretch = Stretch.Uniform;
                u2.Source = selectImageRace(r2);
                Grid.SetColumn(u2, c2.C.Y);
                Grid.SetRow(u2, c2.C.X);
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
            }
            else if (g.Player2.Playing)
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
            var cmd = new NextTurn(g);
            if (cmd.CanExecute())
            {
                cmd.Execute();
                ExchangePlayers();
                double d = g.Map.NbTurn * 2;
                if (d % 2 == 0)
                {
                    turn++;
                    turn_number.Text = "Turn " + turn;
                }
            }
            else
            {
                next_button.IsEnabled = false;
                bool winner = false; //true --> PLayer 1 wins, false --> Player 2 wins
                g.Player1.ComputePoints(ref g);
                g.Player2.ComputePoints(ref g);
                if (g.Player2.Lost() || g.Player1.Points > g.Player2.Points) winner = true;
                mainWindow.Content = new EndingPage(winner);
            }
        }

        private void ExchangePlayers()
        {
            g.Player1.ComputePoints(ref g);
            g.Player2.ComputePoints(ref g);
            if (g.Player1.Name == current_player_name.Text)
            {
                adversary_name.Text = g.Player1.Name;
                adversary_points.Text = "Points : " + g.Player1.Points;
                current_player_name.Text = g.Player2.Name;
                nb_unit.Text = "Number of units available : " + g.Player2.UnitsList.Count;
                nb_points.Text = "Number of points : " + g.Player2.Points;
            }
            else if (g.Player2.Name == current_player_name.Text)
            {
                adversary_name.Text = g.Player2.Name;
                adversary_points.Text = "Points : " + g.Player2.Points;
                current_player_name.Text = g.Player1.Name;
                nb_unit.Text = "Number of units available : " + g.Player1.UnitsList.Count;
                nb_points.Text = "Number of points : " + g.Player1.Points;
            }
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            InGameMenu page = new InGameMenu();
            mainWindow.Content = page;
        }

        private void map_viewMouseDown(object sender, RoutedEventArgs e)
        {
           // if (object.ReferenceEquals(selected, null))
           // {
                selectUnitClick(sender, e);
           // }
        }

        private void selectUnitClick(object sender, RoutedEventArgs e)
        {
            var element = (UIElement)e.Source;
            int x = Grid.GetRow(element);
            int y = Grid.GetColumn(element);
            
            Coord actual = new INSAWORLD.Coord(x, y);
            bool found = false;
            unitsToSelect = new List<Unit>();
            foreach (Unit u in g.Player1.UnitsList)
            {
                if (u.C.Equals(actual))
                {
                    found = true;
                    unitsToSelect.Add(u);
                }
            }
            if (!found)
            {
                foreach (Unit u in g.Player2.UnitsList)
                {
                    if (u.C.Equals(actual))
                    {
                        found = true;
                        unitsToSelect.Add(u);
                    }
                }
            }
            if (!found) return;
            if (unitsToSelect.Count == 1)
            {
                select(unitsToSelect.First());
                return;
            }
            Race r = unitsToSelect.First().Race;
            container = new Grid();
            for (int i = 0; i < unitsToSelect.Count; i++) {
                var c = new ColumnDefinition();
                c.Width = new GridLength(1, GridUnitType.Star);
                container.ColumnDefinitions.Add(c);
                Image image = new Image();
                image.Stretch = Stretch.Uniform;
                image.MouseDown += selectThisUnit;
                image.Source = selectImageRace(r.Type);
                Grid.SetColumn(image, i);
                container.Children.Add(image);
            }
            int taille = (map_view.ColumnDefinitions.Count/2) -1;
            Grid.SetColumn(container,taille);
            Grid.SetRow(container, taille);
            Grid.SetColumnSpan(container, taille);
            Grid.SetRowSpan(container, taille);
            container.Background = Brushes.White;
            container.HorizontalAlignment = HorizontalAlignment.Center;
            container.VerticalAlignment= VerticalAlignment.Center;
            map_view.Children.Add(container);

        }

        private BitmapImage selectImageRace(String r)
        {
            
            switch (r)
            {
                case "Centaurs":
                    return new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaur.png"));
                case "Cyclops":
                    return new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png"));
                case "Cerberus":
                    return new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberus.png"));
            }
            return null;
            
        }

        private void select(Unit u)
        {
            if(!object.ReferenceEquals(selected, null))
            {
                unitToImage[selected].Source = selectImageRace(selected.Race.Type);
            }
            selected = u;

            unitToImage[selected].BringIntoView();
            unitToImage[selected].Source = selectImageSelectedRace(u.Race.Type);

            selected_unit_spec.Text = "Race " + u.Race.Type + "\n Attack : " + u.Race.Attack + "\n Defense : " + "0 \n Life : " + u.LifePoints + " \n Move : " + u.MovePoints;

            selected_unit_spec_viewbox.Visibility = Visibility.Visible;
        }

        private void selectThisUnit(object sender, RoutedEventArgs e)
        {
            var element = (UIElement)e.Source;
            int position = Grid.GetRow(element);
            map_view.Children.Remove(container);
            container = null;
            select(unitsToSelect[position]);
            e.Handled = true;

        }

        private BitmapImage selectImageSelectedRace(String r)
        {
            switch (r)
            {
                case "Centaurs":
                    return new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaurselected.jpg"));
                    
                case "Cyclops":
                    return  new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclopselected.jpg"));
                    
                case "Cerberus":
                    return new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberusselected.jpg"));
                    
            }
            return null;
        }
    }
}
