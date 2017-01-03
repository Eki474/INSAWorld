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
using System.Threading;

namespace InsaworldIHM
{
    /// <summary>
    /// Logique d'interaction pour SaveChoice.xaml
    /// </summary>
    public partial class ReplayChoice : IAsyncResult
    {
        Game game;
        string buttonSelected = "";
        StackPanel sp;

        public bool IsCompleted
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object AsyncState
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ReplayChoice()
        {
            //TODO NotFoundDirectoryException à gérer : si pas de directory --> pas de save --> message utilisateur
            InitializeComponent();
            InitializeScrollViewer();
        }

        private void InitializeScrollViewer()
        {
            ScrollViewer sc = scrollchoice;
            sp = new StackPanel();
            DirectoryInfo dirinfo;
            try { dirinfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Replay\"); }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show("No save to load");
                return;
            }
            FileInfo[] f = dirinfo.GetFiles("*.Game.txt", SearchOption.TopDirectoryOnly);
            foreach (FileInfo t in f)
            {
                var b = new ToggleButton();
                b.Content = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetFileNameWithoutExtension(t.Name));
                b.Click += toggleButtonClick;
                sp.Children.Add(b);
            }
            sc.Content = sp;
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new LoadReplayCommand(buttonSelected);
            if (cmd.CanExecute()) cmd.Execute();
            game = cmd.Game;
            var loaded = new GameBoard(ref game, true);
            Application.Current.MainWindow.Content = loaded;
        }
        /*
        private void updateCoord(ref Game g, ref GameBoard gb)
        {
            foreach(Unit u in g.Player1.UnitsList.Concat(g.Player2.UnitsList))
            {
                Image i = gb.getImageToUnit(u);
                Grid.SetColumn(i, u.C.Y);
                Grid.SetRow(i, u.C.X);
            }
        }

        private void viewReplay()
        {
            var loaded = new GameBoard(ref game);
            Application.Current.MainWindow.Content = loaded;
            foreach (ToCollect cmd in game.Rpz.Step)
            {
                cmd.ExecuteReplay();
                switch (cmd.GetType().ToString())
                {
                    case "NextTurn":
                        var nt = (NextTurn)cmd;
                        
                        break;
                    case "AttackUnit":
                        var au = (AttackUnit)cmd;
                        break;
                    case "MoveUnit":
                        var mu = (MoveUnit)cmd;
                        break;
                }
            }
        }*/

        private void Quit(object sender, RoutedEventArgs e)
        {
            var page = new MainPage();
            Application.Current.MainWindow.Content = page;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(Directory.GetCurrentDirectory() + @"\Replay\" + buttonSelected + ".Game.txt");
            File.Delete(Directory.GetCurrentDirectory() + @"\Replay\" + buttonSelected + ".Map.txt");
            InitializeScrollViewer();
        }

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
