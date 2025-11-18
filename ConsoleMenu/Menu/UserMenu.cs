using ConsoleMenu.Controllers.Customers;
using ConsoleMenu.Controllers.MenuItems;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4.Add MenuItem\n\tQ.Afslut\n\n\tIndtast valg:";

        private CustomerRepository _customerRepository = new CustomerRepository();
        private MenuItemRepository _menuItemRepository = new MenuItemRepository();
        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Valg 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Valg 2");
                        _customerRepository.PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Valg 3");
                        Console.WriteLine("Indlæs navn:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Indlæs mobil nr:");
                        string mobile = Console.ReadLine();
                        Console.WriteLine("Indlæs adresse:");
                        string address = Console.ReadLine();
                        Console.WriteLine("Vil du være clubmember y/n");
                        string clubMemberString = Console.ReadLine().ToLower();
                        bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                        AddCustomerController addCustomerController = new AddCustomerController(name, mobile, address, isClubMember, _customerRepository);
                        addCustomerController.AddCustomer();
                        break;
                    case "4":
                        Console.WriteLine("Valg 4");
                        Console.WriteLine("Indlæs navn:");
                        string itemName = Console.ReadLine();
                        Console.WriteLine("Indlæs Pris:");
                        string imputPrice = Console.ReadLine();
                        double itemPrice = double.Parse(imputPrice);
                        Console.WriteLine("Indlæs Beskrivelse:");
                        string itemDescription = Console.ReadLine();
                        Console.WriteLine("Indlæs Menutype");
                        string inputMenuType = Console.ReadLine();
                        MenuType itemMenuType = (MenuType)Enum.Parse(typeof(MenuType), inputMenuType);
                        AddMenuItemController addMenuItemController = new AddMenuItemController(itemName,itemDescription,itemPrice,itemMenuType,_menuItemRepository);
                        addMenuItemController.AddMenuItem();
                        break;
                    default:
                        Console.WriteLine("Angiv et tal fra 1..4 eller q for afslut");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }

    }

}
