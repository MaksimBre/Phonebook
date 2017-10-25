using System;
using System.Collections.Generic;
using System.Linq;
using Phonebook.BusinessLogicLayer.Models;
using Phonebook.BusinessLogicLayer.Managers.Properties;

namespace Phonebook.BusinessLogicLayer.Managers
{
  public class Contacts
    {
        public IEnumerable<Contact> GetAll()
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.Contacts.GetAll().Select(pt => Map(pt));
            }
        }
        public IEnumerable<Contact> Search(string srch)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.Contacts.Search(srch).Select(pt => Map(pt));
            }
        }

        public Contact GetById(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return Map(phonebook.Contacts.GetById(id));
            }
        }

        public int Add(Contact contact)
        {
            
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.Contacts.Insert(Map(contact));
            }
           
        }

        public void Save(Contact contact)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Contacts.Update(Map(contact));
            }
        }

        public void Delete(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Contacts.Delete(id);
            }
        }

        private Contact Map(DataAccessLayer.Models.Contact dbContact)
        {
            if (dbContact == null)
                return null;

            Contact contact = new Contact(dbContact.Name, dbContact.Picture, dbContact.DateOfBirth)
            {
                Id = dbContact.Id
            };

            return contact;
        }

        private DataAccessLayer.Models.Contact Map(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact", "Valid contact is mandatory!");

            return new DataAccessLayer.Models.Contact(contact.Id, contact.Name, contact.Picture, contact.DateOfBirth);
        }
    }
}
