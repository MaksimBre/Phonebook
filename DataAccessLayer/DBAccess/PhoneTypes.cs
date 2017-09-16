using Phonebook.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class PhoneTypes
    {
        private readonly SqlConnection connection;

        internal PhoneTypes(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection", "Valid connection is mandatory!");

            this.connection = connection;
        }

        public IEnumerable<PhoneType> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM PhoneTypes", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PhoneType> phoneType = new List<PhoneType>();

                    while (reader.Read())
                        phoneType.Add(CreatePhoneType(reader));

                    return phoneType;
                }
            }
        }

        public PhoneType GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM PhoneTypes WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreatePhoneType(reader);

                    return null;
                }
            }
        }

        public int Insert(PhoneType phonetype)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO PhoneTypes (Name) " +
                                                       "VALUES (@Name)" +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = phonetype.Name;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(PhoneType phonetype)
        {
            using (SqlCommand command = new SqlCommand("UPDATE PhoneTypes " +
                                                       "SET  Name = @Name " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = phonetype.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = phonetype.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(PhoneType phonetype)
        {

            using (SqlCommand command = new SqlCommand("DELETE FROM PhoneTypes " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = phonetype.Id;
                command.ExecuteNonQuery();
            }
        }

        private PhoneType CreatePhoneType(IDataReader reader)
        {
            return new PhoneType((int)reader["Id"], reader["Name"] as string);
        }
    }
}
