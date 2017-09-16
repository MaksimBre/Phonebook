using System;
using System.Data.SqlClient;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class Phonebook : IDisposable
    {
        private readonly SqlConnection connection;

        public Emails Emails { get; set; }
        public EmailTypes EmailTypes { get; set; }
        public Contacts Contacts { get; set; }
        public Phones Phones { get; set; }
        public PhoneTypes PhoneTypes { get; set; }
        public Countries Countries { get; set; }
        public Addresses Addresses { get; set; }

        public Phonebook(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Valida connection string is mandatory!", "connectionString");

            connection = new SqlConnection(connectionString);
            connection.Open();

            Emails = new Emails(connection);
            EmailTypes = new EmailTypes(connection);
            Contacts = new Contacts(connection);
            Phones = new Phones(connection);
            PhoneTypes = new PhoneTypes(connection);
            Countries = new Countries(connection);
            Addresses = new Addresses(connection);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}