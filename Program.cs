using AddressBookApp.CustomException;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using System;
class Program
{
    static void Main(string[] args)
    {
        //Contact contact = new Contact("Kashish", "Gupta", "Bank Colony", "Bathinda", "Punjab", "151001", "89023456", "kashish@123gmail.com");
        //Console.WriteLine(contact.ToString());
        try
        {
            var contact =new Contact("Kashish", "Gupta", "Bank Colony", "Bathinda", "Punjab", "151001", "8902345632", "kashish@123gmail.com");
            ContactValidator.Validate(contact);
            Console.WriteLine(contact.ToString());
        }
        catch(InvalidContactException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
