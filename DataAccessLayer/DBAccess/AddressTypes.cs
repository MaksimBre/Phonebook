using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class AddressTypes
    {
        private readonly SqlConnection connection;

        internal AddressTypes(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection", "Valid connection is mandatory!");

            this.connection = connection;
        }

      public  IEnumerable<AddressType> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM AddressTypes", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<AddressType> addressType = new List<AddressType>();
                    while (reader.Read())
                        addressType.Add(CreateAddressType(reader));

                    return addressType;
                }
            }
        }

       public AddressType GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM AddressTypes WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateAddressType(reader);

                    return null;
                }
            }
        }

        public int Insert(AddressType addressTypes)
        {
            if (addressTypes == null)
                throw new ArgumentNullException("addressTypes", "Valid address type is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO AddressTypes (Name) VALUES (@Name); " +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = addressTypes.Name;

                return addressTypes.Id = (int)command.ExecuteScalar();
            }
        }

        public void Update(AddressType addressTypes)
        {
            if (addressTypes == null)
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE AddressType SET Name = @Name WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = addressTypes.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = addressTypes.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(AddressType addressTypes)
        {
            if (addressTypes == null)
                throw new ArgumentNullException("emailType", "Valid email type is mandatory!");

            using (SqlCommand command = new SqlCommand("DELETE FROM AddressType WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = addressTypes.Id;

                command.ExecuteNonQuery();
            }
        }

        private AddressType CreateAddressType(IDataReader reader)
        {
            return new AddressType((int)reader["Id"], reader["Name"] as string);
        }
    }
}
