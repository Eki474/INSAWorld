using System;
using System.Collections.Generic;
using System.Linq;

namespace INSAWORLD
{
    public class Centaurs : Race
    {
        /// <summary>
        /// units' statistics of this race
        /// </summary>
        private int attack;
        private int defense;
        private int life;
        private int move;

        public Centaurs()
        {
            attack = 8;
            defense = 2;
            life = 10;
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
        /// <returns>3 on plain, 2 on desert, 1 on swamp, 0 on volcano</returns>
        public int VictoryPoints(Unit u, ref Game myGame)
        {
            Coord c = u.C;
            Tile t = myGame.Map.CasesJoueur[c];
            switch (t.GetType().ToString())
            {
                case "Plain": return 3;
                case "Desert": return 2;
                case "Swamp": return 1;
                case "Volcano": return 0;
                default: return 0;
            }
        }

        /// <summary>
        /// try to move the unit on the tile with coord
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">coord to move on</param>
        /// <returns>true if the unit can move on the tile, false if not</returns>
        public bool ActionMove(Unit u, Coord c, ref Game myGame)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// move the unit on the tile of the killed unit if no other units on this tile
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">move on those coord</param>
        public void MoveOverride(Unit u, Unit d, ref Game myGame)
        {
            bool movement = true;
            List<Unit> list1;
            List<Unit> list2;
            if (myGame.Player1.UnitsList.Contains(d))
            {
                list1 = myGame.Player1.UnitsList;
                list2 = myGame.Player2.UnitsList;
            }
            else
            {
                list1 = myGame.Player2.UnitsList;
                list2 = myGame.Player1.UnitsList;
            }
            foreach (Unit t in list1)
            {
                if (t.C.Equals(d.C) & !t.Equals(d)) { movement = false; }
            }
            if (movement) { u.C = d.C; }
        }

        public bool NoMoreMoves(Unit u, ref GameMap map)
        {
            return u.MovePoints == 0 || (u.MovePoints == 0.5 && !map.CasesJoueur[u.C].Equals(Plain.Instance));
        }
    }
}
