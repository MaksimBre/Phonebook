using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.DataAccessLayer.DBAccess;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.DataSeeder
{
    public static class TableChecker
    {
        public static void CheckContactTable(Contacts contacts)
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

            contacts.Insert(new Contact()
            {
                Name = "Maksim Bogunovic",
                DateOfBirth = new DateTime(1997, 12, 6),
                Picture = null
            });

            update.Id = contacts.Insert(update);

            delete.Id = contacts.Insert(delete);

            contacts.Update(update);
            contacts.Delete(delete);
        }
    }
}
