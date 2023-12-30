using ConsoleApp.Models;
using System.Diagnostics;

namespace ConsoleApp.Services;

internal class MenuService
{
   
    public MenuService()
    {
        bool showmenu = true; 
        var input = 0;

        UserService userService = new UserService();    // get content and deserialize from .json  to list of type contact on startup
        userService.DeserializeToList();

        while (showmenu) //while true show menu until case 5 which sets showmenu to false.
        {
           

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nWelcome to the adress book");
            Console.WriteLine("-------------------");
            Console.WriteLine("Select options by typing in number 1-5");
            Console.WriteLine("1. Create new contact");
            Console.WriteLine("2. Find contact");
            Console.WriteLine("3. Delete contact");
            Console.WriteLine("4. Display all contacts");
            Console.WriteLine("5. Exit application");
            Console.WriteLine("-------------------");
            Console.Write("Enter your input here:");

            try
            {
                input = int.Parse(Console.ReadLine()!);
            }
            catch (Exception)
            {

            }


            switch (input)
            {
                case 0:
                    {   //reset input
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nValid options are: 1-5 \n Press any key to confirm.");
                        Console.ReadLine();
                        break;
                    }
                case 1:
                    {
                        try
                        {
                            //addcontact method where user sets the parameters in the contact class constructors using console.readline
                            Console.Clear();
                            Console.WriteLine("1. Create new contact");
                            var UserService = new UserService();
                            Console.Write("Enter First Name:");
                            var FirstName = Console.ReadLine()!;
                            Console.Write("Enter Last Name:");
                            var LastName = Console.ReadLine()!;
                            Console.Write("Enter Email:");
                            var Email = Console.ReadLine()!;
                            Console.Write("Enter Adress:");
                            var Address = Console.ReadLine()!;
                            Console.Write("Enter Phone number:");
                            var Phone = Console.ReadLine()!;
                            Contact contact = new Contact(FirstName, LastName, Email, Address, Phone);
                            UserService.AddContact(contact);
                            Console.ReadKey();
                            input = 0;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("2. Find contact");
                        var UserService = new UserService();
                        Console.Write("Enter the email adress of the contact search for:");
                        string Userinput = Console.ReadLine()!;
                        UserService.FindContact(Userinput);
                        Console.ReadKey();
                        input = 0;
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("3. Delete contact");
                        var UserService = new UserService();
                        Console.WriteLine("Enter the email adress of the contact you want to delete:");
                        string Userinput = Console.ReadLine()!;
                        UserService.DeleteContact(Userinput);
                        Console.ReadKey();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("4. Display all contacts");
                        var UserService = new UserService();
                        UserService.GetContactFromList();
                        Console.ReadKey();
                        input = 0;
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("5. Exit menu");
                        Console.ReadKey();
                        showmenu = false;
                        break;
                    }
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nValid options are: 1-5 \n Press any key to confirm.");
                    Console.ReadLine();
                    break;
            }
            Console.Clear();
        }

    }

}

