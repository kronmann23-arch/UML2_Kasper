using PizzaLibrary.Data;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<MenuItem> _menuItemlist;
        public int Count { get { return _menuItemlist.Count; } }

        public MenuItemRepository()
        {
            //_menuItemlist = new List<MenuItem>();
            _menuItemlist = MockData.MenuItemData;
        }
        public void AddMenuItem(MenuItem menuItem)
        {
            if (!MenuItemNameExist(menuItem.Name))
            {
                _menuItemlist.Add(menuItem);
            }
            
               

        }
        private bool MenuItemNameExist(string name)
        {
            foreach (MenuItem m in _menuItemlist)
            {
                if (m.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemlist;
        }

        public MenuItem GetMenuItemByNo(int no)
        {
            foreach (MenuItem i in _menuItemlist)
            {
                if (i.No == no)
                {
                    return i;
                }
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            foreach (MenuItem i in _menuItemlist)
            {
                Console.WriteLine(i);
            }
        }

        public void RemoveMenuItem(int no)
        {
            for (int i = 0; i < _menuItemlist.Count; i++)
            {
                if (_menuItemlist[i].No == no)
                {
                    _menuItemlist.Remove(_menuItemlist[i]);
                    return;
                }
            }

            //Alternativt:
        
            //if (GetMenuItemByNo(no)!=null)
            //{
            //    _menuItemlist.Remove(GetMenuItemByNo(no));
            //}
           
            
        }
        public List<MenuItem> GetMenuType(MenuType type)
        {
            List<MenuItem> menuTypes = new List<MenuItem>();
            foreach (MenuItem t in _menuItemlist)
            {
                if (t.TheMenuType == type)
                {
                    menuTypes.Add(t);
                    
                }
            }
            return menuTypes;
        }


        public MenuItem? GetMostExpensiveItem(MenuType type)
        {
            MenuItem? mostExpensive = null;
            double highestPrice = 0;
            //List<MenuItem> itemsToShearch = GetMenuType(type);
            foreach (MenuItem item in _menuItemlist)
            {
                if (item.TheMenuType == type)
                {
                    if (item.Price > highestPrice)
                    {
                        highestPrice = item.Price;
                        mostExpensive = item;
                    }
                }
                //GetMenuType(type);

            }

            return mostExpensive;

        }
        
        public MenuItem? GetMostExpensivePizza()
        {
            MenuItem? mostExpensive = null;
            double highestPrice = 0;

            foreach (MenuItem item in _menuItemlist)
            {
                if (item.TheMenuType.ToString().StartsWith("PIZZE"))
                {

                    if (item.Price > highestPrice)
                    {
                        highestPrice = item.Price;
                        mostExpensive = item;
                    }
                }
            }
            return mostExpensive;
        }







        public Dictionary<MenuType, List<MenuItem>> PrintMenu()
        {
            var groupedMenu = new Dictionary<MenuType, List<MenuItem>>();

            foreach (var item in _menuItemlist)
            {
                if (!groupedMenu.ContainsKey(item.TheMenuType))
                {
                    groupedMenu[item.TheMenuType] = new List<MenuItem>();
                }

                groupedMenu[item.TheMenuType].Add(item);
            }

            // Udskriv til konsollen
            foreach (var group in groupedMenu)
            {
                Console.WriteLine($"--- {group.Key} ---");
                foreach (var menuItem in group.Value)
                {
                    Console.WriteLine($"Nummer: {menuItem.No}");
                    Console.WriteLine($"Navn:{menuItem.Name}");
                    Console.WriteLine($"Ingredienser:{menuItem.Description}");
                    Console.WriteLine($"Pris:{menuItem.Price} kr.-");
                    Console.WriteLine();
                }
                Console.WriteLine(); // Tom linje mellem grupper
            }

            return groupedMenu;
        }






    }
}
