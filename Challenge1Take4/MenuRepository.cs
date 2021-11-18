using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Take4
{
    class MenuRepository
    {
        private List<Menu> _menuOfFood = new List<Menu>();
        public List<Menu> MenuOfFood { get; set; }

        //Create
        public void AddFoodToMenu(Menu menu)
        {
            _menuOfFood.Add(menu);
        }

        //Read
        public List<Menu> GetMenu()
        {
            return _menuOfFood;
        }
        //Update
        public void UpdateExistingFood(string originalName, Menu newmenu)
        {
            //Find the content
            Menu oldmenu = GetFoodByName(originalName);

            //Update the content
            if (oldmenu != null)
            {
                //A
                oldmenu.Name = newmenu.Name;
                //B
                oldmenu.Number = newmenu.Number;
                //C
                oldmenu.Description = newmenu.Description;
                //D
                oldmenu.Ingredients = newmenu.Ingredients;
                //E
                oldmenu.Price = newmenu.Price;

            }
        }

        //Delete
        public bool RemoveFoodFromMenu(string name)
        {
            Menu menu = GetFoodByName(name);

            if (menu == null)
            {
                return false;
            }

            int initialCount = _menuOfFood.Count;
            _menuOfFood.Remove(menu);

            if (initialCount > _menuOfFood.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public Menu GetFoodByName(string name)
        {
            foreach (Menu menu in _menuOfFood)
            {
                if (menu.Name == name)
                {
                    return menu;
                }
            }

            return null;
        }
    }
}
