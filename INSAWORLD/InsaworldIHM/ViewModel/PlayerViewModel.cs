using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAWORLD;

namespace InsaworldIHM.ViewModel
{
    public class PlayerViewModel
    {
        private Player obj;

        /*public PlayerViewModel(string name, int racetype, int mapsize)
        {
            obj = new Player(name, racetype, mapsize);
        }

        public PlayerViewModel(string[] n)
        {
            obj = new Player(n);
        }*/

        public string TxtName
        {
            get { return obj.Name; }
            set { obj.Name = value; }
        }

        public string TxtRacePlay
        {
            get { return obj.RacePlay.Type; }
        }

        public string TxtPoints
        {
            get { return "Points : " + obj.Points; }
            set { obj.Points = int.Parse(value); }
        }

        public bool IsPlaying
        {
            get { return obj.Playing; }
        }

        public int MapSize
        {
            get { return obj.TailleMap; }
            set { obj.TailleMap = value; }
        }

        public int NbUnits
        {
            get { return obj.UnitsList.Count; }
        }
    }
}
