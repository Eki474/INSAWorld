using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class AttackUnit : CommandMenu, ToCollect
    {
        /// <param name="unit">unit which attack</param>
        private Unit unit;
        /// <param name="def">attacked unit</param>
        private Unit def;
        /// <param name="lostLifeSave">how many life points the unit loses</param>
        private int lostLifeSave;
        /// <param name="game">reference to the game</param>
        private Game game;

        private String typeName = "AttackUnit";

        public string TypeName
        {
            get
            {
                return typeName;
            }
        }

        public Unit Unit
        {
            get
            {
                return unit;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="u">unit which attack</param>
        /// <param name="d">attacked unit</param>
        /// <param name="g">reference to the game</param>
        public AttackUnit(Unit u, Unit d, ref Game g)
        {
            unit = u;
            def = d;
            game = g;
        }

        // attack,unit.Id,def.Id,lostLifeSave
        public AttackUnit(string[] s, ref Game g)
        {
            lostLifeSave = int.Parse(s[3]);
            int ida = int.Parse(s[1]);
            int idd = int.Parse(s[2]);
            var l1 = g.Player1.UnitsList;
            var l2 = g.Player2.UnitsList;
            foreach (Unit u in l1.Concat(l2))
            {
                if (u.Id == ida) { unit = u; }
                if (u.Id == idd) { def = u; }
            }
            game = g;
        }

        /// <summary>
        /// verify if the unit whick attacks can move to the target unit
        /// </summary>
        /// <returns>true if yes, false if not</returns>
        public bool CanExecute()
        {
            return unit.Race.TryMove(unit, def.C, ref game);
        }

        /// <summary>
        /// call unit attack method and remove life points
        /// </summary>
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

                unit.Played = true;
            }
            else if (lostLife < 0) //attacker lost points
            {
                lostLife = -lostLife;
                if (unit.LifePoints < lostLife)
                {
                    unit.LifePoints = 0;
                    game.Cleaner();
                }
                else { unit.LifePoints -= lostLife; 
                unit.Played = true;}
            }
            game.Rpz.AddStep(this);
        }

        /// <summary>
        /// execute without stocking into step and without re-doing the proba attack (for replay only)
        /// </summary>
        public void ExecuteReplay()
        {
            //use attack of unit
            int lostLife = lostLifeSave;
            if (lostLife > 0) //defender lost points
            {
                if (def.LifePoints < lostLife)
                {
                    def.LifePoints = 0;
                    game.Cleaner();
                    unit.Race.ActionMove(unit, def.C, ref game);
                }
                else { def.LifePoints -= lostLife; }

                unit.Played = true;
            }
            else if (lostLife < 0) //attacker lost points
            {
                lostLife = -lostLife;
                if (unit.LifePoints < lostLife)
                {
                    unit.LifePoints = 0;
                    game.Cleaner();
                }
                else
                {
                    unit.LifePoints -= lostLife;
                    unit.Played = true;
                }
            }
            //game.Rpz.AddStep(this);
        }

        /// <summary>
        /// for ReplayCollector
        /// </summary>
        /// <returns>attack,unit.Id,def.Id,lostLifeSave</returns>
        override
        public string ToString()
        {
            return "attack,"+unit.Id+","+def.Id+","+lostLifeSave;
        }

    }
}
