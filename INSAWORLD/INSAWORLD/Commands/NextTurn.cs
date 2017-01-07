using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class NextTurn : CommandMenu, ToCollect
    {
        private Game game; //game
        private bool nbTurn; //true if game win by a player false if not
        private String typeName = "NextTurn";

        public string TypeName
        {
            get
            {
                return typeName;
            }
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="g">game</param>
        public NextTurn(Game g)
        {
            game=g;
        }

        /// <summary>
        /// end the player turn and go to the next turn
        /// verify if the game is finished
        /// </summary>
        public void Execute()
        {
            Player p;
            if (game.Player1.Playing)
            {
                p = game.Player1;
                game.Player2.StartTurn();
                game.Player1.Playing = false;
            }
            else
            {
                p = game.Player2;
                game.Player1.StartTurn();
                game.Player2.Playing = false;
            }
            foreach (Unit u in p.UnitsList) u.Reset();
            nbTurn = game.Map.TurnPlayed();
            game.Rpz.AddStep(this);
        }

        /// <summary>
        /// execute without stocking into step (for replay only)
        /// </summary>
        public void ExecuteReplay()
        {
            Player p;
            if (game.Player1.Playing)
            {
                p = game.Player1;
                game.Player2.StartTurn();
                game.Player1.Playing = false;
            }
            else
            {
                p = game.Player2;
                game.Player1.StartTurn();
                game.Player2.Playing = false;
            }
            foreach (Unit u in p.UnitsList) u.Reset();
            nbTurn = game.Map.TurnPlayed();
        }

        /// <summary>
        /// verify the end of the game
        /// </summary>
        /// <returns>true if the game is finished, else if not</returns>
        public bool CanExecute()
        {
            return !game.EndGame();
        }

        /// <summary>
        /// for ReplayCollector
        /// </summary>
        /// <returns>next</returns>
        override
        public string ToString()
        {
            return "next";
        }
    }
}
