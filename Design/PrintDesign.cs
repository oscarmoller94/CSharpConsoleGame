using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Game
{
    /// <summary>
    /// En klass för att förenkla design i consolen.
    /// </summary>
    public static class PrintDesign
    {
        public static StringBuilder frameTop = new StringBuilder();
        public static StringBuilder frameBottom = new StringBuilder();

        /// <summary>
        /// Använder stringbuilder för att skriva ut en fin liten ram och info om de olika klasserna.
        /// </summary>
        public static void PrintFrameWithClassInfo(Dictionary<string, string> information)
        {
            int counter = 1;
            foreach (var info in information)
            {
                frameTop.Append('*', 20).Append($"[{counter}]{info.Key.ToUpper()}").Append('*', 20);
                frameBottom.Append('*', frameTop.Length);

                Console.Write($"{frameTop}\n");
                FormatStringToFitFrame(info.Value);
                Console.WriteLine($"{frameBottom}\n");
                frameTop.Clear();
                frameBottom.Clear();
                counter++;
            }

        }
        /// <summary>
        /// Används för att få plats inom "ramen" där classinformationen skrivs ut
        /// </summary>
        static void FormatStringToFitFrame(string sentence)
        {
            int wordLimit = 50;
            string[] words = sentence.Split(' ');

            StringBuilder newSentence = new StringBuilder();


            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > wordLimit)
                {
                    newSentence.AppendLine(line);
                    line = "";
                }

                line += string.Format($"{word} ");
            }

            if (line.Length > 0)
            {
                newSentence.AppendLine(line);
            }

            Console.Write(newSentence);
        }
        /// <summary>
        /// Skriver ut all info om spelaren till konsolen i en fin liten ram.
        /// </summary>

        public static void PrintFrameWithPlayerInfo(string name, int level, string fightClass, double health, double maxDmg, double maxBlock, string weapon, string armor, string specialItem, int expNeddedtoLevelUp, int gold)
        {
            
            frameTop.Append('*', 20).Append("Player").Append('*', 20);
            frameBottom.Append('*', frameTop.Length);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{frameTop}\n");
            Console.Write("Name: ");
            Console.WriteLine(name);
            Console.Write("level: ");
            Console.WriteLine($"{level}  ({expNeddedtoLevelUp} Exp Left until level {level + 1})");
            Console.Write("Class: ");
            Console.WriteLine(fightClass);
            Console.Write("Health: ");
            Console.WriteLine(health.ToString());
            Console.Write("Attack value: ");
            Console.WriteLine(maxDmg.ToString());
            Console.Write("Defence value: ");
            Console.WriteLine(maxBlock.ToString());
            Console.Write("Current weapon: ");
            Console.WriteLine(weapon);
            Console.Write("Armor: ");
            Console.WriteLine(armor);
            Console.Write("Special item: ");
            Console.WriteLine(specialItem);
            Console.Write("Gold: ");
            Console.WriteLine(gold.ToString());
            Console.WriteLine($"{frameBottom}\n");
            frameTop.Clear();
            frameBottom.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Skriver ut innehållet i spelarens backpack till consolen i en ram runt
        /// </summary>
        public static void PrintBackpack(Dictionary<string, int> items)
        {
            Console.Clear();
            StringBuilder print = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.Green;
            frameTop.Append('*', 20).Append("Backpack").Append('*', 20);
            frameBottom.Append('*', frameTop.Length);
            Console.Write($"{frameTop}\n");

            foreach (var item in items)
            {
                string value = item.Value.ToString();
                print.Append($"{item.Key.PadRight(25)}");
                print.Append(" | ");
                print.Append($"VALUE: {value.PadRight(20)}");
                Console.WriteLine($"{print}");
                print.Clear();

            }
            Console.WriteLine($"{frameBottom}\n");
            frameTop.Clear();
            frameBottom.Clear();
            Console.ForegroundColor = ConsoleColor.White;

        }
        /// <summary>
        /// Skriver ut saker som är till salu i shopen
        /// </summary>
        public static void PrintShop(Dictionary<string, int> pricedItems)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            StringBuilder print = new StringBuilder();
            frameTop.Append('*', 20).Append("Shop").Append('*', 20);
            frameBottom.Append('*', frameTop.Length);
            Console.Write($"{frameTop}\n");
            int counter = 1;
            foreach (var item in pricedItems)
            {
                string value = item.Value.ToString();
                print.Append($"{item.Key.PadRight(25)}");
                print.Append(" | ");
                print.Append($"VALUE: {value.PadRight(20)}");
                Console.WriteLine($"[{counter}] {print}");
                counter++;
                print.Clear();

            }
            Console.WriteLine($"{frameBottom}\n");
            frameTop.Clear();
            frameBottom.Clear();
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void WriteLineInRed(string stringToPaint)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(stringToPaint);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLineInYellow(string stringToPaint)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(stringToPaint);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLineInGreen(string stringToPaint)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(stringToPaint);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteInRed(string stringToPaint)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(stringToPaint );
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
