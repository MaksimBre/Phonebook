using Phonebook.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
            using (SqlCommand command = new SqlCommand("SELECT * FROM EmailTypes", connection))
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

        public int Insert(EmailType emailtype)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO EmailTypes (Name) " +
                                                       "VALUES (@Name)"+
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emailtype.Name;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(EmailType emailtype)
        {
            using (SqlCommand command = new SqlCommand("UPDATE EmailTypes " +
                                                       "SET  Name = @Name " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = emailtype.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emailtype.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(EmailType emailtype)
        {

            using (SqlCommand command = new SqlCommand("DELETE FROM EmailTypes " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = emailtype.Id;
                command.ExecuteNonQuery();
            }
        }

        private EmailType CreateEmailType(IDataReader reader)
        {
            return new EmailType((int)reader["Id"] ,reader["Name"] as string);
        }
    }
}