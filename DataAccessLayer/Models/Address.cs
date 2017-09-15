using System;

namespace Phonebook.DataAccessLayer.Models
{
    public class Address
    {
        public Address()
        {
        }

        public Address(int contactId, string country, string city, string zipCode, string street, string houseNo, int? typeId = null)
        {
            ContactId = contactId;

            Country = country;
            City = city;
            ZipCode = zipCode;
            Street = street;
            HouseNo = houseNo;
            TypeId = typeId;
    }

        public int ContactId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string HouseNo { get; set; }
        public int? TypeId { get; set; }
    }
}