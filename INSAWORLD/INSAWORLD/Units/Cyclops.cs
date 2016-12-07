using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Cyclops : Race
    {
        /// <summary>
        /// units' statistics of this race
        /// </summary>
        private int attack;
        private int defense;
        private int life;
        private int move;

        public Cyclops()
        {
            attack = 4;
            defense = 6;
            life = 12;
            move = 3;
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public int Move
        {
            get { return move; }
            set { move = value; }
        }

        /// <summary>
        /// compute victory points earn by one unit
        /// </summary>
        /// <param name="u">target unit</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>3 on desert, 2 on plain, 1 on volcano, 0 on swamp</returns>
        public int VictoryPoints(Unit u, ref Game myGame)
        {
            Coord c = u.C;
            Tile t = myGame.Map.CasesJoueur[c];
            switch (t.GetType().ToString())
            {
                case "Desert": return 3;
                case "Plain": return 2;
                case "Volcano": return 1;
                case "Swamp": return 0;
                default: return 0;
            }
        }

        /// <summary>
        /// try to move the unit on the tile with coord
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">coord to move on</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>true if the unit can move on the tile, false if not</returns>
        public bool ActionMove(Unit u, Coord c, ref Game myGame)
        {
            
            throw new NotImplementedException();
        }

        /// <summary>
        /// move the unit on the tile of the killed unit if no other units on this tile
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="d">unit killed and his coord</param>
        /// <param name="map">reference to the map</param>
        public void MoveOverride(Unit u, Unit d, ref Game myGame)
        {
            bool movement = true;
            List<Unit> list1 = new List<Unit>();
            List<Unit> list2 = new List<Unit>();
            if (myGame.Player1.UnitsList.Contains(d))
            {
                foreach (Unit unit in myGame.Player1.UnitsList)
                {
                    list1.Add(unit);
                }
                foreach (Unit unit in myGame.Player2.UnitsList)
                {
                    list2.Add(unit);
                }
            }
            else
            {
                foreach (Unit unit in myGame.Player1.UnitsList)
                {
                    list2.Add(unit);
                }
                foreach (Unit unit in myGame.Player2.UnitsList)
                {
                    list1.Add(unit);
                }
            }
            foreach (Unit t in list1)
            {
                if (t.C.Equals(d.C) & !t.Equals(d)) { movement = false; }
            }
            if (movement) { u.C = d.C; }
        }

        /// <summary>
        /// verifies if a unit can still move or if it has no move points remaining
        /// </summary>
        /// <param name="u">target unit</param>
        /// <param name="map">reference to the map</param>
        /// <returns>true if the unit can't move, false if if do</returns>
        public bool NoMoreMoves(Unit u, ref GameMap map)
        {
            return u.MovePoints == 0;
        }
    }
}
