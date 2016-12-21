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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace InsaworldIHM
{
    /// <summary>
    /// Logique d'interaction pour SaveChoice.xaml
    /// </summary>
    public partial class SaveChoice : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public SaveChoice()
        {
            InitializeComponent();
            ScrollViewer sc = scrollchoice;
            StackPanel sp = new StackPanel();
            var dirinfo = new DirectoryInfo(@"C:\Users\franc\Source\Repos\xXx_POO_xXx\INSAWORLD\InsaworldTEST\bin\Debug\Save\");
            FileInfo[] f = dirinfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo t in f)
            {
                Button b = new Button();
                b.Content = System.IO.Path.GetFileNameWithoutExtension(t.Name);
                sp.Children.Add(b);
            }
            sc.Content = sp;
        }


        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Back(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new MainPage();
        }
    }
}
