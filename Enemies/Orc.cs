using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Game
{
    class Orc : EnemyModel
    {

        private static Random rnd = new Random();
        private static List<string> orcAttacks = new List<string>()
        {
            "Orc goes Berserk",
            "Orc swings axe",
            "Orc shoots arrow"

        };
        public Orc()
        {
            Name = "Orc";
            Health = 100;
            MaxDmg = 14;
            MaxBlock = 2;
            Exp = 12;
            Gold = rnd.Next(1, 40);
            Level = 1;
        }
        public override void Attack(out int damage, out string description)
        {
            damage = rnd.Next((int)MaxDmg);
            description = orcAttacks[rnd.Next(0, 3)];
        }

        public override void Defence(out int defenceValue)
        {
            defenceValue = rnd.Next((int)MaxBlock);
        }

        /// <summary>
        /// Adding how much exp the monster give per level, and increase attack and block for each level.
        /// </summary>
        public override void LevelUp()
        {
            MaxDmg *= 1.06;
            MaxDmg = Math.Ceiling(MaxDmg);
            MaxBlock *= 1.06;
            MaxBlock = Math.Ceiling(MaxBlock);
            Level++;
            if (Level > 5 && Level < 7)
            {
                Exp += 50;
            }
            else if (Level >= 7)
            {
                Exp += 105;
            }
            else
            {
                Exp += 5;
            }
        }
    }
}
