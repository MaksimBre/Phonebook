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
            phonebook.Contacts.Delete(delete.Id);

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

            email2.Id = emails.Insert(email2);

            email1.EmailAddress = "novi@email.com";
            emails.Update(email1);

            emails.Delete(email2.Id);


        }
        public static void CheckPhoneTable(DBAccess.Phonebook phonebook)
        {
            Contact contact1 = new Contact()
            {
                Name = "Milenko Kostic",
                DateOfBirth = new DateTime(1997, 10, 8),
                Picture = null

            };
            contact1.Id = phonebook.Contacts.Insert(contact1);

            Contact contact2 = new Contact()
            {
                Name = "Andrija Agic",
                DateOfBirth = new DateTime(1994, 2, 12),
                Picture = null

            };
            contact2.Id = phonebook.Contacts.Insert(contact2);

            Country country1 = new Country()
            {
                Name = "Serbia",
                PhonePrefix = "+381"
            };
            country1.Id = phonebook.Countries.Insert(country1);

            PhoneType phonetype1 = new PhoneType()
            {
                Name = "Home"
            };
            phonetype1.Id = phonebook.PhoneTypes.Insert(phonetype1);

            PhoneType phonetype2 = new PhoneType()
            {
                Name = "Work"
            };
            phonetype2.Id = phonebook.PhoneTypes.Insert(phonetype2);

            Phone phone1 = new Phone()
            {
                Number = 333555,
                TypeId = phonetype1.Id,
                ContactId = contact1.Id,
                CountryId = country1.Id
            };

            Phone phone2 = new Phone()
            {
                Number = 111111111,
                TypeId = phonetype2.Id,
                ContactId = contact2.Id,
                CountryId = country1.Id
            };

            phone1.Id = phonebook.Phones.Insert(phone1);
            phone2.Id = phonebook.Phones.Insert(phone2);
        }

        public static void CheckAllTables(DBAccess.Phonebook phonebook)
        {
            Contact contact1 = new Contact()
            {
                Name = "Milenko Kostic",
                DateOfBirth = new DateTime(1997, 10, 8),
                Picture = null

            };
            contact1.Id = phonebook.Contacts.Insert(contact1);

            Contact contact2 = new Contact()
            {
                Name = "Andrija Agic",
                DateOfBirth = new DateTime(1994, 2, 12),
                Picture = null

            };
            contact2.Id = phonebook.Contacts.Insert(contact2);

            Contact contact3 = new Contact()
            {
                Name = "Ratko Mladic",
                DateOfBirth = new DateTime(1978, 5, 3),
                Picture = null

            };
            contact3.Id = phonebook.Contacts.Insert(contact3);

            Contact ctemp = new Contact()
            {
                Name = "Temp Temp",
                DateOfBirth = new DateTime(1933, 5, 3),
                Picture = null

            };
            ctemp.Id = phonebook.Contacts.Insert(ctemp);
            phonebook.Contacts.Delete(ctemp.Id);

            contact3.Name = "Dragan Ilic";
            contact3.DateOfBirth = new DateTime(1993,10,30);
            phonebook.Contacts.Update(contact3); 

            EmailType etype1 = new EmailType()
            {
                Name = "Private"
            };
            etype1.Id = phonebook.EmailTypes.Insert(etype1);

            EmailType etype2 = new EmailType()
            {
                Name = "Business"
            };
            etype2.Id = phonebook.EmailTypes.Insert(etype2);

            EmailType etype3 = new EmailType()
            {
                Name = "Stupid memes"
            };
            etype3.Id = phonebook.EmailTypes.Insert(etype3);

            EmailType ettemp = new EmailType()
            {
                Name = "TEMP"
            };
            ettemp.Id = phonebook.EmailTypes.Insert(ettemp);
            phonebook.EmailTypes.Delete(ettemp);

            etype3.Name = "Good Memes";
            phonebook.EmailTypes.Update(etype3);

            Email email1 = new Email()
            {
                EmailAddress = "milena@gmail.com",
                ContactId = contact1.Id,
                TypeId = etype1.Id
            };

            email1.Id = phonebook.Emails.Insert(email1);
            Email email2 = new Email()
            {
                EmailAddress = "andrej@gmail.com",
                ContactId = contact2.Id,
                TypeId = etype1.Id
            };
            email2.Id = phonebook.Emails.Insert(email2);

            Email email3 = new Email()
            {
                EmailAddress = "gagi@gmail.com",
                ContactId = contact3.Id,
                TypeId = etype3.Id
            };

            email3.Id = phonebook.Emails.Insert(email3);

            Country country1 = new Country()
            {
                Name = "Serbia",
                PhonePrefix = "+381"
            };
            country1.Id = phonebook.Countries.Insert(country1);

            Country country2 = new Country()
            {
                Name = "USA",
                PhonePrefix = "+011"
            };
            country2.Id = phonebook.Countries.Insert(country2);

            PhoneType phonetype1 = new PhoneType()
            {
                Name = "Home"
            };
            phonetype1.Id = phonebook.PhoneTypes.Insert(phonetype1);

            PhoneType phonetype2 = new PhoneType()
            {
                Name = "Work"
            };
            phonetype2.Id = phonebook.PhoneTypes.Insert(phonetype2);

            Phone phone1 = new Phone()
            {
                Number = 333555,
                TypeId = phonetype1.Id,
                ContactId = contact1.Id,
                CountryId = country1.Id
            };
            phone1.Id = phonebook.Phones.Insert(phone1);

            Phone phone2 = new Phone()
            {
                Number = 56565665,
                TypeId = phonetype2.Id,
                ContactId = contact2.Id,
                CountryId = country2.Id
            };
            phone2.Id = phonebook.Phones.Insert(phone2);

            AddressType addressType1 = new AddressType()
            {
                Name = "Office"
            };
            addressType1.Id = phonebook.AddressTypes.Insert(addressType1);

            AddressType addressType2 = new AddressType()
            {
                Name = "Home"
            };
            addressType2.Id = phonebook.AddressTypes.Insert(addressType2);

            Address address1 = new Address()
            {
                City = "Zrenjanin",
                ZipCode = "23000",
                Street = "Uteroti Janos",
                HouseNo = 30,
                ContactId = contact1.Id,
                TypeId = addressType1.Id,
                CountryId = country1.Id
            };
            address1.Id = phonebook.Addresses.Insert(address1);

            Address address2 = new Address()
            {
                City = "Washington",
                ZipCode = "11000",
                Street = "White House",
                HouseNo = 2,
                ContactId = contact2.Id,
                TypeId = addressType2.Id,
                CountryId = country2.Id
            };
            address2.Id = phonebook.Addresses.Insert(address2);
            address2.ZipCode = "33333";
            phonebook.Addresses.Update(address2);

            /*Address atemp = new Address()
            {
                City = "Washington",
                ZipCode = "11000",
                Street = "White House",
                HouseNo = 2,
                ContactId = contact1.Id,
                CountryId = country1.Id
            };
            atemp.Id = phonebook.Addresses.Insert(atemp);
            phonebook.Addresses.Delete(atemp.Id);*/


        }
    }
}
