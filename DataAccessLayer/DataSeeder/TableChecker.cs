using System;
using Phonebook.DataAccessLayer.DBAccess;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.DataSeeder
{
    public static class TableChecker
    {
        public static void CheckContactTable(DBAccess.Phonebook phonebook)
        {
            Contact update = new Contact()
            {
                Name = "Dragan Gagy",
                DateOfBirth = new DateTime(1993, 9, 4),
                Picture = null
            };

            Contact delete = new Contact()
            {
                Name = "Kurac Palac",
                DateOfBirth = new DateTime(1997, 12, 6),
                Picture = null
            };

            phonebook.Contacts.Insert(new Contact()
            {
                Name = "Maksim Bogunovic",
                DateOfBirth = new DateTime(1997, 12, 6),
                Picture = null
            });


            update.Id = phonebook.Contacts.Insert(update);

            update.Name = "Dragan Ilic";

            delete.Id = phonebook.Contacts.Insert(delete);

            phonebook.Contacts.Update(update);
            phonebook.Contacts.Delete(delete);

            CheckEmailTable(phonebook.Emails, update, CheckEmailTypesTable(phonebook.EmailTypes));
        }

        public static EmailType CheckEmailTypesTable(EmailTypes emailTypes)
        {
            EmailType newEmailType = new EmailType()
            {
                Name = "Home"
            };
            emailTypes.Insert(newEmailType);

            newEmailType = new EmailType()
            {
                Name = "Work"
            };
            emailTypes.Insert(newEmailType);

            newEmailType.Name = "Memes";
            emailTypes.Update(newEmailType);

            newEmailType = new EmailType()
            {
                Name = "Memes"
            };
            newEmailType.Id = emailTypes.Insert(newEmailType);

            return newEmailType;
        }

        public static void CheckEmailTable(Emails emails, Contact contact, EmailType emailType)
        {
            Email email1 = new Email()
            {
                EmailAddress = "pera@gmail.com",
                ContactId = contact.Id,
                TypeId = emailType.Id
            };

            email1.Id = emails.Insert(email1);

            Email email2 = new Email()
            {
                EmailAddress = "rick@ricknmorty.com",
                ContactId = contact.Id,
                TypeId = emailType.Id
            };

            email2.Id  = emails.Insert(email2);

            email1.EmailAddress = "novi@email.com";
            emails.Update(email1);

            emails.Delete(email2.Id);


        }

    }
}
