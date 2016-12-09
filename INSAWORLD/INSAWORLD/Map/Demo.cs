using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Demo : GameMap
    {
        private int taille; //size of the board
        private Dictionary<Coord, Tile> casesJoueur; //to stock the tile
        private double nbTurn; // number of maximum turns before the game ends

        /// <summary>
        /// constructor
        /// </summary>
        public Demo()
        {
            taille = 6;
            nbTurn = 5;
            casesJoueur = new Dictionary<Coord, Tile>();
        }

        public int Taille
        {
            get { return taille; }
            set { taille = value; }
        }

        public Dictionary<Coord, Tile> CasesJoueur
        {
            get { return casesJoueur; }
            set { casesJoueur = value; }
        }

        public double NbTurn
        {
            get { return nbTurn; }
            set { nbTurn = value; }
        }

        /// <summary>
        /// decrement nbTurn when a turn is finished. -0.5 for a turn in a two-players game. 
        /// </summary>
        /// <returns>true if nbTurn inferior to 0 false if equals to 0</returns>
        
        public bool TurnPlayed()
        {
            nbTurn -= 0.5;
            if (nbTurn < 0) return true;
            else return false;
        }

        public bool Equals(Demo d){
            Coord c;
            for(int i = 0; i<taille; i++){
                for(int j = 0; j<taille; j++){
                    c = new Coord(i,j);
                    if(!d.casesJoueur[c].Equals(casesJoueur[c])) return false;
                }
            }
            return true;
        }

        public bool Equals(GameMap m)
        {
            return this.Equals(((Demo)m));
        }

        public static bool operator==(Demo d, Demo d2){
            return d.Equals(d2);
        }

        public static bool operator!=(Demo d, Demo d2){
            return !d.Equals(d2);
        }

    }
}
