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
        private static List<Contact> contacts = new();
        public IReadOnlyList<Contact> Contacts => contacts;

        public static void AddContact(Contact c)
        {
            try
            {
                ContactValidator.Validate(c);
                contacts.Add(c);
                Console.WriteLine("Contact Added Successfully");
            }
            catch(InvalidContactException ex)
            {
                Console.WriteLine(ex.Message);
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
