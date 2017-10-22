using Phonebook.BusinessLogicLayer.Models;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class PhoneModel
    {
        public PhoneModel()
        {
            Contact = new ContactModel();
            PhoneType = new PhoneTypeModel();
            Country = new CountryModel();
        }
        public PhoneModel(int number, ContactModel contact, CountryModel country, PhoneTypeModel phoneType = default(PhoneTypeModel))
        {
            Number = number;
            Contact = contact;
            Country = country;
            PhoneType = phoneType;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public ContactModel Contact { get; set; }
        public CountryModel Country { get; set; }
        public PhoneTypeModel PhoneType { get; set; }
        public string ParseIds { get; set; }

        public static implicit operator Phone(PhoneModel pm)
        {
            Phone phone = new Phone(pm.Number, pm.Contact, pm.Country, pm.PhoneType)
            {
                Id = pm.Id
            };

            return phone;
        }

        public static implicit operator PhoneModel(Phone p)
        {

            PhoneModel phoneModel = new PhoneModel(p.Number, p.Contact, p.Country, p.PhoneType)
            {
                Id = p.Id
            };

            return phoneModel;
        }
    }
}