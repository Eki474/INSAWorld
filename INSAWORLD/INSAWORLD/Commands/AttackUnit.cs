using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class AttackUnit : CommandMenu, ToCollect
    {
        private string state;

        /// <param name="u">unit which attack</param>
        /// <param name="d">pair of unit/coord of the attacked unit</param>
        /// <param name="game">reference to the game to obtain the map</param>
        private Unit unit;
        private Unit def;
        private int lostLifeSave;
        private Game game;

        public AttackUnit(Unit u, Unit d, ref Game g)
        {
            unit = u;
            def = d;
            game = g;
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public bool CanExecute()
        {
            return unit.Race.TryMove(unit, def.C, ref game);
        }

        /// <summary>
        /// call unit attack method and remove life points
        /// </summary>
        /// <returns>true if the attack has been done false if not</returns>
        public void Execute()
        {
            //use attack of unit
            int lostLife = unit.Attack(def.C, def, ref game);
            lostLifeSave = lostLife;
            if (lostLife > 0) //defender lost points
            {
                if (def.LifePoints < lostLife)
                {
                    def.LifePoints = 0;
                    game.Cleaner();
                    unit.Race.ActionMove(unit, def.C, ref game);
                }
                else { def.LifePoints -= lostLife; }
            }
            else if (lostLife < 0) //attacker lost points
            {
                lostLife = -lostLife;
                if (unit.LifePoints < lostLife)
                {
                    unit.LifePoints = 0;
                    game.Cleaner();
                }
                else { unit.LifePoints -= lostLife; }
            }

            ReplayCollector.Instance.AddStep(this);
        }
    }
}
