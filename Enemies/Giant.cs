using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Giant : EnemyModel
    {
     
        private static Random rnd = new Random();
        private static List<string> giantAttacks = new List<string>()
        {
            "Giant stomps on you",
            "Giant breaks of piece of mountain and throws at you",
            "Giant picks you up and throws you away"
        };

        public Giant()
        {
            Name = "Giant";
            Health = 100;
            MaxDmg = 20;
            MaxBlock = 1;
            Exp = 12;
            Gold = rnd.Next(1, 40);
            Level = 1;
        }
        public override void Attack(out int damage, out string description)
        {
            damage = rnd.Next(1, (int)MaxDmg);
            description = giantAttacks[rnd.Next(0, 3)];
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
