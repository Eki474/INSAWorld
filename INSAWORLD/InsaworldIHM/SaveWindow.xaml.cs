using INSAWORLD;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        Game game;
        string buttonSelected = "";
        StackPanel sp;

        /// <summary>
        /// constructor
        /// </summary>
        public SaveWindow()
        {
            InitializeComponent();
            InitializeScrollViewer();
        }

        /// <summary>
        /// accessors for the game
        /// </summary>
        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        /// <summary>
        /// to initialize view with existing files
        /// </summary>
        private void InitializeScrollViewer()
        {
            ScrollViewer sc = scrollchoice;
            sp = new StackPanel();
            var dirinfo = new DirectoryInfo(Directory.GetCurrentDirectory()+ @"\Save\");
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
        /// to retrieve the name of the save given in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtbox = (TextBox)sender;
            if (txtbox.Text.Equals(""))
            {
                buttonSave.Visibility = Visibility.Hidden;
            }
            else
            {
                buttonSave.Visibility = Visibility.Visible;
            }
        }
        
        /// <summary>
        /// to save the game, appears only if name given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new SaveCommand(ref game, textBoxSave.Text);
            if (cmd.CanExecute()) cmd.Execute();
            this.Close();
        }

        /// <summary>
        /// to quit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// to delete the selected save
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
            foreach(ToggleButton tgl in sp.Children)
            {
                if (tgl.Equals(tglbtn)) continue;
                tgl.IsChecked = false;
            }
            if ((bool)tglbtn.IsChecked) { buttonDelete.Visibility = Visibility.Visible; buttonSelected = (string)tglbtn.Content; }
            else buttonDelete.Visibility = Visibility.Hidden;
        }
    }
}
