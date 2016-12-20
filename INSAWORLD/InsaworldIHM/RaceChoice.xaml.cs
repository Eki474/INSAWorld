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
    /// Interaction logic for RaceChoice.xaml
    /// </summary>
    public partial class RaceChoice : Page
    {
        public RaceChoice()
        {
            InitializeComponent();
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            InGameMenu page = new InGameMenu();
            Content = page;
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
    }
}
