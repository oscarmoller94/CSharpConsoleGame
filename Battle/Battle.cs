using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Game
{
    class Battle
    {
        public static void StartFight(PlayerModel player, EnemyModel enemy)
        {
            Console.Clear();
            int expToGive = enemy.Exp;
            Console.WriteLine($"{player.Name} VS {enemy.Name}");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine($"{player.Name} health: {player.Health}");
                Console.WriteLine($"{enemy.Name} health: {enemy.Health}\n");
                if (GetAttackResult(player, enemy) == "Fight Over") // skickar in spelaren först (dvs spelaren attackerar) returneras stringen Fight Over så ges exp och loot.
                {
                    Console.Clear();

                    player.GainExp(expToGive);
                    PrintDesign.WriteLineInGreen($"\nYou won the fight! you gain {expToGive} Exp");

                    if (player.Level >= 10)
                    {
                        Program.WonGame();
                    }
                    GetLoot(enemy, player);
                    enemy.Health = 100;                    // full health inför varje ny fight.
                    player.Health = 100;
                    if (player.FightClass == "warrior")
                    {
                        player.Health = 102;
                    }
                    break;

                }
                Console.WriteLine($"{player.Name} health: {player.Health}");
                Console.WriteLine($"{enemy.Name} health: {enemy.Health}\n");
                if (GetAttackResult(enemy, player) == "Fight Over") // skickar in fienden först (dvs fienden attackerar)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("\nYou lost!");
                    Program.Exit();
                    break;
                }
            }
        }
        public static string GetAttackResult(IFightable fighterA, IFightable fighterB)
        {

            fighterA.Attack(out int atkValue, out string atkDescription); // hämtar attacken och värdet av den
            fighterB.Defence(out int defValue); // hämtar försvars värdet.
            int damage = atkValue - defValue;

            if (damage < 0)
            {
                damage = 0;
            }



            Console.WriteLine($"{atkDescription} and deals {damage} damage");
            fighterB.Health -= damage;
            if (fighterB.Health <= 0)
            {
                return "Fight Over";
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();

            return "keep fighting";
        }

        /// <summary>
        /// Hämtar loot ifall det finns och ifall spelaren vill plocka upp det.
        /// </summary>

        public static void GetLoot(EnemyModel enemy, PlayerModel player)
        {
            string answer;
            int lootValue;
            string loot = enemy.droppedLoot(out lootValue);
            if (loot == null)
            {
                PrintDesign.WriteLineInGreen($"You search dead {enemy.Name} and find {enemy.Gold} gold, but no additional loot.");
                player.Gold += enemy.Gold;
            }
            else
            {
                PrintDesign.WriteLineInGreen($"You search dead {enemy.Name} and find {enemy.Gold} gold, and {loot} (worth: {lootValue} coins).");
                player.Gold += enemy.Gold;
                do
                {
                    Console.WriteLine($"Do you want to pick up {loot}? Y/N");
                    answer = Console.ReadLine().ToLower().Replace(" ", "");

                    if (answer == "y")
                    {
                        Console.Clear();

                        if (Player.backpack.ContainsKey(loot))
                        {
                            PrintDesign.WriteLineInRed("You already own this item!");
                        }
                        else
                        {
                            Player.backpack.Add(loot, lootValue);
                            PrintDesign.WriteLineInGreen($"{loot} added to backpack!");
                        }
                    }
                    if (answer != "y" && answer != "n")
                    {
                        Console.Clear();
                        PrintDesign.WriteLineInRed("Invalid input! Try again.");
                    }
                } while (answer != "y" && answer != "n");


            }
        }
    }
}

