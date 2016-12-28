using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAWORLD;

namespace InsaworldIHM.ViewModel
{
    class RaceViewModel
    {
        private Race obj;

        public string TxtMove
        {
            get { return "Move : " + obj.Move; }
        }

        public string TxtLife
        {
            get { return "Life : " + obj.Life; }
        }

        public string TxtAttack
        {
            get { return "Attack : " + obj.Attack; }
        }

        public string TxtDefense
        {
            get { return "Defense : " + obj.Defense; }
        }

        public string TxtType
        {
            get { return obj.Type; }
        }

    }
}
