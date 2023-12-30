using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;


namespace ConsoleApp.Services;

public class UserService
{
    private readonly string _filePath = @"C:\temp\contacts.json"; //path for fileservice

    private readonly FileService _fileservice = new FileService(); // new private readonly instance of fileservice called _fileservice
    
    private List<Contact> _contactList = new List<Contact>(); // new list of type Contact
    

    public bool AddContact(Contact contact)
    {
        DeserializeToList();

        try
        {     
            //addcontact method which uses the fileservice and the method SaveContentTofile
                           
            if (! _contactList.Any(x => x.Email == contact.Email)) //using a predicate to match contact.email in the list.
                                                                   //if it doesnt match it will get added to the list & saved to json.
            {
                _contactList.Add(contact);
                Console.WriteLine("contact created and saved to list");
                _fileservice.SaveContentToFile(JsonConvert.SerializeObject(_contactList), _filePath);
                return true;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Email adress {contact.Email} already exist.\nPress any key to return to the main menu");
                return false;
            }

        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
        }
        return false;

    }

    public IEnumerable<Contact> GetContactFromList() // IEnumerable of contact objects
    {
        DeserializeToList();

        foreach (var contact in _contactList) // for each contact in the list console.writeline the individual objects properties.
        {                                
            Console.WriteLine("\nFirstName: " + contact.FirstName);
            Console.WriteLine("LastName: " + contact.LastName);
            Console.WriteLine("Email: " + contact.Email);
            Console.WriteLine("Id: " + contact.Id);
            Console.WriteLine("Adress: " +contact.Address);
            Console.WriteLine("Phone: " +contact.Phone);
            Console.WriteLine("-------------------");
        }
        
        Console.WriteLine("Press any key to return");
        return _contactList;
        
    }
    public bool FindContact(string userInput) // find a contact based on input variable using a predicate
    {
        DeserializeToList();

        try
        {
            var input = userInput;
            Predicate<Contact> findcontact = x => x.Email == input;  // if the input variable matches the findcontact predicate
                                                                     // the method will then console.writeline the properties  of the object return true else return not found false

            if (input != null)
            {
                Contact contact = _contactList.Find(findcontact);
                if (contact != null)
                {
                    Console.WriteLine($"Found Contact with email:{contact.Email}\nFirstName:{contact.FirstName}\nLastName:{contact.LastName}\nAdress:{contact.Address}\nPhone:{contact.Phone}");
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Press any key to return");
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Email adress: {input} does not exist.\nPress any key to return to the main menu");
                    return false;
                }

            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;


    } //find a specific contact via email
    public bool DeleteContact(string userInput) //delete a specific contact via email
    {
        DeserializeToList();

        try
        {
            var input = userInput;
            Predicate<Contact> findcontact = x => x.Email == input; // find a contact based on input variable using a predicate
           
            if (input != null)
            {
                Contact contact = _contactList.Find(findcontact);
                if (contact != null)
                {
                    Console.WriteLine($"Found Contact with email:{contact.Email}\nFirstName:{contact.FirstName}\nLastName:{contact.LastName}");
                    _contactList.Remove(contact);
                    Console.WriteLine("The Contact has been deleted.");
                    _fileservice.SaveContentToFile(JsonConvert.SerializeObject(_contactList), _filePath);
                    Console.WriteLine("contact list has been updated");
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Press any key to return");
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Email adress: {input} does not exist.\nPress any key to return to the main menu");
                    return false;
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    } 
    public bool DeserializeToList() // gets content from .json and deserializes it to contact objects in list  _contactlist 
    {
        var content = _fileservice.GetContentFromFile(_filePath);
        try
        {
            if (!string.IsNullOrEmpty(content)) // if the file exists in content location, deserialize list
            {
                _contactList = JsonConvert.DeserializeObject<List<Contact>>(content)!;  
                return true;
            }
            else
            {
                
            }
        }
       
        catch (Exception ex) {
            Debug.WriteLine(ex.Message);
        }
        return false;
    } 
}
