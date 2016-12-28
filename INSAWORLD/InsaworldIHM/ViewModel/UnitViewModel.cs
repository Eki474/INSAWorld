using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAWORLD;

namespace InsaworldIHM.ViewModel
{
    class UnitViewModel
    {
        private Unit obj;

        public string TxtMovePoints
        {
            get { return "Move : " + obj.MovePoints; }
        }

        public string TxtLifePoints
        {
            get { return "Life : " + obj.LifePoints; }
        }

        public string TxtRace
        {
            get { return obj.Race.Type; }
        }

        public bool IsPlayed
        {
            get { return obj.Played; }
        }

        public int Xcoord
        {
            get { return obj.C.X; }
        }

        public int Ycoord
        {
            get { return obj.C.Y; }
        }
    }
}
