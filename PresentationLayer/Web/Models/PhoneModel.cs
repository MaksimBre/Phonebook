using Phonebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class PhoneModel
    {
        public PhoneModel() { }
        public PhoneModel(int number, int contactId, int countryId, int? typeId = null)
        {
            Number = number;
            ContactId = contactId;
            CountryId = countryId;
            TypeId = typeId;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public int ContactId { get; set; }
        public int CountryId { get; set; }
        public int? TypeId { get; set; }

        public static implicit operator Phone(PhoneModel pm)
        {
            PhoneType phoneType = new PhoneType(){ Id = (int)pm.TypeId };
            Phone phone = new Phone(pm.Number, pm.ContactId, pm.CountryId, phoneType)
            {
                Id = pm.Id
            };

            return phone;
        }

        public static implicit operator PhoneModel(Phone p)
        {

            PhoneModel phoneModel = new PhoneModel(p.Number, p.ContactId, p.CountryId, p.TypeId.Id)
            {
                Id = p.Id
            };

            return phoneModel;
        }
    }
}