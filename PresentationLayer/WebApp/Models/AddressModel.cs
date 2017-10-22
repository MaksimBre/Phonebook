using Phonebook.BusinessLogicLayer.Models;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
            Contact = new ContactModel();
            AddressType = new AddressTypeModel();
            Country = new CountryModel();
        }
        public AddressModel(string city, string street, int houseNo, ContactModel contact, CountryModel country, AddressTypeModel type = default(AddressTypeModel), string zipCode = null)
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
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNo { get; set; }
        public ContactModel Contact { get; set; }
        public CountryModel Country { get; set; }
        public string ZipCode { get; set; }
        public AddressTypeModel AddressType { get; set; }
        public string ParseIds { get; set; }

        public static implicit operator Address(AddressModel am)
        {
            Address address = new Address(am.City, am.Street, am.HouseNo, am.Contact, am.Country, am.ZipCode, am.AddressType)
            {
                Id = am.Id
            };

            return address;
        }

        public static implicit operator AddressModel(Address a)
        {

            AddressModel addressModel = new AddressModel(a.City, a.Street, a.HouseNo, a.Contact, a.Country, a.AddressType, a.ZipCode)
            {
                Id = a.Id
            };

            return addressModel;
        }
    }
}