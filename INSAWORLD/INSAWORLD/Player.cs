using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Player
    {
        private string name; //name of the player 
        private Race racePlay; //race choosen by the player 
        private int points; //points earned by the player 
        IDictionary<Unit, Coord> unitsList; //units of the player 
        private bool playing; //player currently playing
        private int tailleMap;

        public Player(string n, int race, int tailleMap)
        {
            name = n;
            points = 0;
            this.tailleMap = tailleMap;
            racePlay = RaceFactory.Instance.createRace(race);
            UnitsList = UnitsFactory.Instance.createUnits(racePlay, this.tailleMap);
            playing = false;
        }

        public string Name
        {
            get;
            set;
        }

        public int TailleMap
        {
            get;
            set;
        }
        public int Points
        {
            get;
        }

        public Race RacePlay
        {
            get;
            set;
        }

 

        public bool Playing
        {
            get;
        }

        public IDictionary<Unit, Coord> UnitsList
        {
            get
            {
                return unitsList;
            }

            set
            {
                unitsList = value;
            }
        }

        // method : return true if the game is lost by the player
        // false if not
        public bool Lost()
        {            
            throw new System.NotImplementedException();
        }
        // method : end the turn of the player
        public bool EndTurn()
        {
            throw new System.NotImplementedException();
        }
        // method : begin the turn of the player
        public bool StartTurn()
        {
            throw new System.NotImplementedException();
        }
        // method compute points earned by the player this turn and add the result to global count
        public void ComputePoints()
        {
            throw new System.NotImplementedException();
        }

        public bool Attack(Unit u, Coord c)
        {
            throw new System.NotImplementedException();
        }
    }
}
