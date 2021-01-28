using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Program
    {
        public static Random rnd = new Random();
        public static List<EnemyModel> enemies = new List<EnemyModel>();
        public static Player player;
        public static Shop shop;
        static void Main(string[] args)
        {
            RunGame();
        }

        private static void RunGame()
        {
            Console.WriteLine("WELCOME!");
            InitializeGame.Initialize();
            do
            {
                MainMenu(player);
            } while (player.Level < 10);
            WonGame();
          
        }
        public static void MainMenu(Player player)
        {
            int userChoice;
            bool parseSuccessful;
            do
            {
                Console.WriteLine("\nSelect an action from the menu: ");
                Console.WriteLine($"1. take {player.Name} adventuring");
                Console.WriteLine($"2. show details about {player.Name}");
                Console.WriteLine("3. Open backpack");
                Console.WriteLine("4. Visit shop");
                PrintDesign.WriteLineInRed("5. Play with GodMode");
                PrintDesign.WriteLineInRed("6. Exit game");
                Console.Write("\nChoice: ");
                
                parseSuccessful = int.TryParse(Console.ReadLine(), out userChoice);

                if (userChoice <= 0)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Chosen number to small, pick a number between 1 and 4 in the menu");
                }
                else if (userChoice > 4)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Chosen number to big, pick a number between 1 and 4 in the menu");
                }
                else if (parseSuccessful == false)                                                                              // denna behövs egentligen inte då ints default är 0, men varför inte :)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Something went wrong with your input. Pick a number between 1 and 4 in the menu");
                }

                MenuAction(userChoice);

            } while (userChoice < 0 || userChoice > 6 || parseSuccessful == false);


        }
        public static void MenuAction(int choice)
        {
            switch (choice)
            {
                case 1:
                    if(rnd.Next(1,11) == 10)
                    {
                        Console.WriteLine("You walk by without seeing any enemies!");
                        Console.Clear();
                    }
                    else
                    {
                        Battle.StartFight(player, enemies[rnd.Next(enemies.Count)]);   // skickar med spelaren och en random vald fiende i listan
                    }   
                    break;
                case 2:
                    player.PlayerInfo();
                    break;
                case 3:
                    if(Player.backpack.Count == 0)
                    {
                        Console.Clear();
                        PrintDesign.WriteLineInRed("Backpack is currently empty!");
                    }
                    else
                    {
                        PrintDesign.PrintBackpack(Player.backpack);

                    }
                    break;
                case 4:
                    shop.ShopMenu(player);
                    break;
                case 5:
                    player.GodMode();
                    break;
                case 6:
                    Exit();
                    break;


                default:
                    break;
            }
        }
        public static void WonGame()
        {
            Console.Clear();
            Console.WriteLine("You won the game!");
            Console.WriteLine("Thank you for playing!!");
            Environment.Exit(0);
        }

        public static void Exit()
        {
            Console.Clear();
            PrintDesign.WriteLineInGreen("Thank you for playing! See you next time");
            Environment.Exit(0);
        }
    }
}
