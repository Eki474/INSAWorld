using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //strategy : several implementations of VictoryPoints in function of the race
    public interface Race
    {

        int Attack
        {
            get;
        }

        int Defense
        {
            get;
        }

        int Life
        {
            get;
        }

        int Move
        {
            get;
        }

        
        /// <summary>
        /// compute victory points earn by one unit
        /// </summary>
        /// <returns>depend on the implementation</returns>
        int VictoryPoints(Unit u, ref Game myGame);

        /// <summary>
        /// try to move the unit on the tile with coord
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">coord to move on</param>
        /// <returns>true if the unit can move on the tile, false if not</returns>
        bool ActionMove(Unit u, Coord c, ref Game myGame);

        /// <summary>
        /// move the unit on the tile of the killed unit if no other units on this tile
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="d">unit killed and his coord</param>
        void MoveOverride(Unit u, KeyValuePair<Unit, Coord> d, ref Game myGame);
    }
}
