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
            if (connection == null)
                throw new ArgumentNullException("connection", "Valid connection is mandatory!");

            this.connection = connection;
        }

       public IEnumerable<Email> GetByContactId(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM EMails WHERE ContactId = @ContactId", connection))
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

        public void Insert(Email email)
        {
            if (email == null)
                throw new ArgumentNullException("email", "Valid email is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO EMails (ContactId, Address, TypeId) " +
                                                       "VALUES (@ContactId, @Address, @TypeId)", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = email.ContactId;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = email.Address;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = email.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }

        public void Update(Email email)
        {
            if (email == null)
                throw new ArgumentNullException("email", "Valid email is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE EMails " +
                                                       "SET  Address = @Address, TypeId = @TypeId " +
                                                       "WHERE ContactId = @ContactId AND Address = @Address", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = email.ContactId;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = email.Address;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = email.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }
        public void Update(Email email, string address)
        {
            if (email == null)
                throw new ArgumentNullException("email", "Valid email is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE EMails " +
                                                       "SET Address = @Adr, TypeId = @TypeId " +
                                                       "WHERE ContactId = @ContactId AND Address = @Address", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = email.ContactId;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = email.Address;
                command.Parameters.Add("@Adr", SqlDbType.NVarChar).Value = address;   // new value for email address
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = email.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }
        public void Delete(Email email)
        {
            if (email == null)
                throw new ArgumentNullException("email", "Valid email is mandatory!");

            using (SqlCommand command = new SqlCommand("DELETE FROM EMails " +
                                                       "WHERE ContactId = @ContactId AND Address = @Address", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = email.ContactId;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = email.Address;
               

                command.ExecuteNonQuery();
            }
        }
         
        private Email CreateEmail(IDataReader reader )
        {
            return new Email((int)reader["ContactId"], reader["Address"] as string, reader["TypeId"].DBNullTo<int?>());
        }
    }
}
