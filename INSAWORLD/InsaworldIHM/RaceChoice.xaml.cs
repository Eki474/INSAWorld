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

namespace InsaworldIHM
{
    /// <summary>
    /// Interaction logic for RaceChoice.xaml
    /// </summary>
    public partial class RaceChoice : Page
    {
        // know which player is choosing
        int joueur = 1;
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public RaceChoice()
        {
            InitializeComponent();
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
        }

        private void small_Selected(object sender, RoutedEventArgs e)
        {
            standardSpec.Visibility = Visibility.Hidden;
            demoSpec.Visibility = Visibility.Hidden;
            smallSpec.Visibility = Visibility.Visible;
        }

        private void standard_Selected(object sender, RoutedEventArgs e)
        {
            smallSpec.Visibility = Visibility.Hidden;
            demoSpec.Visibility = Visibility.Hidden;
            standardSpec.Visibility = Visibility.Visible;
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
            }
            else button.Background = Brushes.Red;

            buttonOkCentaurs.Visibility = Visibility.Visible;


        }

        private void buttonOkCentaurs_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCentaurs.IsChecked)
            {
                buttonOkCentaurs.IsChecked = true;
                joueur++;
                if (joueur == 3)
                {
                    buttonStartGame.Visibility = Visibility.Visible;
                }
            }
            else
            {
                buttonCentaurs.Background = Brushes.White;
                joueur--;
                buttonOkCentaurs.IsChecked = false;
                buttonStartGame.Visibility = Visibility.Hidden;
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
            }
            else button.Background = Brushes.Red;

            buttonOkCerberus.Visibility = Visibility.Visible;


        }

        private void buttonOkCerberus_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCerberus.IsChecked)
            {
                buttonOkCerberus.IsChecked = true;
                joueur++;
                if (joueur == 3)
                {
                    buttonStartGame.Visibility = Visibility.Visible;
                }
            }
            else
            {
                buttonCerberus.Background = Brushes.White;
                joueur--;
                buttonOkCerberus.IsChecked = false;
                buttonStartGame.Visibility = Visibility.Hidden;
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
            }
            else button.Background = Brushes.Red;

            buttonOkCyclops.Visibility = Visibility.Visible;


        }

        private void buttonOkCyclops_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)buttonOkCyclops.IsChecked)
            {
                buttonOkCyclops.IsChecked = true;
                joueur++;
                if (joueur == 3)
                {
                    buttonStartGame.Visibility = Visibility.Visible;
                }
            }
            else
            {
                buttonCyclops.Background = Brushes.White;
                joueur--;
                buttonOkCyclops.IsChecked = false;
                buttonStartGame.Visibility = Visibility.Hidden;
            }
        }

        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HoverCentaurs(object sender, RoutedEventArgs  e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/menu/1.jpg")));
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/menu/1.jpg")));
            }
        }

        private void EndHoverCentaurs(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source =null;
            }
            else if (joueur == 2)
            {
                race2.Source = null;
            }
        }

        private void HoverCerberus(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/menu/1.jpg")));
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/menu/1.jpg")));
            }
        }

        private void EndHoverCerberus(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = null;
            }
            else if (joueur == 2)
            {
                race2.Source = null;
            }
        }

        private void HoverCyclops(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/menu/1.jpg")));
            }
            else if (joueur == 2)
            {
                race2.Source = new BitmapImage(new Uri(("pack://application:,,,/InsaworldIHM;component/Ressources/images/menu/1.jpg")));
            }
        }

        private void EndHoverCyclops(object sender, RoutedEventArgs e)
        {
            if (joueur == 1)
            {
                race1.Source = null;
            }
            else if (joueur == 2)
            {
                race2.Source = null;
            }
        }



    }
}
