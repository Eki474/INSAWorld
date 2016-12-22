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

        public GameBoard(ref Player p1, ref Player p2, int map)
        {
            InitializeComponent();
            g = new Game(ref p1, ref p2);
            g.Initialize(map);
            Grid.SetColumn(map_view, 1);
            board.Children.Add(map_view);
            int map_size = g.Map.Taille;
            for(int i = 0; i< map_size; i++)
            {
                var c = new ColumnDefinition();
                c.Width = new GridLength(1, GridUnitType.Star);
                map_view.ColumnDefinitions.Add(c);
                var r = new RowDefinition();
                r.Height = new GridLength(1, GridUnitType.Star);
                map_view.RowDefinitions.Add(r);
            }

            for(int j = 0; j<map_size; j++)
            {
                for(int k = 0; k<map_size; k++)
                {
                    string t = g.Map.CasesJoueur[new Coord(j, k)].getType();
                    var l = new ListView();
                    var item = new ListViewItem();
                    Image img = new Image();
                    img.Stretch = Stretch.Fill;
                    switch (t)
                    {
                        case "plain":
                            img.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/plain.png"));
                            item.Content = img;
                            break;
                        case "volcano":
                            img.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/volcano.jpg"));
                            item.Content = img;
                            break;
                        case "swamp":
                            img.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/swamp.png"));
                            item.Content = img;
                            break;
                        case "desert":
                            img.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/textures/desert.jpg"));
                            item.Content = img;
                            break;
                    }
                    l.Items.Add(item);
                    Grid.SetColumn(l, j);
                    Grid.SetRow(l, k);
                    map_view.Children.Add(l);
                    mainWindow.Content = board;
                }
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
