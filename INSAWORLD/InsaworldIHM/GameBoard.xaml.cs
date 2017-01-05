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
using InsaworldIHM.TileView;

namespace InsaworldIHM
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        Game g;
        double maxTurn;
        int turn;
        Unit selected = null;
        Dictionary<Unit, Image> unitToImage;
        Dictionary<Coord, TileView.ViewTile> coordToTileView;
        List<Coord> selectedImage = new List<Coord>();
        Grid container = null;
        List<Unit> unitsToSelect;

        /// <summary>
        /// constructor, create the game
        /// </summary>
        /// <param name="p1">player 1</param>
        /// <param name="p2">player 2</param>
        /// <param name="map">map type</param>
        public GameBoard(ref Player p1, ref Player p2, int map)
        {
            InitializeComponent();
            turn = 1;
            g = new Game(ref p1, ref p2);
            new NewGameCommand(g, map).Execute();
            GenerateMapView();
            map_view.MouseLeftButtonDown += map_viewLeftDown;
            map_view.MouseRightButtonDown += map_viewRightDown;
            inGameMenuGrid.Game = g;
            UnitsInitialization();
            GenerateLeftSideView();
            mainWindow.Content = board;
        }

        /// <summary>
        /// constructor, load a game
        /// </summary>
        /// <param name="game">loaded game</param>
        public GameBoard(ref Game game, bool replayGame)
        {
            InitializeComponent();
            turn = 1;
            g = game;
            GenerateMapView();
            inGameMenuGrid.Game = g;
            UnitsPlacement();
            UpdateLeftSideView();
            mainWindow.Content = board;
            if (replayGame)
            {
                ReplayAsync();
            }else
            {
                map_view.MouseLeftButtonDown += map_viewLeftDown;
                map_view.MouseRightButtonDown += map_viewRightDown;
            }
        }

        private async void ReplayAsync()
        {
            next_button.Visibility = Visibility.Hidden;
            await Task.Delay(1000);
            foreach(ToCollect cmd in g.Rpz.Step)
            {
                cmd.ExecuteReplay();
                UpdateUnitsPlacement();
                UpdateRecapTabReplay();//TODO: recap on left side view
                await Task.Delay(1000);
            }
            next_button_Click(null, null);
            next_button.Visibility = Visibility.Visible;
        }

        private void UpdateUnitsPlacement()
        {
            Unit toErase = null;
            foreach (Unit u in unitToImage.Keys)
            {
                Image u1 = unitToImage[u];
                if (u.LifePoints != 0)
                {
                    Grid.SetColumn(u1, u.C.Y);
                    Grid.SetRow(u1, u.C.X);
                }
                else toErase = u;
            }
            if (!object.ReferenceEquals(null, toErase))
            {
                Image u1 = unitToImage[toErase];
                map_view.Children.Remove(u1);
                u1 = null;
                unitToImage.Remove(toErase);
            }
        }

        /// <summary>
        /// generate the view of the map 
        /// </summary>
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
            coordToTileView = new Dictionary<Coord, TileView.ViewTile>();
            for (int j = 0; j < map_size; j++)
            {
                for (int k = 0; k < map_size; k++)
                {
                    string t = g.Map.CasesJoueur[new Coord(j, k)].getType();
                    TileView.ViewTile img;

                    switch (t)
                    {
                        case "plain":
                            img = new ViewPlain();
                            break;
                        case "volcano":
                            img = new ViewVolcano();
                            break;
                        case "swamp":
                            img = new ViewSwamp();
                            break;
                        case "desert":
                            img = new ViewDesert();
                            break;
                        default: throw new Exception("Tile not recognized");
                    }
                    img.Stretch = Stretch.Fill;
                    coordToTileView.Add(new Coord(j, k), img);
                    Grid.SetColumn(img, k);
                    Grid.SetRow(img, j);
                    map_view.Children.Add(img);
                }
            }
        }

        /// <summary>
        /// initial units placements on the map
        /// </summary>
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

        /// <summary>
        /// units placements on the map (used to load a save)
        /// </summary>
        private void UnitsPlacement()
        {
            unitToImage = new Dictionary<Unit, Image>();
            string r1 = g.Player1.RacePlay.Type;
            string r2 = g.Player2.RacePlay.Type;
            foreach (Unit u in g.Player1.UnitsList)
            {
                Image u1 = new Image();
                unitToImage.Add(u, u1);
                u1.Stretch = Stretch.Uniform;
                u1.Source = selectImageRace(r1);
                Grid.SetColumn(u1, u.C.Y);
                Grid.SetRow(u1, u.C.X);
                map_view.Children.Add(u1);
            }
            foreach (Unit u in g.Player2.UnitsList)
            {
                Image u2 = new Image();
                unitToImage.Add(u, u2);
                u2.Stretch = Stretch.Uniform;
                u2.Source = selectImageRace(r2);
                Grid.SetColumn(u2, u.C.Y);
                Grid.SetRow(u2, u.C.X);
                map_view.Children.Add(u2);
            }
        }

        /// <summary>
        /// dynamic generation of the left view (players names, points, units...)
        /// </summary>
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

        /// <summary>
        /// generate the left side view when a game is loaded
        /// </summary>
        private void UpdateLeftSideView()
        {
            maxTurn = BuilderMap.Instance.getMaxTurn(g.Map.Taille);
            turn_number.Text = "Turn " + (int) (maxTurn - g.Map.NbTurn + 1);
            g.Player1.ComputePoints(ref g);
            g.Player2.ComputePoints(ref g);
            if (g.Player1.Playing)
            {
                current_player_name.Text = g.Player1.Name;
                nb_unit.Text = "Number of units available : " + g.Player1.UnitsList.Count;
                nb_points.Text = "Number of points : " + g.Player1.Points;
                adversary_name.Text = g.Player2.Name;
                adversary_points.Text = "Points : " + g.Player2.Points;
            }
            else if (g.Player2.Playing)
            {
                current_player_name.Text = g.Player2.Name;
                nb_unit.Text = "Number of units available : " + g.Player2.UnitsList.Count;
                nb_points.Text = "Number of points : " + g.Player2.Points;
                adversary_name.Text = g.Player1.Name;
                adversary_points.Text = "Points : " + g.Player1.Points;
            }
        }

        private void UpdateRecapTabReplay()
        {
            maxTurn = BuilderMap.Instance.getMaxTurn(g.Map.Taille);
            turn_number.Text = "Turn " + (int)(maxTurn - g.Map.NbTurn + 1);
            g.Player1.ComputePoints(ref g);
            g.Player2.ComputePoints(ref g);
            if (g.Player1.Playing)
            {
                current_player_name.Text = g.Player1.Name;
                nb_unit.Text = "Number of units available : " + g.Player1.UnitsList.Count;
                nb_points.Text = "Number of points : " + g.Player1.Points;
                adversary_name.Text = g.Player2.Name;
                adversary_points.Text = "Points : " + g.Player2.Points;
            }
            else if (g.Player2.Playing)
            {
                current_player_name.Text = g.Player2.Name;
                nb_unit.Text = "Number of units available : " + g.Player2.UnitsList.Count;
                nb_points.Text = "Number of points : " + g.Player2.Points;
                adversary_name.Text = g.Player1.Name;
                adversary_points.Text = "Points : " + g.Player1.Points;
            }
            int size = g.Player2.UnitsList.Count;
            if (g.Player1.UnitsList.Count < size) size = g.Player1.UnitsList.Count;
            string recapP1 = g.Player1.Name+"'s units \n";
            string recapP2 = g.Player2.Name+"'s units \n";
            int j = 0;
            foreach(Unit u in g.Player1.UnitsList)
            {
                recapP1 += "HP : " + u.LifePoints + " - Move : " + u.MovePoints;
                if (j != size) recapP1 += "\n";
                j++;
            }
            j = 0;
            foreach(Unit v in g.Player2.UnitsList)
            {
                recapP2 += "HP : " + v.LifePoints + " - Move : " + v.MovePoints;
                if (j != size) recapP2 += "\n";
                j++;
            }
            recap_p1_replay.Text = recapP1;
            recap_p2_replay.Text = recapP2;
            recap_p1_replay_viewbox.Visibility = Visibility.Visible;
            recap_p2_replay_viewbox.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// handler for the next turn button : launch NextTurn command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_button_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new NextTurn(g);

            unselect();
            if (!object.ReferenceEquals(container, null))
            {
                map_view.Children.Remove(container);
                container = null;
            }
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
                var page = new EndingPage(winner, g.Player1, g.Player2);
                page.Game = g;
                mainWindow.Content = page;
            }
        }

        /// <summary>
        /// exchange the players place inside view (on the left side)
        /// </summary>
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

        /// <summary>
        /// handler for the menu button : display menu popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Effects.BlurEffect objBlur =
                                 new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 10;
            map_view.Effect = objBlur;
            Specs.Effect = objBlur;
            inGameMenuGrid.BringIntoView();
            inGameMenuGrid.Visibility = Visibility.Visible;
            // InGameMenu page = new InGameMenu();
            // mainWindow.Content = page;
        }

        /// <summary>
        /// handle right clic on map : deselect what's selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void map_viewRightDown(object sender, RoutedEventArgs e)
        {
            unselect();
            updateTextSpec();
        }

        /// <summary>
        /// unselect image : change view of the unit from selected to unselected
        /// </summary>
        private void unselect()
        {
            if (!object.ReferenceEquals(selected, null) && selected.LifePoints > 0)
            {
                unitToImage[selected].Source = selectImageRace(selected.Race.Type);
            }
            selected = null;
    
            unselectTiles();
        }

        /// <summary>
        /// handle selection of unit : change view + handle move + handle attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void map_viewLeftDown(object sender, RoutedEventArgs e)
        {
            //If we're already selecting a unit, close the appropriate container
            if (!object.ReferenceEquals(container, null))
            {
                map_view.Children.Remove(container);
                container = null;
                return;
            }
            Player playing; Player notPlaying;
            if (g.Player1.Playing) { playing = g.Player1; notPlaying = g.Player2; }
            else { playing = g.Player2; notPlaying = g.Player1; }

            //If no unit is selected try to select one
            if (object.ReferenceEquals(selected, null))
            {
                selectUnitClick(sender, e, playing);
            }
            else
            {
                //Get the clicked tile's position
                var element = (UIElement)e.Source;
                int x = Grid.GetRow(element);
                int y = Grid.GetColumn(element);
                Coord actual = new Coord(x, y);

                //Check if there's a unit in the tile
                //TODO select unit with max life
                bool found = false;
                var unitToAttack = new List<Unit>();
                foreach (Unit u in notPlaying.UnitsList)
                {
                    if (u.C.Equals(actual) && u.LifePoints > 0)
                    {
                        found = true;
                        unitToAttack.Add(u);
                        break;
                    }
                }
                //If no unit on the tile we move
                if (!found) moveUnit(actual);
                //else we attack the unit if the selected unit hasn't attacked yet
                else if (!selected.Played)
                {
                    int lifeMax = 0;
                    foreach (Unit t in unitToAttack)
                    {
                        if (t.LifePoints > lifeMax)
                        {
                            lifeMax = t.LifePoints;
                        }
                    }
                    foreach (Unit d in unitToAttack)
                    {
                        if (d.LifePoints < lifeMax)
                        {
                            unitToAttack.Remove(d);
                        }
                    }
                    Random rnd = new Random();
                    int target = rnd.Next(0, unitToAttack.Count);
                    attackUnit(unitToAttack[target]);
                }
                updateTextSpec();
            }
        }

        /// <summary>
        /// handle attack on another unit and remove dead unit if any
        /// </summary>
        /// <param name="u"></param>
        private void attackUnit(Unit u)
        {
            var cmd = new AttackUnit(selected, u, ref g);
            if (cmd.CanExecute()) cmd.Execute();

            //If the attacker dies remove its view
            if (selected.LifePoints == 0)
            {
                Image i = unitToImage[selected];
                map_view.Children.Remove(i);
                i = null;
                unitToImage.Remove(selected);
                unselect();
            }
            //If the defender dies remove its view then update the attacker coordinates
            if (u.LifePoints == 0)
            {
                Image i = unitToImage[u];
                map_view.Children.Remove(i);
                i = null;
                unitToImage.Remove(u);
                updateCoord();
                unselect();
            }
        }

        /// <summary>
        /// handle move to coord for the selected unit
        /// </summary>
        /// <param name="coord">coord to move to</param>
        private void moveUnit(Coord coord)
        {
            var cmd = new MoveUnit(selected, coord, ref g);
            if (cmd.CanExecute())
            {
                cmd.Execute();
                updateCoord();
            }
            unselectTiles();
            suggestMoveTile();
        }

        /// <summary>
        /// handle view of the deplacement of a unit
        /// </summary>
        private void updateCoord()
        {
            Image i = unitToImage[selected];
            Grid.SetColumn(i, selected.C.Y);
            Grid.SetRow(i, selected.C.X);
        }

        public Image getImageToUnit(Unit u)
        {
            return unitToImage[u];
        }

        /// <summary>
        /// handle selection of a unit whether there are one or more units on the tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="p">player currently playing</param>
        private void selectUnitClick(object sender, RoutedEventArgs e, Player p)
        {
            //Get click's coordinates
            var element = (UIElement)e.Source;
            int x = Grid.GetRow(element);
            int y = Grid.GetColumn(element);
            Coord actual = new Coord(x, y);

            //Check if there's a unit
            bool found = false;
            unitsToSelect = new List<Unit>();
            foreach (Unit u in p.UnitsList)
            {
                if (u.C.Equals(actual) && u.LifePoints > 0)
                {
                    found = true;
                    unitsToSelect.Add(u);
                }
            }

            if (!found) return;

            //If only one unit 
            if (unitsToSelect.Count == 1)
            {
                select(unitsToSelect.First());
                return;
            }

            //If multiple units
            Race r = unitsToSelect.First().Race;
            //Will contain the image of the units to select
            container = new Grid();
            var row = new RowDefinition();
            row.Height = new GridLength(9, GridUnitType.Star);
            container.RowDefinitions.Add(row);
            row = new RowDefinition();
            row.Height = new GridLength(1, GridUnitType.Star);
            container.RowDefinitions.Add(row);
            //In order to show lifepoints
            int maxLifePoints = r.Life;
            //Adds the units and their lifepoints to the container
            for (int i = 0; i < unitsToSelect.Count; i++)
            {
                var c = new ColumnDefinition();
                c.Width = new GridLength(1, GridUnitType.Star);
                container.ColumnDefinitions.Add(c);
                Image image = new Image();
                image.Stretch = Stretch.Uniform;
                image.MouseDown += selectThisUnit;
                image.Source = selectImageRace(r.Type);
                Grid.SetColumn(image, i);
                Grid.SetRow(image, 0);
                //display life points bar
                Grid life = new Grid();
                c = new ColumnDefinition();
                c.Width = new GridLength(unitsToSelect[i].LifePoints, GridUnitType.Star);
                life.ColumnDefinitions.Add(c);
                c = new ColumnDefinition();
                c.Width = new GridLength(maxLifePoints - unitsToSelect[i].LifePoints, GridUnitType.Star);
                life.ColumnDefinitions.Add(c);
                Rectangle rect = new Rectangle();
                rect.Fill = Brushes.Green;
                //rect.MinHeight = 10;
                rect.HorizontalAlignment = HorizontalAlignment.Stretch;
                rect.VerticalAlignment = VerticalAlignment.Stretch;
                life.Background = Brushes.Black;
                life.ShowGridLines = true;
                rect.Margin = new Thickness(1, 0, 1, 0);
                Grid.SetColumn(rect, 0);
                life.Children.Add(rect);
                Grid.SetColumn(life, i);
                Grid.SetRow(life, 1);

                container.Children.Add(image);
                container.Children.Add(life);
            }
            //Show the container in the middle of the map
            int taille = (map_view.ColumnDefinitions.Count / 2) - 1;
            Grid.SetColumn(container, taille);
            Grid.SetRow(container, taille);
            Grid.SetColumnSpan(container, taille);
            Grid.SetRowSpan(container, taille);

            container.Background = Brushes.White;
            //Could change for center depending on taste
            container.HorizontalAlignment = HorizontalAlignment.Stretch;
            container.VerticalAlignment = VerticalAlignment.Stretch;
            map_view.Children.Add(container);

        }

        /// <summary>
        /// associate a selected unit to its view
        /// </summary>
        /// <param name="r">race of the unit</param>
        /// <returns>selected image function of the race</returns>
        private BitmapImage selectImageRace(string r)
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

        /// <summary>
        /// select unit on grid and update its view
        /// </summary>
        /// <param name="u"></param>
        private void select(Unit u)
        {
            if (!object.ReferenceEquals(selected, null))
            {
                unselect();
            }
            selected = u;

            unitToImage[selected].BringIntoView();
            unitToImage[selected].Source = selectImageSelectedRace(u.Race.Type);
            suggestMoveTile();
            updateTextSpec();
        }

        private void suggestMoveTile()
        {
            var listString = BuilderMap.Instance.suggestMove(ref g, selected);
            selectedImage = new List<Coord>();

            if (!object.ReferenceEquals(listString, null))
            {
                coordToTileView[selected.C].Select();
                selectedImage.Add(selected.C);
                // déplacement: 0 -> 1 <- 2 î 3 V
                foreach (String s in listString)
                {
                    Coord it = selected.C;
                    foreach (String p in s.Split(','))
                    {
                        switch (p)
                        {
                            case "0":
                                it = new Coord(it.X+1, it.Y ); break;
                            case "1":
                                it = new Coord(it.X-1, it.Y); break;
                            case "2":
                                it = new Coord(it.X, it.Y+1); break;
                            case "3":
                                it = new Coord(it.X, it.Y-1); break;
                            default: throw new Exception("bad move suggestion");
                        }
                        coordToTileView[it].Select();
                        selectedImage.Add(it);
                    }
                }
            }
        }

        private void unselectTiles()
        {
            foreach(Coord c in selectedImage)
            {
                coordToTileView[c].Unselect();
            }
        }


        /// <summary>
        /// display spec of the selected unit
        /// </summary>
        private void updateTextSpec()
        {
            if (object.ReferenceEquals(selected, null)) selected_unit_spec_viewbox.Visibility = Visibility.Hidden;
            else
            {
                selected_unit_spec.Text = "Race " + selected.Race.Type + "\n Attack : " + selected.Race.Attack + "\n Defense : " + selected.Race.Defense + "\n Life : " + selected.LifePoints + " \n Move : " + selected.MovePoints;

                selected_unit_spec_viewbox.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// select a unit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectThisUnit(object sender, RoutedEventArgs e)
        {
            var element = (UIElement)e.Source;
            int position = Grid.GetColumn(element);
            map_view.Children.Remove(container);
            select(unitsToSelect[position]);
            e.Handled = true;

        }



        /// <summary>
        /// associate a unselected unit to its view
        /// </summary>
        /// <param name="r"></param>
        /// <returns>selected image function of the race</returns>
        private BitmapImage selectImageSelectedRace(string r)
        {
            switch (r)
            {
                case "Centaurs":
                    return new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaurselected.jpg"));

                case "Cyclops":
                    return new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclopselected.jpg"));

                case "Cerberus":
                    return new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberusselected.jpg"));

            }
            return null;
        }

        /// <summary>
        /// to remove blur on menu closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeBlur(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (inGameMenuGrid.Visibility.Equals(Visibility.Hidden))
            {
                System.Windows.Media.Effects.BlurEffect objBlur =
                                     new System.Windows.Media.Effects.BlurEffect();
                objBlur.Radius = 0;
                map_view.Effect = objBlur;
                Specs.Effect = objBlur;
            }
        }
    }
}
