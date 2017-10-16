using System;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Table.Width =160;
            Table.Title = "Users";
            Table.ColumnNames = new string[] { "Id", "Name", "Date of Birth", "Number", "Email", "City", "Street and number" };
            Table.Setup();

            using (DBAccess.Phonebook phonebook = new DBAccess.Phonebook(Properties.Settings.Default.PhonebookDbConnection))
            {
                foreach (Contact contact in phonebook.Contacts.GetAll())
                {
                    Table.Insert(1, contact.Id.ToString());
                    Table.Insert(2, contact.Name);
                    string dateOfBirth = Equals(contact.DateOfBirth, null) ? "N/A" : contact.DateOfBirth.Value.ToShortDateString();
                    Table.Insert(3, dateOfBirth);

                    foreach (Phone phone in phonebook.Phones.GetAllByContactId(contact.Id))
                    {
                        Country country = phonebook.Countries.GetById(phone.CountryId);
                        if (phone.TypeId != null)
                        {
                            PhoneType phonetype = phonebook.PhoneTypes.GetById((int)phone.TypeId);
                            string typename = Equals(phonetype, null) ? "N/A" : phonetype.Name;
                            Table.Insert(4, country.PhonePrefix + phone.Number.ToString() + " (" + typename + ")");
                        }
                        else
                        {
                            Table.Insert(4, country.PhonePrefix + phone.Number.ToString());
                        }
                    }

                    foreach (Email email in phonebook.Emails.GetAllByContactId(contact.Id))
                    {
                        EmailType type = phonebook.EmailTypes.GetById((int)email.TypeId);
                        Table.Insert(5, email.EmailAddress + " (" + type.Name + ")");
                    }

                    foreach (Address address in phonebook.Addresses.GetAllByContactId(contact.Id))
                    {
                        Table.Insert(6, address.City);


                        if (address.TypeId != null)
                        {
                            AddressType addressType = phonebook.AddressTypes.GetById((int)address.TypeId);
                            Table.Insert(7, address.Street + " " + address.HouseNo + " (" + addressType.Name + ")");
                        }
                        else
                        {
                            Table.Insert(7, address.Street + " " + address.HouseNo);
                        }
                    }

                    Table.NewRow();

                }

            }

        }

    }

}

