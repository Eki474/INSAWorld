using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAWORLD;

namespace InsaworldIHM.ViewModel
{
    class GameMapViewModel
    {
        private GameMap obj;

        public string TxtSize
        {
            get { return "Size : " + obj.Taille; }
        }

        public string TxtMaxTurn
        {
            get { return "Number of turn : " + BuilderMap.Instance.getMaxTurn(obj.Taille); }
        }

        public string TxtCurrentTurn
        {
            get { return "Turn : " + (BuilderMap.Instance.getMaxTurn(obj.Taille) - obj.NbTurn + 1); }
        }
    }
}
