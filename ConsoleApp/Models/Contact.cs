using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Models;

public class Contact : IContact
{
    public Contact()  //empty constructor
    { 
    }
    
    public Contact (string fName, string lName, string eMail, string aDdress, string pHone) //constructor for contact creation with guid generation
    {
        FirstName = fName;
        LastName = lName;
        Email = eMail;
        Address = aDdress;
        Phone = pHone;
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;

 
}
