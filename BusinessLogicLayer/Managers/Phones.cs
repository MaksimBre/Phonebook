using System;
using Phonebook.BusinessLogicLayer.Managers.Properties;
using Phonebook.BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.BusinessLogicLayer.Managers
{
    public class Phones
    {
        public Phone GetById(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return Map(phonebook.Phones.GetById(id));
            }
        }

        public IEnumerable<Phone> GetAllByContact(Contact contact)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                //return Map(phonebook.Addresses.GetAllByContact(contact));
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

        public void Delete(Phone phone)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Phones.Delete(Map(phone));
            }
        }

        private Phone Map(DataAccessLayer.Models.Phone dbPhone, Contact contact)
        {
            if (dbPhone == null)
                return null;

            if (contact == null)
                return null;

            Phone phone = new Phone(dbPhone.Number, dbPhone.ContactId, dbPhone.CountryId, contact.Id);
            phone.Id = dbPhone.Id;

            return phone;
        }

        private Phone Map(DataAccessLayer.Models.Phone dbPhone)
        {
            if (dbPhone == null)
                return null;

            Phone phone = new Phone(dbPhone.Number, dbPhone.ContactId, dbPhone.CountryId, dbPhone.TypeId);
            phone.Id = dbPhone.Id;

            return phone;
        }

        private DataAccessLayer.Models.Phone Map(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException("phone", "Valid phone is mandatory!");

            return new DataAccessLayer.Models.Phone(phone.Id, phone.Number, phone.TypeId, phone.ContactId, phone.CountryId);
        }
    }
}
