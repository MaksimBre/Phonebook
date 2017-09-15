using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class EmailTypes
    {
        private readonly SqlConnection connection;

        internal EmailTypes(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection", "Valid connection is mandatory!");

            this.connection = connection;
        }

       public IEnumerable<EmailType> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM EMailTypes", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<EmailType> emailTypes = new List<EmailType>();
                    while (reader.Read())
                        emailTypes.Add(CreateEmailType(reader));

                    return emailTypes;
                }
            }
        }

      public  EmailType GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM EMailTypes WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateEmailType(reader);

                    return null;
                }
            }
        }

        public int Insert(EmailType emailType)
        {
            if (emailType == null)
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO EMailTypes (Name) VALUES (@Name); " +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emailType.Name;

                return emailType.Id = (int)command.ExecuteScalar();
            }
        }

        public void Update(EmailType emailType)
        {
            if (emailType == null)
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE EMailTypes SET Name = @Name WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = emailType.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emailType.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(EmailType emailType)
        {
            if (emailType == null)
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            using (SqlCommand command = new SqlCommand("DELETE FROM EMailTypes WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = emailType.Id;

                command.ExecuteNonQuery();
            }
        }

        private EmailType CreateEmailType(IDataReader reader)
        {
            return new EmailType((int)reader["Id"], reader["Name"] as string);
        }
    }
}
