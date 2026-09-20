using AddressBookApp.CustomException;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        public string Name { get; set; }
        private List<Contact> contacts = new();
        public IReadOnlyList<Contact> Contacts => contacts;

        public AddressBook(string name)
        {
            Name = name;
        }

        public bool AddContact(Contact contact)
        {
            ContactValidator.Validate(contact);

            if (contacts.Any(existing =>
                existing.FirstName.Equals(contact.FirstName,
                    StringComparison.OrdinalIgnoreCase) &&
                existing.LastName.Equals(contact.LastName,
                    StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            contacts.Add(contact);
            return true;
        }
        public void EditContact(string firstName, string lastName)
        {
            Contact? contact = contacts.FirstOrDefault(c =>
        c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
        c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine($"Editing: {contact}");

            bool editing = true;
            while (editing)
            {
                Console.WriteLine("\nWhich field do you want to update?");
                Console.WriteLine("1. First Name");
                Console.WriteLine("2. Last Name");
                Console.WriteLine("3. Address");
                Console.WriteLine("4. City");
                Console.WriteLine("5. State");
                Console.WriteLine("6. Zip");
                Console.WriteLine("7. Phone Number");
                Console.WriteLine("8. Email");
                Console.WriteLine("0. Done editing");
                Console.Write("> ");
                string? choice = Console.ReadLine();

                
                string? oldFirstName = contact.FirstName;
                string? oldLastName = contact.LastName;
                string? oldAddress = contact.Address;
                string? oldCity = contact.City;
                string? oldState = contact.State;
                string? oldZip = contact.Zip;
                string? oldPhone = contact.PhoneNumber;
                string? oldEmail = contact.Email;

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new first name: ");
                        contact.FirstName = Console.ReadLine()!;
                        break;
                    case "2":
                        Console.Write("Enter new last name: ");
                        contact.LastName = Console.ReadLine()!;
                        break;
                    case "3":
                        Console.Write("Enter new address: ");
                        contact.Address = Console.ReadLine()!;
                        break;
                    case "4":
                        Console.Write("Enter new city: ");
                        contact.City = Console.ReadLine()!;
                        break;
                    case "5":
                        Console.Write("Enter new state: ");
                        contact.State = Console.ReadLine()!;
                        break;
                    case "6":
                        Console.Write("Enter new zip: ");
                        contact.Zip = Console.ReadLine()!;
                        break;
                    case "7":
                        Console.Write("Enter new phone number: ");
                        contact.PhoneNumber = Console.ReadLine()!;
                        break;
                    case "8":
                        Console.Write("Enter new email: ");
                        contact.Email = Console.ReadLine()!;
                        break;
                    case "0":
                        editing = false;
                        continue; 
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        continue;
                }

                try
                {
                    ContactValidator.Validate(contact);
                    Console.WriteLine("Field updated.");
                }
                catch (InvalidContactException ex)
                {
                    contact.FirstName = oldFirstName;
                    contact.LastName = oldLastName;
                    contact.Address = oldAddress;
                    contact.City = oldCity;
                    contact.State = oldState;
                    contact.Zip = oldZip;
                    contact.PhoneNumber = oldPhone;
                    contact.Email = oldEmail;

                    Console.WriteLine($"Error: {ex.Message} — field not updated.");
                }
            }

            Console.WriteLine("Contact updated successfully.");
            Console.WriteLine(contact);
        }

        public void DeleteContact(string firstName,string lastName)
        {
            Contact? contact = contacts.FirstOrDefault(c =>
        c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
        c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
            {
                Console.WriteLine("Contact not found");
                return;
            }
            contacts.Remove(contact);
            Console.WriteLine("Contact deleted.");
        }
        public void SortByCity()
        {
            var sorted = contacts.OrderBy(c => c.City);
            foreach (var c in sorted)
            {
                Console.WriteLine(c);
            }
        }

        public void SortByState()
        {
            var sorted = contacts.OrderBy(c => c.State);
            foreach (var c in sorted)
            {
                Console.WriteLine(c);
            }
        }

        public void SortByZip()
        {
            var sorted = contacts.OrderBy(c => c.Zip);
            foreach (var c in sorted)
            {
                Console.WriteLine(c);
            }
        }

        public void PrintAll()
        {
            foreach (Contact c in contacts) { 
                Console.WriteLine(c.ToString());
            }
        }
    }
}
