using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public static class InitializeGame
    { /// <summary>
    /// Initialiserar spelet genom att låta spelaren välja vilken klass och namn, samt så initializeras fienderna och shopen.
    /// </summary>
        public static void Initialize()
        {
            InitializeEnemies();
        }
        private static void InitializeEnemies()
        {
            Program.enemies.Add(new Orc());
            Program.enemies.Add(new Troll());
            Program.enemies.Add(new Giant());
            Program.enemies.Add(new Zombie());
            Program.enemies.Add(new Vampire());
            ChooseClass();
        }
        private static void ChooseClass()
        {
            Dictionary<string, string> classInfo = new Dictionary<string, string>()
            {
                { "Mage", "The Mage class gives 2 extra Defence value. Starting weapon: Magic staff" },
                { "Ranged", "The Ranged class Gives 2 extra Attack value. Starting weapon: Bow"},
                { "Warrior", "The Warrior class Gives 2 extra Health value. Starting weapon: Sword"},
            };
            int chosenClass;
            bool parseSuccessful;

            Console.WriteLine("Choose a class for your character by picking the number next to the class you want to play as: \n");

            do
            {
                PrintDesign.PrintFrameWithClassInfo(classInfo);
                Console.Write("choose number: ");
                parseSuccessful = int.TryParse(Console.ReadLine(), out chosenClass);

                if (chosenClass > 3 || chosenClass <= 0 || parseSuccessful == false)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Class doesnt exists. Choose the number next to one of the classes below:\n");
                }

            } while (chosenClass > 3 || chosenClass <= 0 || parseSuccessful == false);

            List<string> classes = classInfo.Keys.ToList();
            Console.Clear();
            Console.WriteLine($"You chose the {classes[chosenClass - 1].ToUpper()} class\n");

            NameCharacter(classes[chosenClass - 1]);
        }
        private static void NameCharacter(string classOfCharacter)
        {
            string characterName;
            Console.WriteLine("Pick a name for your character:(max 25 characters)");
            do
            {

                Console.Write("Character name: ");
                characterName = Console.ReadLine();
                if (characterName.Length > 25)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Name contains to many characters\n");
                }
                else if (!characterName.Any(char.IsLetter))
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Name must contain at least one letter!\n");
                }
            } while (characterName.Length > 25 || !characterName.Any(char.IsLetter));

            Console.Clear();
            InitiliazePlayer(characterName, classOfCharacter);
        }

        private static void InitiliazePlayer(string characterName, string classOfCharacter)
        {
            Program.player = new Player(characterName, classOfCharacter);
            InitializeShop();
        }

        private static void InitializeShop()
        {
            Program.shop = new Shop();
        }
    }
}


