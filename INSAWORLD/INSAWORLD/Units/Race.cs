using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    //strategy : several implementations of VictoryPoints function of the race
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

        string Type
        {
            get;
        }

        /// <summary>
        /// compute victory points earn by one unit
        /// </summary>
        /// <param name="u">target unit</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>depend on the implementation</returns>
        int VictoryPoints(Unit u, ref Game myGame);

        /// <summary>
        /// try to move the unit on the tile with coord
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">coord to move on</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>true if the unit can move on the tile, false if not</returns>
        void ActionMove(Unit u, Coord c, ref Game myGame);

        /// <summary>
        /// move the unit on the tile of the killed unit if no other units on this tile
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="d">unit killed and his coord</param>
        /// <param name="map">reference to the map</param>
        bool TryMove(Unit u, Coord c, ref Game myGame);

        /// <summary>
        /// verifies if a unit can still move or if it has no move points remaining
        /// </summary>
        /// <param name="u">target unit</param>
        /// <param name="map">reference to the map</param>
        /// <returns>true if the unit can't move, false if if do</returns>
        bool NoMoreMoves(Unit u, ref GameMap map);
    }
}
