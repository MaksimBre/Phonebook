using System;
using Phonebook.BusinessLogicLayer.Managers.Properties;
using Phonebook.BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Phonebook.BusinessLogicLayer.Managers
{
    public class Phones
    {
        public IEnumerable<Phone> GetAllByContact(Contact contact)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.Phones.GetAllByContactId(contact.Id).Select(p => Map(p, contact));
            }
        }

        public int Add(Phone phone)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.Phones.Insert(Map(phone));
            }
        }

        public void Save(Phone phone)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Phones.Update(Map(phone));
            }
        }

        public void Delete(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Phones.Delete(id);
            }
        }

        private Phone Map(DataAccessLayer.Models.Phone dbPhone, Contact contact)
        {
            if (Equals(dbPhone, null))
                return null;
            Debug.Assert(dbPhone.ContactId == contact.Id);

            Phone phone = new Phone(dbPhone.Number, contact, dbPhone.CountryId, dbPhone.TypeId.HasValue ? new PhoneTypes().GetById(dbPhone.TypeId.Value) : null)
            {
                Id = dbPhone.Id
            };

            return phone;
        }

        private DataAccessLayer.Models.Phone Map(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException("phone", "Valid phone is mandatory!");

            return new DataAccessLayer.Models.Phone(phone.Id, phone.Number, phone.Contact.Id, phone.CountryId, phone.PhoneType?.Id);
        }
    }
}
