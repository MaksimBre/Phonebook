using System;
using System.Data;
using System.Data.SqlClient;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class Phonebook : IDisposable
    {
        private readonly SqlConnection connection;

        public PhoneTypes PhoneTypes { get; set; }
        public Phones Phones { get; set; }
        public AddressTypes AddressTypes { get; set; }
        public Addresses Addresses { get; set; }
        public EmailTypes EmailTypes { get; set; }
        public Emails Emails { get; set; }
        public Contacts Contacts { get; set; }

        public Phonebook(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Valida connection string is mandatory!", "connectionString");

            connection = new SqlConnection(connectionString);
            connection.Open();

            PhoneTypes = new PhoneTypes(connection);
            Phones = new Phones(connection);

            AddressTypes = new AddressTypes(connection);
            Addresses = new Addresses(connection);
            EmailTypes = new EmailTypes(connection);
            Emails = new Emails(connection);
            Contacts = new Contacts(connection);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}