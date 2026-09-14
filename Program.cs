using AddressBookApp.Models;
class Program
{
    static void Main(string[] args)
    {
        Contact contact = new Contact("Kashish", "Gupta", "Bank Colony", "Bathinda", "Punjab", "151001", "89023456", "kashish@123gmail.com");
        Console.WriteLine(contact.ToString());
    }
}
