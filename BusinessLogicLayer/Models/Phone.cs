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
        private int countryId;

        public Phone() { }
        public Phone(int number, Contact contact, int countryId, PhoneType phoneType = null)
        {
            Number = number;
            Contact = contact;
            CountryId = countryId;
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
                    throw new ArgumentNullException("Email", "Valid email is mandatory");

                contact = value;
            }
        }

        public int CountryId
        {
            get
            {
                return countryId;
            }
            set
            {
                int oldValue = countryId;
                try
                {
                    countryId = value;
                }
                catch
                {
                    countryId = oldValue;
                    //throw;
                }
            }
        }

        public PhoneType PhoneType { get; set; }
    }
}
