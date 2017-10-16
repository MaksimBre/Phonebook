using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.DBAccess
{
   public class Emails
    {
        private readonly SqlConnection connection;

        internal Emails(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

       public Email GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Emails WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Email email = new Email();
                    while (reader.Read())
                        email = CreateEmail(reader);

                    return email;
                }
            }
        }

        public IEnumerable<Email> GetAllByContactId(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Emails WHERE ContactId = @ContactId", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Email> emails = new List<Email>();
                    while (reader.Read())
                        emails.Add(CreateEmail(reader));

                    return emails;
                }
            }
        }

        public int Insert(Email email)
        {
            if (email == null)
                throw new ArgumentNullException("email", "Valid email is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO Emails (ContactId, EmailAddress, TypeId) " +
                                                       "VALUES (@ContactId, @EmailAddress, @TypeId) " +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)",connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = email.ContactId;
                command.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email.EmailAddress;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = email.TypeId.Optional();

               return (int)command.ExecuteScalar();
            }
        }

        public void Update(Email email)
        {
            if (email == null)
                throw new ArgumentNullException("email", "Valid email is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Emails " +
                                                       "SET  EmailAddress = @EmailAddress, TypeId = @TypeId " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = email.Id;
                command.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email.EmailAddress;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = email.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand command = new SqlCommand("DELETE FROM Emails " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }
         
        private Email CreateEmail(IDataReader reader )
        {
            return new Email((int)reader["Id"],(int)reader["ContactId"], reader["EmailAddress"] as string, reader["TypeId"].DBNullTo<int?>());
        }
    }
}
