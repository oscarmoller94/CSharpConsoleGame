using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    abstract class EnemyModel : IFightable
    {
        public int Exp { get; set; }
        public string Name { get; set; }
        public double Health { get; set; }
        public double MaxDmg { get ; set; }
        public double MaxBlock { get; set ; }
        public int Gold { get; set; }
        public int Level { get; set; }

        Random rnd = new Random();
        public Dictionary<string, int> lootToDrop = new Dictionary<string, int>()
        {

            { "Silver ring", 50},
            { "Small diamond", 100 },
            { "Junk", 1},
            { "Broken knife", 5}
        };
        /// <summary>
        /// andom tal mellan 0 och 14. Ifall talet är mellan 0 och 3 så hämtas det indexet direkt från loot dictionaryn.
        /// </summary>
        public string droppedLoot(out int lootValue)
        {
            int value = rnd.Next(0, 15);
            if (value > 3)
            {
                lootValue = 0;
                return null;
            }
            else
            {
                var listOfValues = lootToDrop.Values.ToList();
                lootValue = listOfValues[value];
                var nameOfItems = lootToDrop.Keys.ToList();
                return nameOfItems[value];
            }
        }

        public abstract void Attack(out int attackValue, out string description);
        public abstract void Defence(out int defenceValue);
        public abstract void LevelUp();
    }
}
