using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.DataAccessLayer.DBAccess;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.ConsoleClient
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> numbers = new List<string>();
            List<string> contacts = new List<string>();

            //List<>

            using (DBAccess.Phonebook phonebook = new DBAccess.Phonebook(Properties.Settings.Default.PhonebookDbConnection))
            {
               
                Console.WriteLine("= = = = Contacts = = = = =");
                Console.WriteLine("= id = = Name = = Picture = = Date of Birth = =  Phone number = = Phone type = =");
                foreach (Contact contact in phonebook.Contacts.GetAll())
                {
                   
                    string picture = Equals(contact.Picture, null) ? "N/A" : "Exist";
                    string dateOfBirth = Equals(contact.DateOfBirth, null) ? "N/A" : contact.DateOfBirth.Value.ToShortDateString();
                    

                   Console.WriteLine($"\n  {contact.Id}    \t{contact.Name}\t {picture}\t  {dateOfBirth}\t    number(s)");
                                      
                 }
                          
            }




        }

    }

}

