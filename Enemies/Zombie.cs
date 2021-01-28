using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Zombie : EnemyModel, IFightable
    {
        private static Random rnd = new Random();
        private static List<string> zombieAttacks = new List<string>()
        {
            "Zombie summon two of his skeleton homies who charge you",
            "Zombie removes his arm and throws at you",
            "Zombie spreads his death breath on you"

        };
        public Zombie()
        {
            Name = "Zombie";
            Health = 100;
            MaxDmg = 18;
            MaxBlock = 4;
            Exp = 12;
            Gold = rnd.Next(1, 40);
            Level = 1;
        }
        public override void Attack(out int damage, out string description)
        {
            damage = rnd.Next((int)MaxDmg);
            description = zombieAttacks[rnd.Next(0, 3)];
        }

        public override void Defence(out int defenceValue)
        {
            defenceValue = rnd.Next((int)MaxBlock);
        }

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
