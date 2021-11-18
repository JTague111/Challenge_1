using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Challenge1Take4
{
    class App
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Start()
        {
            SeedMenuList();
            Title = "Komodo Insurance";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"
     )                                                
  ( /(                 (           (       (          
  )\())      )         )\ )        )\     ))\ )   (   
|((_)\ (    (     (   (()/( (    (((_) ( /(()/(  ))\  
|_ ((_))\   )\  ' )\   ((_)))\   )\___ )(_))(_))/((_) 
| |/ /((_)_((_)) ((_)  _| |((_) ((/ __((_)(_) _(_))   
  ' </ _ \ '  \() _ \/ _` / _ \  | (__/ _` |  _/ -_)  
 _|\_\___/_|_|_|\___/\__,_\___/   \___\__,_|_| \___|  

Hello proprietor of Komodo Cafe. Please enter Desired Course of action.";
            string[] options = { "See all items", "Delete item", "Add item", "Exit" };
            Selection mainMenu = new Selection(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunSeeItems();
                    break;
                case 1:
                    RunDeleteItems();
                    break;
                case 2:
                    RunAddItems();
                    break;
                case 3:
                    RunExit();
                    break;

            }
        }
        private void RunSeeItems()
        {
            Clear();
            List<Menu> menuOfFood = _menuRepo.GetMenu();

            foreach (Menu menu in menuOfFood)
            {
            WriteLine($"Item Number: {menu.Number}\n" +
                $"Name: {menu.Name}\n" +
                $"Description: {menu.Description}\n" +
                $"Ingredients: {menu.Ingredients}\n" +
                $"Price: {menu.Price}");
            }
            WriteLine("Press any key to continue");
            ReadKey();
            RunMainMenu();
        }
        private void RunSeeItems1()
        {
            Clear();
            List<Menu> menuOfFood = _menuRepo.GetMenu();

            foreach (Menu menu in menuOfFood)
            {
                WriteLine($"Item Number: {menu.Number}\n" +
                    $"Name: {menu.Name}\n" +
                    $"Description: {menu.Description}\n" +
                    $"Ingredients: {menu.Ingredients}\n" +
                    $"Price: {menu.Price}");
            }
        }

        private void RunDeleteItems()
        {
            Clear();
            RunSeeItems1();
            WriteLine("Enter the name of the item you'd like to remove:");

            string input = ReadLine();

            bool wasDeleted = _menuRepo.RemoveFoodFromMenu(input);

            if (wasDeleted)
            {
                WriteLine("The item was succesfully deleted.");
            }
            else
            {
                WriteLine("The item could not be deleted.");
            }
            RunMainMenu();
        }
        private void RunAddItems()
        {
            Clear();
            Menu newmenu = new Menu();
            //Name
            WriteLine("Enter name for new item:");
            newmenu.Name = ReadLine().Trim();
            //Description
            WriteLine("Enter Description for new item:");
            newmenu.Description = ReadLine().Trim();
            //Number
            WriteLine("Enter the Meal Number for the new item:");
            string mealNumberString = ReadLine().Trim();
            newmenu.Number = int.Parse(mealNumberString);
            //Ingredients
            WriteLine("Enter list of ingredients:");
            newmenu.Ingredients = ReadLine().Trim();
            //Price
            WriteLine("Enter the Price for the new item:");
            string mealPriceString = ReadLine().Trim();
            newmenu.Price = double.Parse(mealPriceString);

            _menuRepo.AddFoodToMenu(newmenu);

            RunMainMenu();
        }
        private void RunExit()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void SeedMenuList()
        {
            Menu croissant = new Menu(1, "Croissant", "Flaky and buttery rolls from France", "Butter, Flour, Salt, Bakingpowder", 2.50);
            Menu donut = new Menu(2, "Donut", "Fluffy yeast donuts with an array of different icings and fillings", "Yeast, Flour, Sugar, Baking Powder, Salt, (Jelly), (Nuts) Jelly and nuts depend on type of donut bought.", 0.90);
            Menu cookie = new Menu(3, "Cookie", "Warm Freshly baked chocolate chip cookie", "chocolate chips, Flour, Baking Powder, Olive Oil, Salt, Vanilla", 3.00);

            _menuRepo.AddFoodToMenu(croissant);
            _menuRepo.AddFoodToMenu(donut);
            _menuRepo.AddFoodToMenu(cookie);

        }
    }
}
