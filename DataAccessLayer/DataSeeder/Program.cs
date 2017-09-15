using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.DataAccessLayer.Models;
using Phonebook.DataAccessLayer.DBAccess;

namespace Phonebook.DataAccessLayer.DataSeeder
{
  static class Program
    {
        static void Main(string[] args)
        {

            using (DBAccess.Phonebook phonebook = new DBAccess.Phonebook(Properties.Settings.Default.PhonebookDbConnection))
            {
                phonebook.AddressTypes.Insert(new AddressType() { Name = null });
                //phonebook.Phones.Insert(new Phone()
                //{
                //    ContactId = 10,
                //    Number = "+12122627625"
                //});

                //phonebook.Phones.Update(new Phone()
                //{
                //    ContactId = 10,
                //    Number = "+12123569377467",
                //    TypeId = 23
                //},"+358 6954753");
                //phonebook.Contacts.Insert(new Contact()
                //{
                //    Name = "Bob",
                //    Surname = "Rock",
                //    Picture = null,
                //    DateOfBirth = new DateTime(1969, 5, 5)
                //});

                //int id = phonebook.Contacts.Insert(new Contact()
                //{
                //    Name = "Pera",
                //    Surname = "Peric",
                //    DateOfBirth = DateTime.Parse("1967/5/24")

                //});
                //phonebook.AddressTypes.Insert(new AddressType()
                //{
                //    Name = "Home"
                //});
                //phonebook.AddressTypes.Insert(new AddressType()
                //{
                //    Name = "Work"
                //});
                //phonebook.PhoneTypes.Insert(new PhoneType()
                //{
                //    Name = "Home"
                //});
                //phonebook.PhoneTypes.Insert(new PhoneType()
                //{
                //    Name = "Work"
                //});
                //phonebook.PhoneTypes.Insert(new PhoneType()
                //{
                //    Name = "Celluar"
                //});
                //phonebook.EmailTypes.Insert(new EmailType()
                //{
                //    Name = "Personal"
                //});
                //phonebook.EmailTypes.Insert(new EmailType()
                //{
                //    Name = "Work"
                //});
                //phonebook.Emails.Insert(new Email()
                //{
                //    ContactId = id,
                //    Address = "pera.peric@example.com"
                //});
                //phonebook.Phones.Insert(new Phone()
                //{
                //    ContactId = 3,
                //    Number = "+381 60 4321567",
                //});
                //phonebook.Addresses.Insert(new Address()
                //{
                //    ContactId = id,
                //    City = "Zrenjanin",
                //    Street = "Zmaj Jovina",
                //    HouseNo = "25"
                //});
            }

        }
    }
}
