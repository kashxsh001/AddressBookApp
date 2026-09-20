using AddressBookApp.CustomException;
using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookApp.Validation
{
    public class ContactValidator
    {
        public static void Validate(Contact c)
        {
            if (!Regex.IsMatch(c.FirstName, @"^[A-Z][a-zA-Z]{2,}$"))
            {
                throw new InvalidContactException("First name must start with a capital letter and be at least 3 characters.");
            }

            if (!Regex.IsMatch(c.LastName, @"^[A-Z][a-zA-Z]{2,}$"))
            {
                throw new InvalidContactException("Last name must start with a capital letter and be at least 3 characters.");
            }

            if (!Regex.IsMatch(c.Address, @".{4,}$"))
            {
                throw new InvalidContactException("Address should be of minimum 4 characters.");
            }

            if (!Regex.IsMatch(c.City, @"^.{4,}$"))
                throw new InvalidContactException("City should be of minimum 4 characters.");

            if (!Regex.IsMatch(c.State, @"^.{4,}$"))
                throw new InvalidContactException("State should be of minimum 4 characters.");

            if (!Regex.IsMatch(c.Zip, @"^[0-9]{6}$"))
            {
                throw new InvalidContactException("Zip Code must be of 6 digits.");
            }
            if (!Regex.IsMatch(c.PhoneNumber, @"^[0-9]{10}$"))
            {
                throw new InvalidContactException("Phone number must be of 10 digits.");
            }
            if (!Regex.IsMatch(c.Email, @"^[A-Za-z0-9.]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                throw new InvalidContactException("Invalid Email.");
            }
        }
            
    }
}
