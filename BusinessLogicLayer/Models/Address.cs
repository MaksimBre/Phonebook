using System;
using System.Diagnostics;

namespace Phonebook.BusinessLogicLayer.Models
{
    public class Address
    {
        private string city;
        private string street;
        private int houseNo;
        private Contact contact;
        private Country country;

        public Address() { }
        public Address(string city, string street, int houseNo, Contact contact, Country country, string zipCode = null, AddressType type = null)
        {
            City = city;
            Street = street;
            HouseNo = houseNo;
            Contact = contact;
            Country = country;
            ZipCode = zipCode;
            AddressType = type;
        }

        public int Id { get; set; }

        public string City
        {
            get
            {
                Debug.Assert(city != null);
                return city;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("City", "Valid city is mandatory!");

                string oldValue = city;
                try
                {
                    city = value;
                }
                catch
                {
                    city = oldValue;
                }
            }
        }

        public string Street
        {
            get
            {
                Debug.Assert(street != null);
                return street;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Street", "Valid street is mandatory!");

                string oldValue = street;
                try
                {
                    street = value;
                }
                catch
                {
                    street = oldValue;
                    //throw;
                }
            }
        }

        public int HouseNo
        {
            get
            {
                return houseNo;
            }
            set
            {
                int oldValue = houseNo;
                try
                {
                    houseNo = value;
                }
                catch
                {
                    houseNo = oldValue;
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

        public string ZipCode { get; set; }

        public AddressType AddressType { get; set; }

    }
}
