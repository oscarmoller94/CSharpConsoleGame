using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Player : PlayerModel
    {
        public static bool PlayGodMode = false;
        public static Dictionary<string, int> backpack = new Dictionary<string, int>();
        public static Random rnd = new Random();

      
        public Player(string name, string fightClass) // initializing start värden for spelaren
        {
            Name = name;
            FightClass = fightClass;                       
            Armor = "Regular shirt";
            SpecialItem = "None";
            Health = 100;
            MaxDmg = 30;
            MaxBlock = 5;
            Level = 1;
            Gold = 0;
            TotalExpGained = 0;
            ExpLeftUntilLevelUp = 15;
            ExpNeededToLevelUp = 15;
            PopulateFightClassValues();

        }

        /// <summary>
        /// Ger spelaren olika vapen och start värden beroende på vilken klass användaren väljer.
        /// </summary>
        private void PopulateFightClassValues()
        {
            if (FightClass == "Warrior")
            {
                Weapon = "Sword";
                Health += 2;
            }
            else if (FightClass == "Ranged")
            {
                Weapon = "Bow";
                MaxDmg += 2;
            }
            else if (FightClass == "Mage")
            {
                Weapon = "Magic staff";
                MaxBlock += 2;
            }
        }
        public override void Attack(out int attackValue, out string attackDescription) // använder out för att kunna använda båda värderna i battle classen sedan. Attacken beskrvis och ett random värde beroende på ens maxDmg.
        {
            attackValue = rnd.Next((int)MaxDmg);
            attackDescription = $"{Name} uses {Weapon}";       
        }
        public override void Defence(out int defenceValue)
        {
            defenceValue = rnd.Next((int)MaxBlock);
        }
        public override void GainExp(int exp)
        {
            TotalExpGained += exp;
            ExpLeftUntilLevelUp -= exp;

            if (TotalExpGained >= ExpNeededToLevelUp)   // ifall man har tillräckligt mycket exp för att levla upp kallas LevelUp metoden på.
            {
                LevelUp();
            }
        }
        /// <summary>
        /// Ökar maxblock och maxdmg för varje level. Här används också en formel för att öka exp som behövs för nästa level. Härifrån levlas även alla enemies upp.
        /// </summary>
        public override void LevelUp()
        {
            Level++;

            MaxDmg *= 1.05;
            MaxDmg = Math.Ceiling(MaxDmg);
            MaxBlock *= 1.05;
            MaxBlock = Math.Ceiling(MaxBlock);

            double expModifier = Math.Pow(1.05, Level);
            ExpNeededToLevelUp = (int)Math.Floor(TotalExpGained * expModifier);
            ExpLeftUntilLevelUp = ExpNeededToLevelUp;
            TotalExpGained = 0;
            Console.WriteLine($"\nYou advanced from level {Level - 1} to {Level}");

            foreach (var enemy in Program.enemies)
            {
                enemy.LevelUp();
            }
            
        }
        public void PlayerInfo()
        {
            Console.Clear();
            PrintDesign.PrintFrameWithPlayerInfo(Name, Level, FightClass, Health, MaxDmg, MaxBlock, Weapon, Armor, SpecialItem, ExpLeftUntilLevelUp, Gold);
        }
        public void GodMode()
        {
            if (PlayGodMode == true)
            {
                Console.Clear();
                PrintDesign.WriteLineInRed("You already play with godmode!");
                    
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Have fun with Godmode!");
                MaxBlock += 1000;
                MaxDmg += 80;
                Gold = 9999999;
                PlayGodMode = true;
            }
            
        }
    }
}
