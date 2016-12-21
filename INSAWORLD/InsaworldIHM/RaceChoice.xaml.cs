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

        public RaceChoice()
        {
            InitializeComponent();
            joueur = 1;
            map = -1;
            raceJ1 = -1;
            raceJ2 = -1;
            nameJ1 = "";
            nameJ2 = "";
    }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            InGameMenu page = new InGameMenu();
            mainWindow.Content = page;
        }

        private void demo_Selected(object sender, RoutedEventArgs e)
        {
            smallSpec.Visibility = Visibility.Hidden;
            standardSpec.Visibility = Visibility.Hidden;
            demoSpec.Visibility = Visibility.Visible;
            map = 0;
            EnAvantDisplay();
        }

        private void small_Selected(object sender, RoutedEventArgs e)
        {
            standardSpec.Visibility = Visibility.Hidden;
            demoSpec.Visibility = Visibility.Hidden;
            smallSpec.Visibility = Visibility.Visible;
            map = 1;
            EnAvantDisplay();
        }

        private void standard_Selected(object sender, RoutedEventArgs e)
        {
            smallSpec.Visibility = Visibility.Hidden;
            demoSpec.Visibility = Visibility.Hidden;
            standardSpec.Visibility = Visibility.Visible;
            map = 2;
            EnAvantDisplay();
        }

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

        private void buttonOkCentaurs_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCentaurs.IsChecked)
            {
                if (joueur == 1)
                {
                    centaursLeftSpec.Visibility = Visibility.Visible;
                    race1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/centaurs/mecha1.jpg"));
                }
                else if(joueur == 2)
                {
                    centaursRightSpec.Visibility = Visibility.Visible;
                    race2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/centaurs/mecha1.jpg"));
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

        private void buttonOkCerberus_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCerberus.IsChecked)
            {
                buttonOkCerberus.IsChecked = true;
                if (joueur == 1)
                {
                    cerberusLeftSpec.Visibility = Visibility.Visible;
                    race1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/cerberus/mecha2.jpg"));
                }
                else if(joueur == 2)
                {
                    cerberusRightSpec.Visibility = Visibility.Visible;
                    race2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/cerberus/mecha2.jpg"));
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

        private void buttonOkCyclops_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCyclops.IsChecked)
            {
                buttonOkCyclops.IsChecked = true;
                if (joueur == 1)
                {
                    cyclopsLeftSpec.Visibility = Visibility.Visible;
                    race1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/cyclops/mecha3.jpg"));
                }
                else if(joueur == 2)
                {
                    cyclopsRightSpec.Visibility = Visibility.Visible;
                    race2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/cyclops/mecha3.jpg"));
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

        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            var p1 = new Player(nameJ1, raceJ1, BuilderMap.Instance.getSize(map));
            var p2 = new Player(nameJ2, raceJ2, BuilderMap.Instance.getSize(map));
            mainWindow.Content = new GameBoard(ref p1, ref p2, map);
        }

        private void HoverCentaurs(object sender, RoutedEventArgs  e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/centaurs/mecha1.jpg"));
                centaursLeftSpec.Visibility = Visibility.Visible;
                cyclopsLeftSpec.Visibility = Visibility.Hidden;
                cerberusLeftSpec.Visibility = Visibility.Hidden;
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/centaurs/mecha1.jpg"));
                centaursRightSpec.Visibility = Visibility.Visible;
                cyclopsRightSpec.Visibility = Visibility.Hidden;
                cerberusRightSpec.Visibility = Visibility.Hidden;
            }
        }

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

        private void HoverCerberus(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/cerberus/mecha2.jpg")));
                centaursLeftSpec.Visibility = Visibility.Hidden;
                cyclopsLeftSpec.Visibility = Visibility.Hidden;
                cerberusLeftSpec.Visibility = Visibility.Visible;
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/cerberus/mecha2.jpg")));
                centaursRightSpec.Visibility = Visibility.Hidden;
                cyclopsRightSpec.Visibility = Visibility.Hidden;
                cerberusRightSpec.Visibility = Visibility.Visible;
            }
        }

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

        private void HoverCyclops(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/cyclops/mecha3.jpg")));
                centaursLeftSpec.Visibility = Visibility.Hidden;
                cyclopsLeftSpec.Visibility = Visibility.Visible;
                cerberusLeftSpec.Visibility = Visibility.Hidden;
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/cyclops/mecha3.jpg")));
                centaursRightSpec.Visibility = Visibility.Hidden;
                cyclopsRightSpec.Visibility = Visibility.Visible;
                cerberusRightSpec.Visibility = Visibility.Hidden;
            }
        }

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

        private void EnAvantDisplay()
        {
            if (joueur==3 && mapChoice.SelectedItem != null && !string.IsNullOrWhiteSpace(name1.Text) && !string.IsNullOrWhiteSpace(name2.Text))
            {
                buttonStartGame.Visibility = Visibility.Visible;
            }
            else if(buttonStartGame != null)
            {
                buttonStartGame.Visibility = Visibility.Hidden;
            }
        }

        private void name1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            nameJ1 = t.Text;
            EnAvantDisplay();
        }

        private void name2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            nameJ2 = t.Text;
            EnAvantDisplay();
        }
    }
}
