using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAWORLD;
using System.ComponentModel;

namespace InsaworldIHM.ViewModel
{
    
        
    class UnitViewModel : ViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Unit obj;
        Unit u;

        public UnitViewModel(Unit u)
        {
            this.u = u;
        }

        public double MovePoints
        {
            get { return u.MovePoints; }
            set { u.MovePoints = value; this.onPropertyChanged("MovePoints");}
        }

        public int Id
        {
            get { return u.Id; }
            private set { this.onPropertyChanged("Id"); }
        }

        public int LifePoints
        {
            get { return u.LifePoints; }
            set { u.LifePoints = value; this.onPropertyChanged("LifePoints"); }
        }

        public bool Played
        {
            get { return u.Played; }
            set { u.Played = value; this.onPropertyChanged("Played"); }
        }

        public Race Race
        {
            get { return u.Race; }
            set { u.Race = value; this.onPropertyChanged("Race"); }
        }

        public Coord C
        {
            get { return u.C; }
            set {
                Coord newc = (Coord)value;
                if(!newc.X.Equals(u.C.X)) this.onPropertyChanged("CX");
                if (!newc.Y.Equals(u.C.Y)) this.onPropertyChanged("CY");
                u.C = value;  }
        }

        /// <summary>
        /// Attack an other unit
        /// </summary>
        /// <param name="c">coord of the attacked unit</param>
        /// <param name="def">unit which defend the tile on coord</param>
        /// <param name="myGame">reference to game to use information from map</param>
        /// <returns>true if the fight is won false if not</returns>
        public void Attack(Coord c, UnitViewModel def, ref Game myGame)
        {
            u.Attack(c, def.u, ref myGame);
            onPropertyChanged("LifePoints");
            def.onPropertyChanged("LifePoints");
        }
            

        /// <summary>
        /// All points are resetted + life regen 
        /// </summary>
        public void Reset()
        {
            onPropertyChanged("LifePoints");

            onPropertyChanged("Played");
        }

        override
        public void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
