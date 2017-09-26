using Phonebook.BusinessLogicLayer.Managers.Properties;
using Phonebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.BusinessLogicLayer.Managers
{
    public class EmailTypes
    {
        public IEnumerable<EmailType> GetAll()
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.EmailTypes.GetAll().Select(et => Map(et));
            }
        }

        public EmailType GetById(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return Map(phonebook.EmailTypes.GetById(id));
            }
        }

        public int Add(EmailType emailType)
        {
            if (emailType == null)
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.EmailTypes.Insert(Map(emailType));
            }
        }

        public void Save(EmailType emailType)
        {
            if (emailType == null)
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.EmailTypes.Update(Map(emailType));
            }
        }

        public void Delete(EmailType emailType)
        {
            if (emailType == null)
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.EmailTypes.Delete(Map(emailType));
            }
        }

        private EmailType Map(DataAccessLayer.Models.EmailType dbEmailType)
        {
            if (Equals(dbEmailType, null))
                return null;

            EmailType emailType = new EmailType(dbEmailType.Name);
            emailType.Id = dbEmailType.Id;

            return emailType;
        }
        private DataAccessLayer.Models.EmailType Map(EmailType emailType)
        {
            if (Equals(emailType, null))
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            return new DataAccessLayer.Models.EmailType(emailType.Id, emailType.Name);


        }
    }
}
