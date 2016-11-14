using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class RaceFactory
    {
        public static RaceFactory Instance { get; } = new RaceFactory();
        private RaceFactory()
        {

        }

        public Race createRace(int i)
        {
            switch(i){
                case 0: return new Cyclops();
                case 1: return new Cerberus();
                case 2: return new Centaurs();
                default:
                    throw new Exception("Bad Race Initialization");
            }
        }

    }
}