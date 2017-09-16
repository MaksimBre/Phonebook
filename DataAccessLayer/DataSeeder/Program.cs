using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.DataAccessLayer.Models;
using Phonebook.DataAccessLayer.DBAccess;

namespace Phonebook.DataAccessLayer.DataSeeder
{
  public class Program
    {
        static void Main(string[] args)
        {

            using (DBAccess.Phonebook phonebook = new DBAccess.Phonebook(Properties.Settings.Default.PhonebookDbConnection))
            {
                //TableChecker.CheckContactTable(phonebook);
                //TableChecker.CheckPhoneTable(phonebook);
                TableChecker.CheckAllTables(phonebook);
            }

        }
    }
}
