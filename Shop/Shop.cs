using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    /// <summary>
    ///Tillåter spelaren att handla varor i Shop
    /// </summary>
    class Shop
    {

        public int ExtraHealthFromItems { get; set; }
        public int ExtraDamageFromWeapons { get; set; }
        public int ExtraDefenceFromArmor { get; set; }


        public Dictionary<string, int> weaponsToSell = new Dictionary<string, int>();
        public Dictionary<string, int> armorsToSell = new Dictionary<string, int>();
        public Dictionary<string, int> specialItemsToSell = new Dictionary<string, int>();

        public Shop()
        {


            if (Program.player.FightClass == "Warrior")                     // adderar "set" av vapen beorende på vad spelaren är för klass. 
            {
                weaponsToSell.Add("Shining sword (+3 damage)", 100);
                weaponsToSell.Add("Serpent sword (+5 damage)", 200);
                weaponsToSell.Add("Broad sword (+7 damage)", 300);
            }
            else if (Program.player.FightClass == "Ranged")
            {
                weaponsToSell.Add("Throwing knives(+3 damag)", 100);
                weaponsToSell.Add("Crossbow (+5 damage)", 200);
                weaponsToSell.Add("Longbow (+7 damage)", 300);
            }
            else if (Program.player.FightClass == "Mage")
            {
                weaponsToSell.Add("Fire staff     (+3 damage)", 100);
                weaponsToSell.Add("Electric staff (+5 damage)", 200);
                weaponsToSell.Add("Water staff (+7 damage)", 300);
            }

            armorsToSell.Add("Leather armor(+3 defence)", 100);             // adderar armors
            armorsToSell.Add("Chain armor (+5 defence)", 200);
            armorsToSell.Add("Steel armor (+7 defence)", 300);

            specialItemsToSell.Add("Lucky coin (+1 health)", 100);        // adderar special item
            specialItemsToSell.Add("Necklace (+2 health)", 200);
            specialItemsToSell.Add("Magic ring (+3 Health)", 300);
        }

        public void ShopMenu(Player customer)
        {
            int choice;
            bool parseSuccessfull;
            Console.Clear();
            PrintDesign.WriteLineInYellow("Welcome to the shop!");
            do
            {

                PrintDesign.WriteLineInYellow("1. Show weapons for sale");
                PrintDesign.WriteLineInYellow("2. Show armor for sale");
                PrintDesign.WriteLineInYellow("3. Show special items for sale");
                PrintDesign.WriteLineInYellow("4. Sell items");
                PrintDesign.WriteLineInYellow("5. Back to main menu");
                parseSuccessfull = int.TryParse(Console.ReadLine(), out choice);

                if (parseSuccessfull == false)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Something went wrong! Try again.");
                }

                if (choice > 5)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Number to high, choose a number between 1 and 5.");
                }
                else if (choice <= 0)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Number to low, choose a number between 1 and 5.");
                }

                MenuAction(choice, customer);

            } while (choice != 5);

            Console.ForegroundColor = ConsoleColor.White;


        }

        private void MenuAction(int choice, Player customer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            switch (choice)
            {
                case 1:
                    WeaponAvailableForSell(customer);
                    break;
                case 2:
                    ArmorsAvaliableForSell(customer);
                    break;
                case 3:
                    SpecialItemsAvaliableForSell(customer);
                    break;
                case 4:
                    SellItems(customer);
                    break;
                case 5:
                    Console.Clear();
                    PrintDesign.WriteLineInYellow("Thank you for visiting the shop! Welcome back anytime.");
                    break;
                default:
                    break;
            }
        }
        private void WeaponAvailableForSell(Player customer)
        {
            var listOfWeaponNames = weaponsToSell.Keys.ToList();
            var listOfWeaponPrices = weaponsToSell.Values.ToList();
            int choice;
            bool parseSuccessfull;

            Console.Clear();
            Console.WriteLine($"Weapons avaliable for the {customer.FightClass}:");
            do
            {
                
                PrintDesign.WriteLineInGreen($"\nGold in wallet: {customer.Gold}");
                PrintDesign.PrintShop(weaponsToSell);
                Console.Write("Number: ");

                parseSuccessfull = int.TryParse(Console.ReadLine(), out choice);

                if (choice <= 0)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Chosen number to small!");
                }
                else if (parseSuccessfull == false)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Something went wrong!");
                }
                else if (choice >= 4)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Chosen number to high!");
                }

            } while (choice >= 4 || choice <= 0 || parseSuccessfull == false);

            if (listOfWeaponPrices[choice - 1] > customer.Gold)
            {
                Console.Clear();
                PrintDesign.WriteLineInRed($"You dont have enough money to buy {listOfWeaponNames[choice - 1]}!");
            }

            else if (customer.Weapon == listOfWeaponNames[choice - 1])
            {
                Console.Clear();
                PrintDesign.WriteLineInRed($"You already own {listOfWeaponNames[choice - 1]}!");
            }
            else
            {
                Console.Clear();
                PrintDesign.WriteLineInGreen($"\n{listOfWeaponNames[choice - 1]} bought and equipped!");
                customer.Weapon = listOfWeaponNames[choice - 1];
                customer.Gold -= listOfWeaponPrices[choice - 1];

                if (choice == 1)
                {
                    customer.MaxDmg -= ExtraDamageFromWeapons;
                    ExtraDamageFromWeapons = 3;
                    customer.MaxDmg += ExtraDamageFromWeapons;
                }
                if (choice == 2)
                {
                    customer.MaxDmg -= ExtraDamageFromWeapons;
                    ExtraDamageFromWeapons = 5;
                    customer.MaxDmg += ExtraDamageFromWeapons;
                }
                if (choice == 3)
                {
                    customer.MaxDmg -= ExtraDamageFromWeapons;
                    ExtraDamageFromWeapons = 7;
                    customer.MaxDmg += ExtraDamageFromWeapons;
                }
            }
        }
        private void ArmorsAvaliableForSell(Player customer)
        {
            var listOfArmorNames = armorsToSell.Keys.ToList();
            var listOfArmorPrices = armorsToSell.Values.ToList();
            int choice;
            bool parseSuccessfull;
            do
            {
                ;
                PrintDesign.WriteLineInGreen($"\nGold in wallet: {customer.Gold}");
                PrintDesign.PrintShop(armorsToSell);
                Console.Write("Number: ");

                parseSuccessfull = int.TryParse(Console.ReadLine(), out choice);

                if (choice <= 0)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Chosen number to small!");
                }
                else if (parseSuccessfull == false)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Something went wrong!");
                }
                else if (choice >= 4)
                {
                    Console.Clear();
                    PrintDesign.WriteLineInRed("Chosen number to high!");
                }

            } while (choice >= 4 || choice <= 0 || parseSuccessfull == false);

            if (listOfArmorPrices[choice - 1] > customer.Gold)
            {
                Console.Clear();
                PrintDesign.WriteLineInRed($"You dont have enough money to buy {listOfArmorNames[choice - 1]}!");
            }

            else if (customer.Armor.Contains(listOfArmorNames[choice - 1]))
            {
                Console.Clear();
                PrintDesign.WriteLineInRed($"You already {listOfArmorNames[choice - 1]}!");
            }
            else
            {
                PrintDesign.WriteLineInGreen($"\n{listOfArmorNames[choice - 1]} bought and equipped!");
                customer.Armor = listOfArmorNames[choice - 1];
                customer.Gold -= listOfArmorPrices[choice - 1];

                if (choice == 1)
                {
                    customer.MaxBlock -= ExtraDefenceFromArmor; // tar bort nuvarande bonusen från armor
                    ExtraDefenceFromArmor = 3;
                    customer.MaxBlock += ExtraDefenceFromArmor; // addrar bonusen från den nyköpta armor
                }
                if (choice == 2)
                {
                    customer.MaxBlock -= ExtraDefenceFromArmor;
                    ExtraDefenceFromArmor = 5;
                    customer.MaxBlock += ExtraDefenceFromArmor;
                }
                if (choice == 3)
                {
                    customer.MaxBlock -= ExtraDefenceFromArmor;
                    ExtraDefenceFromArmor = 7;
                    customer.MaxBlock += ExtraDefenceFromArmor;
                }

            }
        }
        private void SpecialItemsAvaliableForSell(Player customer)
        {

            var listOfItemNames = specialItemsToSell.Keys.ToList();  // hämmtar namnet på special item till salu
            var listOfItemPrices = specialItemsToSell.Values.ToList(); // hämtar värdet på special item till salu.
            int choice;
            bool parseSuccessfull;
            do
            {
                
                PrintDesign.WriteLineInGreen($"\nGold in wallet: {customer.Gold}");
                PrintDesign.PrintShop(specialItemsToSell);
                Console.Write("Number: ");

                parseSuccessfull = int.TryParse(Console.ReadLine(), out choice);

                if (choice < 0)
                {
                    PrintDesign.WriteLineInRed("Chosen number to small!");
                }
                else if (parseSuccessfull == false)
                {
                    PrintDesign.WriteLineInRed("Something went wrong!");
                }
                else if (choice > 4)
                {
                    PrintDesign.WriteLineInRed("Chosen number to high!");
                }

            } while (choice >= 4 || choice <= 0 || parseSuccessfull == false);

            if (listOfItemPrices[choice - 1] > customer.Gold)
            {
                Console.Clear();
                PrintDesign.WriteLineInRed($"You dont have enough money to buy {listOfItemNames[choice - 1]}!");
            }

            else if (customer.SpecialItem == listOfItemNames[choice - 1])
            {
                Console.Clear();
                PrintDesign.WriteLineInRed($"You already own {listOfItemNames[choice - 1]}!");
            }
            else
            {
                Console.Clear();
                PrintDesign.WriteLineInGreen($"\n{listOfItemNames[choice - 1]} bought and equipped!");
                customer.SpecialItem = listOfItemNames[choice - 1]; // adderar special item till spelaren
                customer.Gold -= listOfItemPrices[choice - 1]; // tar bort det antal guld från spelaren som den köpta varan kostar.

                if (choice == 1)
                {
                    customer.Health -= ExtraHealthFromItems;
                    ExtraHealthFromItems = 1;
                    customer.Health += ExtraHealthFromItems;
                }
                if (choice == 2)
                {
                    customer.Health -= ExtraHealthFromItems;
                    ExtraHealthFromItems = 2;
                    customer.Health += ExtraHealthFromItems;
                }
                if (choice == 3)
                {
                    customer.Health -= ExtraHealthFromItems;
                    ExtraHealthFromItems = 3;
                    customer.Health += ExtraHealthFromItems;
                }

            }
        }
        private void SellItems(Player customer)
        {
            var backpackItemsName = Player.backpack.Keys.ToList();  // hämmtar namnet på sakerna i backpacken
            var backpackItemsValue = Player.backpack.Values.ToList(); // hämtar värdet på sakerna i backpacken
            int choice;
            bool parseSuccessfull;
            if (Player.backpack.Count == 0)
            {
                Console.Clear();
                PrintDesign.WriteLineInRed("You have nothing to sell!");
            }
            else
            {
                do
                {
                    PrintDesign.PrintShop(Player.backpack);
                    Console.WriteLine("Select the number next to the item that you want to sell: ");
                    Console.Write("Number: ");
                    parseSuccessfull = int.TryParse(Console.ReadLine(), out choice);
                    if (choice > Player.backpack.Count + 1)
                    {
                        Console.Clear();
                        PrintDesign.WriteLineInRed("Number to high. Choose one of the numbers infront of the items");
                    }
                    else if (choice <= 0)
                    {
                        Console.Clear();
                        PrintDesign.WriteLineInRed("Number to low. Choose one of the numbers infront of the items");
                    }
                    else if (parseSuccessfull == false)
                    {
                        Console.Clear();
                        PrintDesign.WriteLineInRed("Something went wrong! Try again");
                    }

                } while (choice > Player.backpack.Count + 1 || choice <= 0 || parseSuccessfull == false);
                Console.Clear();
                PrintDesign.WriteLineInGreen($"\nSold {backpackItemsName[choice - 1]} for {backpackItemsValue[choice - 1]} gold");
                customer.Gold += backpackItemsValue[choice - 1]; // adderar guldet för den sålda varan till spelaren
                Player.backpack.Remove(backpackItemsName[choice - 1]); // tar bort sålda varan från ryggsäcken
            }

        }
    }
}
