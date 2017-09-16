using System;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.ConsoleClient
{
    class Program
    {
        static int[] Locations = new int[] { 0, 8, 35, 51, 73, 94, 113, 141, 161, 180, 200, 220, 230 };
        static int x = 1;

        static void Main(string[] args)
        {
            Console.WindowWidth = 231;
            DrawHeader();
            /*List<string> numbers = new List<string>();
            List<string> contacts = new List<string>();
            List<string> emails = new List<string>();
            List<Phone> phones = new List<Phone>();*/
            
            using (DBAccess.Phonebook phonebook = new DBAccess.Phonebook(Properties.Settings.Default.PhonebookDbConnection))
            {

                foreach (Contact contact in phonebook.Contacts.GetAll())
                {

                    string picture = Equals(contact.Picture, null) ? "N/A" : "Exist";
                    string dateOfBirth = Equals(contact.DateOfBirth, null) ? "N/A" : contact.DateOfBirth.Value.ToShortDateString();
                    WriteToTable(1, contact.Id.ToString());
                    WriteToTable(2, contact.Name);
                    WriteToTable(3, picture);
                    WriteToTable(4, dateOfBirth);
                    WriteToTable(5);
                    WriteToTable(6);
                    Country country = new Country();
                    foreach (Phone phone in phonebook.Phones.GetAllByContactId(contact.Id))
                    {
                        country = phonebook.Countries.GetById(phone.CountryId);
                        WriteToTable(5, country.PhonePrefix+ phone.Number.ToString());
                        if(phone.TypeId != null)
                        {
                            PhoneType phonetype = new PhoneType();
                            phonetype = phonebook.PhoneTypes.GetById((int)phone.TypeId);
                            string typename = Equals(phonetype, null) ? "N/A" : phonetype.Name;
                            WriteToTable(6, typename);
                        }
                        WriteToTable(9, country.Name);
                    }

                    WriteToTable(7);
                    WriteToTable(8);

                    foreach (Email email in phonebook.Emails.GetAllByContactId(contact.Id))
                    {
                        WriteToTable(7, email.EmailAddress);
                        EmailType type = phonebook.EmailTypes.GetById((int)email.TypeId);
                        WriteToTable(8, type.Name);
                    }

                    WriteToTable(9);
                    foreach (Address address in phonebook.Addresses.GetAllByContactId(contact.Id))
                    {
                        WriteToTable(9,"aaa");
                    }

                    

                    

                    WriteToTable(10);
                    WriteToTable(11);
                    WriteToTable(12);
                    WriteToTable(0);
                }

            }
            WriteToTable(0);
            WriteToTable(0);
            WriteToTable(0);

        }
        public static void WriteToTable(int n, string d = "")
        {
            if (n != 0)
            {
                Console.SetCursorPosition(Locations[n - 1], x);
                Console.Write($"| {d}");
            }
            else
            {
                Console.WriteLine();
                x++;
            }

        }
        public static void DrawHeader()
        {
            Console.Write(" ____________________________________________________________________________________________________________________/ CONTACTS \\___________________________________________________________________________________________");
            WriteToTable(1, "  id");
            WriteToTable(2, "           Name");
            WriteToTable(3, "    Picture");
            WriteToTable(4, "    Date of Birth");
            WriteToTable(5, "    Phone number");
            WriteToTable(6, "    Phone type");
            WriteToTable(7, "           Email");
            WriteToTable(8, "    Email Type");
            WriteToTable(9, "     Country");
            WriteToTable(10, "     Address");
            WriteToTable(11, "  Address Type");
            WriteToTable(12);
            WriteToTable(0);
            WriteToTable(1);
            WriteToTable(2);
            WriteToTable(3);
            WriteToTable(4);
            WriteToTable(5);
            WriteToTable(6);
            WriteToTable(7);
            WriteToTable(8);
            WriteToTable(9);
            WriteToTable(10);
            WriteToTable(11);
            WriteToTable(12);
            WriteToTable(0);
        }

    }

}

