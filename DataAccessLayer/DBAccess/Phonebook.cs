using System;
using System.Data;
using System.Data.SqlClient;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class Phonebook : IDisposable
    {
        private readonly SqlConnection connection;

        public Emails Emails { get; set; }
        public Contacts Contacts { get; set; }

        public Phonebook(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Valida connection string is mandatory!", "connectionString");

            connection = new SqlConnection(connectionString);
            connection.Open();

            Emails = new Emails(connection);
            Contacts = new Contacts(connection);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}