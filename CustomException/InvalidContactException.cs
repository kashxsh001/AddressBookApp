using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.CustomException
{
    public class InvalidContactException: Exception
    {
        public InvalidContactException(string message) : base(message) { }
    }
}
