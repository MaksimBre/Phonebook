using System;
using Phonebook.BusinessLogicLayer.Managers.Properties;
using Phonebook.BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.BusinessLogicLayer.Managers
{
    public class Addresses
    {
        /*public Address GetById(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return Map(phonebook.Addresses.GetById(id));
            }
        }*/

        public IEnumerable<Address> GetAllByContact(Contact contact)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                //return Map(phonebook.Addresses.GetAllByContact(contact));
                return phonebook.Addresses.GetAllByContactId(contact.Id).Select(pt => Map(pt, contact));
            }
        }

        public int Add(Address address)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.Addresses.Insert(Map(address));
            }
        }

        public void Save(Address address)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Addresses.Update(Map(address));
            }
        }

        public void Delete(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Addresses.Delete(id);
            }
        }

        private Address Map(DataAccessLayer.Models.Address dbAddress, Contact contact)
        {
            if (dbAddress == null)
                return null;

            if (contact == null)
                return null;

            Address address = new Address(dbAddress.City, dbAddress.Street, dbAddress.HouseNo, contact, new Countries().GetById(dbAddress.CountryId), dbAddress.ZipCode, dbAddress.TypeId.HasValue ? new AddressTypes().GetById(dbAddress.TypeId.Value) : null);
            address.Id = dbAddress.Id;

            return address;
        }

        /*private Address Map(DataAccessLayer.Models.Address dbAddress)
        {
            if (dbAddress == null)
                return null;

            Address address = new Address(dbAddress.City, dbAddress.Street, dbAddress.HouseNo, dbAddress.ContactId, dbAddress.CountryId, dbAddress.ZipCode, dbAddress.TypeId);
            address.Id = dbAddress.Id;

            return address;
        }*/

        private DataAccessLayer.Models.Address Map(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address", "Valid address is mandatory!");

            return new DataAccessLayer.Models.Address(address.Id, address.City, address.ZipCode, address.Street, address.HouseNo, address.Contact.Id, address.Country.Id, address.AddressType.Id);
        }
    }
}
