using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class PhoneTypes
    {
        private readonly SqlConnection connection;

        internal PhoneTypes(SqlConnection connection) //only phonebook.cs can access to this constructor 
                                                      // Phonebook.cs and PhoneTypes.cs are in the same assembly

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
                    List<PhoneType> phoneTypes = new List<PhoneType>();
                    while (reader.Read())
                        phoneTypes.Add(CreatePhoneType(reader));

                    return phoneTypes;
                }
            }
        }

     public   PhoneType GetById(int id)
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

        public int Insert(PhoneType phoneType)
        {
            if (phoneType == null)
                throw new ArgumentNullException("phoneType", "Valid phone type is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO PhoneTypes (Name) VALUES (@Name); " +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = phoneType.Name;

                return phoneType.Id = (int)command.ExecuteScalar();
            }
        }

        public void Update(PhoneType phoneType)
        {
            if (phoneType == null)
                throw new ArgumentNullException("phoneType", "Valid phone type is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE PhoneTypes SET Name = @Name WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = phoneType.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = phoneType.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(PhoneType phoneType)
        {
            if (phoneType == null)
                throw new ArgumentNullException("phoneType", "Valid phone type is mandatory!");

            using (SqlCommand command = new SqlCommand("DELETE FROM PhoneTypes WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = phoneType.Id;

                command.ExecuteNonQuery();
            }
        }

        private PhoneType CreatePhoneType(IDataReader reader)
        {
            return new PhoneType((int)reader["Id"], reader["Name"] as string);
        }
    }
}
