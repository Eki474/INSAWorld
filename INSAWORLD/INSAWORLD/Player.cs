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

        public Player(string n, int race)
        {
            name = n;
            points = 0;
            racePlay = RaceFactory.Instance.createRace(race);
            unitsList = UnitsFactory.Instance.createUnits(RacePlay);
            playing = false;
        }

        public string Name
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

        public IDictionary<Unit, Coord> UnitsList
        {
            get;
            set;
        }

        public bool Playing
        {
            get;
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
    }
}
