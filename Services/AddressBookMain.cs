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
    }
}
