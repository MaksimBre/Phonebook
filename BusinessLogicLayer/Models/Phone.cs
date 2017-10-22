using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.BusinessLogicLayer.Models
{
    public class Phone
    {
        private int number;
        private Contact contact;
        private Country country;

        public Phone() { }
        public Phone(int number, Contact contact, Country country, PhoneType phoneType = null)
        {
            Number = number;
            Contact = contact;
            Country = country;
            PhoneType = phoneType;
        }

        public int Id { get; set; }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                int oldValue = number;
                try
                {
                    number = value;
                }
                catch
                {
                    number = oldValue;
                    //throw;
                }
            }
        }

        public Contact Contact
        {
            get
            {
                Debug.Assert(!Equals(contact, null));
                return contact;
            }
            set
            {
                if (Equals(value, null))
                    throw new ArgumentNullException("Contact", "Valid contact is mandatory");

                contact = value;
            }
        }

        public Country Country
        {
            get
            {
                Debug.Assert(!Equals(country, null));
                return country;
            }
            set
            {
                if (Equals(value, null))
                    throw new ArgumentNullException("Country", "Valid country is mandatory");

                country = value;
            }
        }

        public PhoneType PhoneType { get; set; }
    }
}
