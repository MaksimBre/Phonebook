using Phonebook.BusinessLogicLayer.Managers.Properties;
using Phonebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.BusinessLogicLayer.Managers
{
    public class PhoneTypes
    {
        public IEnumerable<PhoneType> GetAll()
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.PhoneTypes.GetAll().Select(pt => Map(pt));
            }
        }

        public PhoneType GetById(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return Map(phonebook.PhoneTypes.GetById(id));
            }
        }

        public int Add(PhoneType phoneType)
        {
            if (phoneType == null)
                throw new ArgumentNullException("phoneType", "Valid phone type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.PhoneTypes.Insert(Map(phoneType));
            }
        }

        public void Save(PhoneType phoneType)
        {
            if (phoneType == null)
                throw new ArgumentNullException("phoneType", "Valid phone type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.PhoneTypes.Update(Map(phoneType));
            }
        }

        public void Delete(PhoneType phoneType)
        {
            if (phoneType == null)
                throw new ArgumentNullException("phoneType", "Valid phone type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.PhoneTypes.Delete(Map(phoneType));
            }
        }

        private PhoneType Map(DataAccessLayer.Models.PhoneType dbPhoneType)
        {
            if (Equals(dbPhoneType, null))
                return null;

            PhoneType phoneType = new PhoneType(dbPhoneType.Name);
            phoneType.Id = dbPhoneType.Id;

            return phoneType;
        }
        private DataAccessLayer.Models.PhoneType Map(PhoneType phoneType)
        {
            if (Equals(phoneType, null))
                throw new ArgumentNullException("phoneType", "Valid phone type is mandatory!");

            return new DataAccessLayer.Models.PhoneType(phoneType.Id, phoneType.Name);


        }
    }
}
