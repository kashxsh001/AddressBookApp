using AddressBookApp.Models;
using AddressBookApp.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        AddressBookMain manager = new AddressBookMain();
        AddressBook currentBook = null;

        while (true)
        {
            Console.WriteLine("---------ADDRESS BOOK MENU----------");
            Console.WriteLine($"Current Book: {(currentBook != null ? currentBook.Name : "None selected")}");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Show All Contacts");
            Console.WriteLine("5. Create New Address Book");
            Console.WriteLine("6. Switch Address Book");
            Console.WriteLine("7. Total Contact Count (All Books)");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter the number:");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 5) // Create new book
            {
                Console.Write("Enter a name for this address book: ");
                string name = Console.ReadLine()!;

                AddressBook existing = manager.FindByName(name);
                if (existing != null)
                {
                    Console.WriteLine("A book with this name already exists. Switching to it instead.");
                    currentBook = existing;
                }
                else
                {
                    AddressBook newBook = new AddressBook(name);
                    manager.AddAddressBook(newBook);
                    currentBook = newBook;
                    Console.WriteLine($"Created and switched to '{name}'.");
                }
                continue;
            }

            if (input == 6) // Switch book
            {
                if (manager.Books.Count == 0)
                {
                    Console.WriteLine("No address books exist yet. Create one first.");
                    continue;
                }

                Console.WriteLine("Available books:");
                foreach (var b in manager.Books)
                {
                    Console.WriteLine($"  - {b.Name} ({b.Contacts.Count} contacts)");
                }

                Console.Write("Enter book name to switch to: ");
                string name = Console.ReadLine()!;
                AddressBook found = manager.FindByName(name);

                if (found != null)
                {
                    currentBook = found;
                    Console.WriteLine($"Switched to '{name}'.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
                continue;
            }

            if (input == 7) // Total across all books
            {
                Console.WriteLine($"Total contacts in all address books: {manager.GetTotalContactCount()}");
                continue;
            }

            if (input == 0)
            {
                return;
            }

            if (currentBook == null)
            {
                Console.WriteLine("No address book selected. Create or switch to one first (option 5 or 6).");
                continue;
            }

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
                string State = Console.ReadLine()!;
                Console.WriteLine("Enter Your ZipCode: ");
                string Zip = Console.ReadLine()!;
                Console.WriteLine("Enter Your Phone Number: ");
                string Phone = Console.ReadLine()!;
                Console.WriteLine("Enter Your Email: ");
                string Email = Console.ReadLine()!;

                Contact c = new Contact(FirstName, LastName, Address, City, State, Zip, Phone, Email);
                currentBook.AddContact(c);
            }

            if (input == 2)
            {
                Console.WriteLine("Enter Your First Name: ");
                string firstName = Console.ReadLine()!;
                Console.WriteLine("Enter Your Last Name: ");
                string lastName = Console.ReadLine()!;
                currentBook.EditContact(firstName, lastName);
            }

            if (input == 3)
            {
                Console.WriteLine("Enter Your First Name: ");
                string firstName = Console.ReadLine()!;
                Console.WriteLine("Enter Your Last Name: ");
                string lastName = Console.ReadLine()!;
                currentBook.DeleteContact(firstName, lastName);
            }

            if (input == 4)
            {
                currentBook.PrintAll();
            }
        }
    }
}