using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;
using System.Diagnostics;



namespace ConsoleApp.Tests;

public class UserService_Test
{
    [Fact]
    public void AddContact_ShouldAddOneContactToList_ThenReturnTrue() 
    {
        // ARRANGE
        Contact contact = new Contact("Test", "Testsson", "test@email.com","TestAddress", "TestPhone");
        UserService userService = new UserService();

        // ACT 

        userService.DeleteContact("test@email.com"); // if the test user exists in the contact list, delete prior to adding.
        bool result = userService.AddContact(contact);
        userService.DeleteContact("test@email.com"); // delete the contact afterwards.


        // ASSERT

        Assert.True(result);
        
    }

    [Fact]
    public void FindContact_ShouldFindTheContact_ThenReturnTrue()
    {
        // ARRANGE
        UserService userService = new UserService();
        Contact contact = new Contact("Test", "Testsson", "test@email.com", "TestAddress", "TestPhone");
        userService.AddContact(contact);

        // ACT 
        string Userinput = "test@email.com";
        bool result = userService.FindContact(Userinput);
        userService.DeleteContact("test@email.com"); // delete the contact afterwards.


        // ASSERT
        Assert.True(result);
    }
    [Fact]
    public void DeleteContact_ShouldDeleteTheContact_ThenReturnTrue() 
    {
        // ARRANGE
        UserService userService = new UserService();
        Contact contact = new Contact("Test", "Testsson", "test@email.com", "TestAddress", "TestPhone");
        userService.AddContact(contact);

        // ACT 
        string Userinput = "test@email.com";
        bool result = userService.DeleteContact(Userinput);



        // ASSERT
        Assert.True(result);
    }
    [Fact]
    public void GetContact_ShouldGetContacts_AndAssertResultVariable()  
    {
        // ARRANGE
        UserService userService = new UserService();
        Contact contact = new Contact("Test", "Testsson", "test@email.com", "TestAddress", "TestPhone");
        userService.AddContact(contact);

        // ACT 

        IEnumerable<Contact> result = userService.GetContactFromList();
        userService.DeleteContact("test@email.com");

        // ASSERT
        Assert.NotNull(result);
        Contact returned_contact = result.FirstOrDefault()!;
        Assert.True(returned_contact.Id != null);
    }
    [Fact]
    public void DeserializeToList_ShouldDeserializeJsonFile_ReturnTrue() 
    {
        // ARRANGE
        UserService userService = new UserService();
        Contact contact = new Contact("Test", "Testsson", "test@email.com", "TestAddress", "TestPhone");
        userService.AddContact(contact);

        // ACT 

        var result = userService.DeserializeToList();
        userService.DeleteContact("test@email.com");

        // ASSERT
        Assert.True(result);
        
    }
    
}
