using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        private List<AddressBook> books = new();
        public IReadOnlyList<AddressBook> Books => books;

        public void AddAddressBook(AddressBook book)
        {
            books.Add(book);
        }

        public AddressBook FindByName(string name)
        {
            return books.FirstOrDefault(b => b.Name == name);
        }

        public int GetTotalContactCount()
        {
            return books.Sum(b => b.Contacts.Count);
        }

        public List<Contact> SearchByCity(string city)
        {
            return books.SelectMany(b => b.Contacts)
                .Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Contact> SearchByState(string state)
        {
            return books.SelectMany(b => b.Contacts)
                .Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void ViewByCityOrState()
        {
            var allContacts = books.SelectMany(b => b.Contacts).ToList();

            Console.WriteLine("--- By City ---");
            var byCity = allContacts.GroupBy(c => c.City);
            foreach (var group in byCity)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var contact in group)
                {
                    Console.WriteLine($"  {contact.FirstName} {contact.LastName}");
                }
            }

            Console.WriteLine("\n--- By State ---");
            var byState = allContacts.GroupBy(c => c.State);
            foreach (var group in byState)
            {
                Console.WriteLine($"{group.Key}:");
                var names = group.Select(c => $"{c.FirstName} {c.LastName}");
                Console.WriteLine("  " + string.Join(", ", names));
            }
        }
    }
}
