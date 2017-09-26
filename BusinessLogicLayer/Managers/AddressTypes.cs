using Phonebook.BusinessLogicLayer.Managers.Properties;
using Phonebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.BusinessLogicLayer.Managers
{
    public class AddressTypes
    {
        public IEnumerable<AddressType> GetAll()
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.AddressTypes.GetAll().Select(et => Map(et));
            }
        }

        public AddressType GetById(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return Map(phonebook.AddressTypes.GetById(id));
            }
        }

        public int Add(AddressType addressType)
        {
            if (addressType == null)
                throw new ArgumentNullException("addressType", "Valid address type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.AddressTypes.Insert(Map(addressType));
            }
        }

        public void Save(AddressType addressType)
        {
            if (addressType == null)
                throw new ArgumentNullException("addressType", "Valid addresss type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.AddressTypes.Update(Map(addressType));
            }
        }

        public void Delete(AddressType addressType)
        {
            if (addressType == null)
                throw new ArgumentNullException("addressType", "Valid address type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.AddressTypes.Delete(Map(addressType));
            }
        }

        private AddressType Map(DataAccessLayer.Models.AddressType dbAddressType)
        {
            if (Equals(dbAddressType, null))
                return null;

            AddressType addressType = new AddressType(dbAddressType.Name);
            addressType.Id = dbAddressType.Id;

            return addressType;
        }
        private DataAccessLayer.Models.AddressType Map(AddressType addressType)
        {
            if (Equals(addressType, null))
                throw new ArgumentNullException("addressType", "Valid address type is mandatory!");

            return new DataAccessLayer.Models.AddressType(addressType.Id, addressType.Name);


        }
    }
}
