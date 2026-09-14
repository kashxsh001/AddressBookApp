using AddressBookApp.CustomException;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using AddressBookApp.Services;
using System;
class Program
{
    static void Main(string[] args)
    {
        
      
        while (true)
        {
            Console.WriteLine("---------ADDRESS BOOK MENU----------");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Show All Contacts");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter the number:");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine("Enter Your First Name: ");
                string FirstName = Console.ReadLine()!;
                Console.WriteLine("Enter Your Last Name: ");
                string LastName = Console.ReadLine()!;
                Console.WriteLine("Enter Your Address: ");
                string Address = Console.ReadLine()!;
                Console.WriteLine("Enter Your City: ");
                string City = Console.ReadLine()!;
                Console.WriteLine("Enter Your State: ");
                string State= Console.ReadLine()!;
                Console.WriteLine("Enter Your ZipCode: ");
                string Zip = Console.ReadLine()!;
                Console.WriteLine("Enter Your Phone Number: ");
                string Phone = Console.ReadLine()!;
                Console.WriteLine("Enter Your Email: ");
                string Email= Console.ReadLine()!;

                Contact c = new Contact(FirstName,LastName, Address, City, State, Zip, Phone, Email);
                AddressBook.AddContact(c);
            }
            if (input == 2)
            {
                Console.WriteLine("Enter Your First Name: ");
                string firstName = Console.ReadLine()!;
                Console.WriteLine("Enter Your Last Name: ");
                string lastName = Console.ReadLine()!;
                AddressBook.EditContact(firstName, lastName);
            }
            if (input == 3)
            {
                AddressBook.PrintAll();
            }

            if(input == 0)
            {
                return;
            }

        }

    }
}
