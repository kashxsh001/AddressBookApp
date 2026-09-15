using AddressBookApp.Models;
using AddressBookApp.Services;
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
        public void GetCountByCityOrState()
        {
            var allContacts = books.SelectMany(b => b.Contacts).ToList();

            var byCity = allContacts
                .GroupBy(c => c.City)
                .Select(g => new { City = g.Key, Count = g.Count() });

            var byState = allContacts
                .GroupBy(c => c.State)
                .Select(g => new { State = g.Key, Count = g.Count() });

            string cityLine = string.Join(", ", byCity.Select(x => $"{x.City} = {x.Count}"));
            string stateLine = string.Join(", ", byState.Select(x => $"{x.State} = {x.Count}"));

            Console.WriteLine($"By City: {cityLine}");
            Console.WriteLine($"By State: {stateLine}");
        }

        public void SortByName()
        {
            var allContacts = books.SelectMany(b => b.Contacts).ToList();
            var byName = allContacts.OrderBy(c => c.FirstName)
                                    .ThenBy(c => c.LastName)
                                    .ToList();
            foreach(var c in byName)
            {
                Console.WriteLine(c);
            }

        }
        
    }
}
