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
using INSAWORLD;
using System.Windows.Controls.Primitives;

namespace InsaworldIHM
{
    /// <summary>
    /// Logique d'interaction pour SaveChoice.xaml
    /// </summary>
    public partial class SaveChoice : Page
    {
        string buttonSelected = "";
        StackPanel sp;
        MainPage page;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="p">main page</param>
        public SaveChoice(MainPage p)
        {
            //NotFoundDirectoryException à gérer : si pas de directory --> pas de save --> message utilisateur
            InitializeComponent();
            InitializeScrollViewer();
            page = p;
        }

        /// <summary>
        /// initialize the view with the files
        /// </summary>
        private void InitializeScrollViewer()
        {
            ScrollViewer sc = scrollchoice;
            sp = new StackPanel();
            DirectoryInfo dirinfo;
            try { dirinfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Save\"); }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show("No save to load");
                return;
            }
            FileInfo[] f = dirinfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo t in f)
            {
                var b = new ToggleButton();
                b.Content = System.IO.Path.GetFileNameWithoutExtension(t.Name);
                b.Click += toggleButtonClick;
                sp.Children.Add(b);
            }
            sc.Content = sp;
        }

        /// <summary>
        /// handler for the load button which load a selected save, appears only if one selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new LoadCommand(buttonSelected);
            if (cmd.CanExecute()) cmd.Execute();
            var g = cmd.Game;
            var loaded = new GameBoard(ref g, false);
            Application.Current.MainWindow.Content = loaded;
        }

        /// <summary>
        /// handler to quit the game 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = page;
        }

        /// <summary>
        /// handler to delete a selected save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            bool found = File.Exists(Directory.GetCurrentDirectory() + @"\Save\" + buttonSelected + ".txt");
            File.Delete(Directory.GetCurrentDirectory() + @"\Save\" + buttonSelected + ".txt");
            InitializeScrollViewer();
        }

        /// <summary>
        /// to select a save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toggleButtonClick(object sender, RoutedEventArgs e)
        {
            var tglbtn = (ToggleButton)sender;
            foreach (ToggleButton tgl in sp.Children)
            {
                if (tgl.Equals(tglbtn)) continue;
                tgl.IsChecked = false;
            }
            if ((bool)tglbtn.IsChecked)
            {
                buttonLoad.Visibility = Visibility.Visible;
                buttonDelete.Visibility = Visibility.Visible;
                buttonSelected = (string)tglbtn.Content;
            }
            else
            {
                buttonDelete.Visibility = Visibility.Hidden;
                buttonLoad.Visibility = Visibility.Hidden;
            }
        }
    }
}
