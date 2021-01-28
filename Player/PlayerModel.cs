using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
     abstract class PlayerModel : IFightable
    {
        public string FightClass { get; set; }
        public int TotalExpGained { get; set; }
        public int ExpNeededToLevelUp { get; set; }
        public int ExpLeftUntilLevelUp { get; set; }
        public string Weapon { get; set; }
        public string Armor { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public string Name { get; set; }
        public double MaxDmg { get; set; }
        public double MaxBlock { get; set; }
        public double Health { get; set; }
        public string SpecialItem { get; set; }

        public abstract void Attack(out int attackValue, out string description);
        public abstract void Defence(out int defenceValue);

        public abstract void GainExp(int exp);
        public abstract void LevelUp();
       
    }
}
