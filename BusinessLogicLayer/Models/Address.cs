using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.BusinessLogicLayer.Models
{
    public class Address
    {
        private string city;
        private string street;
        private int houseNo;
        private int contactId;
        private int countryId;

        public Address() { }
        public Address(string city, string street, int houseNo, int contactId, int countryId, string zipCode = null, int? typeId = null)
        {
            City = city;
            Street = street;
            HouseNo = houseNo;
            ContactId = contactId;
            CountryId = countryId;
            ZipCode = zipCode;
            TypeId = typeId;
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
                    //throw;
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

        public int ContactId
        {
            get
            {
                return contactId;
            }
            set
            {
                int oldValue = contactId;
                try
                {
                    contactId = value;
                }
                catch
                {
                    contactId = oldValue;
                    //throw;
                }
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

        public string ZipCode { get; set; }

        public int? TypeId { get; set; }


    }
}
