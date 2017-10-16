using Phonebook.BusinessLogicLayer.Models;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class PhoneModel
    {
        public PhoneModel()
        {
            Contact = new ContactModel();
            PhoneType = new PhoneTypeModel();
        }
        public PhoneModel(int number, Contact contact, int countryId, PhoneTypeModel phoneType = default(PhoneTypeModel))
        {
            Number = number;
            Contact = contact;
            CountryId = countryId;
            PhoneType = phoneType;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public Contact Contact { get; set; }
        public int CountryId { get; set; }
        public PhoneTypeModel PhoneType { get; set; }
        public string ParseIds { get; set; }

        public static implicit operator Phone(PhoneModel pm)
        {
            Phone phone = new Phone(pm.Number, pm.Contact, pm.CountryId, pm.PhoneType)
            {
                Id = pm.Id
            };

            return phone;
        }

        public static implicit operator PhoneModel(Phone p)
        {

            PhoneModel phoneModel = new PhoneModel(p.Number, p.Contact, p.CountryId, p.PhoneType)
            {
                Id = p.Id
            };

            return phoneModel;
        }
    }
}