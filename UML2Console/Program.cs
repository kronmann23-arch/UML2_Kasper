// See https://aka.ms/new-console-template for more information
using PizzaLibrary.Exceptions;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using System;
using System.Net.WebSockets;
using static System.Net.Mime.MediaTypeNames;

//CUSTOMER REPOSITORY
//-------------------------------------------------------------------------------------------------------------
//Nyt CustomerRepository skabes
CustomerRepository cRepo = new CustomerRepository();

//Tester Count property 
Console.WriteLine("Antallet af Kunder:");
Console.WriteLine("---------------------------------------------------------------------");
Console.WriteLine($"{cRepo.Count} " + "Kunder");
Console.WriteLine();

//Customer laves
Customer customer1 = new Customer("Peter", "15356491", "Hejrevej 292");
//Tester AddCustomer metoden samt PrintAllCustomers metoden
cRepo.AddCustomer(customer1);
Console.WriteLine("Alle kunder med nyligt tilføret kunde Peter:");
Console.WriteLine("---------------------------------------------------------------------");
//Bruger PrintAllCustomers metoden til at printe alle customers ud inklusiv den nye tilføret customer 1
cRepo.PrintAllCustomers();
Console.WriteLine();

//Tester GetAll metoden inde i program.cs 
Console.WriteLine("Listen med alle kunderne");
Console.WriteLine("---------------------------------------------------------------------");
List<Customer> allcustomers = cRepo.GetAll();
foreach (Customer c in allcustomers)
{
    Console.WriteLine(c.ToString());
}
Console.WriteLine();

//Tester GetCustomerByMobile metoden
Console.WriteLine("Leder efter kunde med telefonnummeret 12121212");
Console.WriteLine("---------------------------------------------------------------------");
Console.WriteLine(cRepo.GetCustomerByMobile("12121212"));
Console.WriteLine();

//Test RemoveCustomer metoden
Console.WriteLine("Sletter kunde med telefonnummeret 13131313");
Console.WriteLine("---------------------------------------------------------------------");
cRepo.RemoveCustomer("13131313");
cRepo.PrintAllCustomers();
Console.WriteLine();




//-------------------------------------------------------------------------------------------------------------



//MENUITEM REPOSITORY
//-------------------------------------------------------------------------------------------------------------

//Nyt MenuItemRepository skabes
MenuItemRepository mIRepo = new MenuItemRepository();

//Tester Count property 
Console.WriteLine("Antallet af menuelementer på menuen:");
Console.WriteLine("---------------------------------------------------------------------");
Console.WriteLine($"{mIRepo.Count} " + "Menuelementer");
Console.WriteLine();

//MenuItem laves
MenuItem menuItem1 = new MenuItem("Peperoni",75.0,"Tomatsovs, ost, oregano & peperoni pølser", MenuType.PIZZECLASSSICHE);


//Tester AddMenuItem metoden samt PrintAllMenuItems metoden
mIRepo.AddMenuItem(menuItem1);
Console.WriteLine("Alle menuelementer på menuen med ny tilføret Peperoni Pizza");
Console.WriteLine("---------------------------------------------------------------------");
//Bruger PrintAllMenuItems metoden til at printe alle menuitems ud inklusiv den nye tilføret menuitem1
mIRepo.PrintAllMenuItems();
Console.WriteLine();

//Tester GetAll metoden inde i program.cs 
Console.WriteLine("Listen med alle menuelementer");
Console.WriteLine("---------------------------------------------------------------------");
List<MenuItem> allmenuitems = mIRepo.GetAll();
foreach (MenuItem mI in allmenuitems)
{
    Console.WriteLine(mI.ToString());
}
Console.WriteLine();



//Tester GetMenuItemByNo metoden
Console.WriteLine("Leder efter menuelement nr.1 på menuen");
Console.WriteLine("---------------------------------------------------------------------");
Console.WriteLine(mIRepo.GetMenuItemByNo(1));
Console.WriteLine();

//Test RemoveMenuItem metoden
Console.WriteLine("Sletter menuelement nr.3 på menuen");
Console.WriteLine("---------------------------------------------------------------------");
mIRepo.RemoveMenuItem(3);
mIRepo.PrintAllMenuItems();
Console.WriteLine();

//-------------------------------------------------------------------------------------------------------------



//TEST AF ANDRE FUNKTIONER
//-------------------------------------------------------------------------------------------------------------

//Test af GetAllClubMembers metoden
Console.WriteLine("Leder efter clubmembers og printer dem ud");
Console.WriteLine("---------------------------------------------------------------------");
List<Customer> clubmembers = cRepo.GetAllClubMembers();
foreach (Customer c in clubmembers)
{
    Console.WriteLine(c.ToString());
}

//Test af GetAllCustomersFromRoskilde metoden
Console.WriteLine("Finder alle kunder fra Roskilde");
Console.WriteLine("---------------------------------------------------------------------");
cRepo.GetAllCustomersFromRoskilde();
List<Customer> customers = cRepo.GetAllCustomersFromRoskilde();
foreach(Customer c in customers)
{
    Console.WriteLine(c.ToString());
}
Console.WriteLine();

//Test af GetMenuType metoden
Console.WriteLine("Finder og udprinter alle MenuItems med MenuType PIZZECLASSSICHE");
Console.WriteLine("---------------------------------------------------------------------");
List<MenuItem> menuItems1 = mIRepo.GetMenuType(MenuType.PIZZECLASSSICHE);
foreach(MenuItem m in menuItems1)
{
    Console.WriteLine(m.ToString());
}
Console.WriteLine();
//lavet som forloop istedet
Console.WriteLine("Finder og udprinter alle MenuItems med MenuType PIZZECLASSSICHE");
Console.WriteLine("---------------------------------------------------------------------");
List<MenuItem> menuItems2 = mIRepo.GetMenuType(MenuType.PIZZECLASSSICHE);
for (int i =0 ; i < menuItems2.Count; i++)
{
    Console.WriteLine(menuItems2[i].ToString());
}
Console.WriteLine();
//Lavet som forloop istedet



//Test af GetMostExpensiveItem metoden
Console.WriteLine("Finder den dyreste Item af en specifik type");
Console.WriteLine("---------------------------------------------------------------------");
Console.WriteLine(mIRepo.GetMostExpensiveItem(MenuType.TILBEHØR));
Console.WriteLine();

//Test af GetMostExpensivePizza metoden
Console.WriteLine("Finder den dyreste pizza af typen Pizza classic eller Pizza speziale");
Console.WriteLine("---------------------------------------------------------------------");
Console.WriteLine(mIRepo.GetMostExpensivePizza());
Console.WriteLine();

// Test af PrintMenu metoden
Console.WriteLine("Udskriv Menutyper og menuitems i hver type");
Console.WriteLine("---------------------------------------------------------------------");
mIRepo.PrintMenu();
Console.WriteLine();

//Test af VIPCustomer klassen og tilføjer objektet til customerrepo
Console.WriteLine("Finder en givende customer af typen VIP");
Console.WriteLine("---------------------------------------------------------------------");
VIPCustomer vip1 = new VIPCustomer("Peter", "17171717", "Næstvedvej 14", 20);
Console.WriteLine(vip1);
cRepo.AddCustomer(vip1);
Console.WriteLine();

//Test af Beverage klassen og tilføjer 2 objekter med objektref bev1 og bev2 til menuitemrepo, så
//hvis jeg bruger PrintMenu metoden senere vil de være at se.
Console.WriteLine("Opretter, udprinter og tilføjer de nye objekter af Beverage klassen");
Console.WriteLine("---------------------------------------------------------------------");
Beverage bev1 = new Beverage("Pepsi Max", 25.0, "0.5 liter", MenuType.TILBEHØR, false);
Console.WriteLine(bev1);
mIRepo.AddMenuItem(bev1);
Console.WriteLine();

Beverage bev2 = new Beverage("Tuborg Classic", 40.0,"0.5 liter",MenuType.TILBEHØR, true);
Console.WriteLine(bev2);
mIRepo.AddMenuItem(bev2);
Console.WriteLine();


//Test af catch af CustomerMobileNumberExist Exception
Console.WriteLine("Test CustomerMobileNumberExist Exception");
Console.WriteLine("---------------------------------------------------------------------");

try
{
    cRepo.AddCustomer(new Customer("Peter", "12345678","Vej1"));
    cRepo.AddCustomer(new Customer("Lars", "12345678","Vej2")); // Personerne har samme nummer
}
catch (CustomerMobileNumberExist cmne)
{
    Console.WriteLine($"Fejl: {cmne.Message}");
}
Console.WriteLine();

//Test af try og catch af MenuItemNameExistException
Console.WriteLine("Tester MenuItemNameExistException");
Console.WriteLine("---------------------------------------------------------------------");
try
{
    mIRepo.AddMenuItem(new MenuItem("Cola", 20, "Light", MenuType.TILBEHØR));
    mIRepo.AddMenuItem(new MenuItem("Cola", 30, "Zero", MenuType.TILBEHØR));
}
catch(MenuItemNameExist mine)
{
    Console.WriteLine($"Fejl: {mine.Message}");
}
Console.WriteLine();

//Test af try og catch af TooHighDiscountException
Console.WriteLine("Tester TooHighDiscountException");
Console.WriteLine("---------------------------------------------------------------------");
try
{
    VIPCustomer vip = new VIPCustomer("Kasper", "8383883", "Gade 11", 100);

}
catch (TooHighDiscountException thde)
{
    Console.WriteLine($"Fejl: {thde.Message}");
}




//-------------------------------------------------------------------------------------------------------------






