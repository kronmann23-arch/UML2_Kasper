using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controllers.MenuItems
{
    public class AddMenuItemController
    {
        IMenuItemRepository _menuItemRepository;
        public MenuItem MenuItem { get; set; }

        public AddMenuItemController(string name, string description, double price,MenuType menuType ,MenuItemRepository menuItemRepository)
        {
            MenuItem = new MenuItem(name, price, description, menuType);
            //Customer.ClubMember = clubMember;
            _menuItemRepository = menuItemRepository;
        }

        public void AddMenuItem()
        {
            _menuItemRepository.AddMenuItem(MenuItem);
        }


    }
}

