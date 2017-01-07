using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for RaceChoice.xaml
    /// </summary>
    public partial class RaceChoice : Page
    {
        // know which player is choosing
        private int joueur;
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private int map;
        private int raceJ1;
        private int raceJ2;
        private string nameJ1;
        private string nameJ2;
        private MainPage page;
        /// <summary>
        /// sonstructor
        /// </summary>
        public RaceChoice(MainPage p)
        {
            InitializeComponent();
            joueur = 1;
            map = -1;
            raceJ1 = -1;
            raceJ2 = -1;
            nameJ1 = "";
            nameJ2 = "";
            page = p;
    }

        /// <summary>
        /// handle menu button : display menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = page;
        }

        /// <summary>
        /// select map type demo, update attribute with 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void demo_Selected(object sender, RoutedEventArgs e)
        {
            smallSpec.Visibility = Visibility.Hidden;
            standardSpec.Visibility = Visibility.Hidden;
            demoSpec.Visibility = Visibility.Visible;
            map = 0;
            EnAvantDisplay();
        }

        /// <summary>
        /// select map type small, update attribute with 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void small_Selected(object sender, RoutedEventArgs e)
        {
            standardSpec.Visibility = Visibility.Hidden;
            demoSpec.Visibility = Visibility.Hidden;
            smallSpec.Visibility = Visibility.Visible;
            map = 1;
            EnAvantDisplay();
        }

        /// <summary>
        /// select map type standard, updaate attribute with 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void standard_Selected(object sender, RoutedEventArgs e)
        {
            smallSpec.Visibility = Visibility.Hidden;
            demoSpec.Visibility = Visibility.Hidden;
            standardSpec.Visibility = Visibility.Visible;
            map = 2;
            EnAvantDisplay();
        }

        /// <summary>
        /// select race centaurs, update attribute with 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCentaurs_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCentaurs.IsChecked || joueur == 3)
            {
                return;
            }
            //TODO Change by a groupbutton?
            if (!(bool)buttonOkCerberus.IsChecked)
            {
                buttonCerberus.Background = Brushes.White;
                buttonOkCerberus.Visibility = Visibility.Hidden;
            }

            if (!(bool)buttonOkCyclops.IsChecked)
            {
                buttonCyclops.Background = Brushes.White;
                buttonOkCyclops.Visibility = Visibility.Hidden;
            }

            Button button = (Button)sender;
            if (joueur == 1)
            {
                button.Background = Brushes.Green;
                raceJ1 = 2;
            }
            else
            {
                button.Background = Brushes.Red;
                raceJ2 = 2;
            }

            buttonOkCentaurs.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// confirm selected race centaurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOkCentaurs_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCentaurs.IsChecked)
            {
                if (joueur == 1)
                {
                    centaursLeftSpec.Visibility = Visibility.Visible;
                    race1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaur.png"));
                }
                else if(joueur == 2)
                {
                    centaursRightSpec.Visibility = Visibility.Visible;
                    race2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaur.png"));
                }
                joueur++;
                if (joueur == 3)
                {
                    EnAvantDisplay();
                }
            }
            else
            {
                buttonCentaurs.Background = Brushes.White;
                joueur--;
                buttonOkCentaurs.IsChecked = false;
                EnAvantDisplay();
            }
        }

        /// <summary>
        /// select race cerberus, update attribute with 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCerberus_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCerberus.IsChecked || joueur == 3)
            {
                return;
            }
            //TODO Change by a groupbutton?
            if (!(bool)buttonOkCentaurs.IsChecked)
            {
                buttonCentaurs.Background = Brushes.White;
                buttonOkCentaurs.Visibility = Visibility.Hidden;
            }

            if (!(bool)buttonOkCyclops.IsChecked)
            {
                buttonCyclops.Background = Brushes.White;
                buttonOkCyclops.Visibility = Visibility.Hidden;
            }

            Button button = (Button)sender;
            if (joueur == 1)
            {
                button.Background = Brushes.Green;
                raceJ1 = 1;
            }
            else
            {
                button.Background = Brushes.Red;
                raceJ2 = 1;
            }

            buttonOkCerberus.Visibility = Visibility.Visible;
        }
        
        /// <summary>
        /// confirm selected race cerberus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOkCerberus_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCerberus.IsChecked)
            {
                buttonOkCerberus.IsChecked = true;
                if (joueur == 1)
                {
                    cerberusLeftSpec.Visibility = Visibility.Visible;
                    race1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberus.png"));
                }
                else if(joueur == 2)
                {
                    cerberusRightSpec.Visibility = Visibility.Visible;
                    race2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberus.png"));
                }
                joueur++;
                if (joueur == 3)
                {
                    EnAvantDisplay();
                }
            }
            else
            {
                buttonCerberus.Background = Brushes.White;
                joueur--;
                buttonOkCerberus.IsChecked = false;
                EnAvantDisplay();
            }
        }

        /// <summary>
        /// select race cyclops, update attribute with 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCyclops_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCyclops.IsChecked || joueur == 3)
            {
                return;
            }
            //TODO Change by a groupbutton?
            if (!(bool)buttonOkCerberus.IsChecked)
            {
                buttonCerberus.Background = Brushes.White;
                buttonOkCerberus.Visibility = Visibility.Hidden;
            }

            if (!(bool)buttonOkCentaurs.IsChecked)
            {
                buttonCentaurs.Background = Brushes.White;
                buttonOkCentaurs.Visibility = Visibility.Hidden;
            }

            Button button = (Button)sender;
            if (joueur == 1)
            {
                button.Background = Brushes.Green;
                raceJ1 = 0;
            }
            else
            {
                button.Background = Brushes.Red;
                raceJ2 = 0;
            }

            buttonOkCyclops.Visibility = Visibility.Visible;
            HoverCyclops(sender, e);
        }

        /// <summary>
        /// confirm selected race cyclops
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOkCyclops_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCyclops.IsChecked)
            {
                buttonOkCyclops.IsChecked = true;
                if (joueur == 1)
                {
                    cyclopsLeftSpec.Visibility = Visibility.Visible;
                    race1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png"));
                }
                else if(joueur == 2)
                {
                    cyclopsRightSpec.Visibility = Visibility.Visible;
                    race2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png"));
                }
                joueur++;
                if (joueur == 3)
                {
                    EnAvantDisplay();
                }
            }
            else
            {
                buttonCyclops.Background = Brushes.White;
                joueur--;
                buttonOkCyclops.IsChecked = false;
                EnAvantDisplay();
            }
        }

        /// <summary>
        /// launch board view to start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            var p1 = new Player(nameJ1, raceJ1, BuilderMap.Instance.getSize(map));
            var p2 = new Player(nameJ2, raceJ2, BuilderMap.Instance.getSize(map));
            mainWindow.Content = new GameBoard(ref p1, ref p2, map);
        }

        /// <summary>
        /// display centaurs spec and picture on hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoverCentaurs(object sender, RoutedEventArgs  e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaur.png"));
                centaursLeftSpec.Visibility = Visibility.Visible;
                cyclopsLeftSpec.Visibility = Visibility.Hidden;
                cerberusLeftSpec.Visibility = Visibility.Hidden;
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaur.png"));
                centaursRightSpec.Visibility = Visibility.Visible;
                cyclopsRightSpec.Visibility = Visibility.Hidden;
                cerberusRightSpec.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// stop display centaurs spec and picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndHoverCentaurs(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source =null;
                centaursLeftSpec.Visibility = Visibility.Hidden;
            }
            else if (joueur == 2)
            {
                race2.Source = null;
                centaursRightSpec.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// display cerberus spec and picture on hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoverCerberus(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberus.png")));
                centaursLeftSpec.Visibility = Visibility.Hidden;
                cyclopsLeftSpec.Visibility = Visibility.Hidden;
                cerberusLeftSpec.Visibility = Visibility.Visible;
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cerberus.png")));
                centaursRightSpec.Visibility = Visibility.Hidden;
                cyclopsRightSpec.Visibility = Visibility.Hidden;
                cerberusRightSpec.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// stop display cerberus spec and picture 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndHoverCerberus(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = null;
                cerberusLeftSpec.Visibility = Visibility.Hidden;
            }
            else if (joueur == 2)
            {
                race2.Source = null;
                cerberusRightSpec.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// display cyclops spec and picture on hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoverCyclops(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png")));
                centaursLeftSpec.Visibility = Visibility.Hidden;
                cyclopsLeftSpec.Visibility = Visibility.Visible;
                cerberusLeftSpec.Visibility = Visibility.Hidden;
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png")));
                centaursRightSpec.Visibility = Visibility.Hidden;
                cyclopsRightSpec.Visibility = Visibility.Visible;
                cerberusRightSpec.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// stop display centaurs spec and picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndHoverCyclops(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = null;
                cyclopsLeftSpec.Visibility = Visibility.Hidden;
            }
            else if (joueur == 2)
            {
                race2.Source = null;
                cyclopsRightSpec.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// if all spec has been choose, display start game button
        /// </summary>
        private void EnAvantDisplay()
        {
            if (joueur==3 && map != -1 && !string.IsNullOrWhiteSpace(name1.Text) && !string.IsNullOrWhiteSpace(name2.Text))
            {
                buttonStartGame.Visibility = Visibility.Visible;
            }
            else if(buttonStartGame != null) //pourquoi ?
            {
                buttonStartGame.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// retrieve given player 1 name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void name1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            nameJ1 = t.Text;
            EnAvantDisplay();
        }

        /// <summary>
        /// retrieve given player 2 name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void name2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            nameJ2 = t.Text;
            EnAvantDisplay();
        }
    }
}
