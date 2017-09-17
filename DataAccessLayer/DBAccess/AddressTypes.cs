using Phonebook.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<AddressType> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM AddressTypes", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<AddressType> addressTypes = new List<AddressType>();

                    while (reader.Read())
                        addressTypes.Add(CreateAddressType(reader));

                    return addressTypes;
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

        public int Insert(AddressType addressType)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO AddressTypes (Name) " +
                                                       "VALUES (@Name)" +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = addressType.Name;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(AddressType addressType)
        {
            using (SqlCommand command = new SqlCommand("UPDATE AddressTypes " +
                                                       "SET  Name = @Name " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = addressType.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = addressType.Name;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(AddressType addressType)
        {

            using (SqlCommand command = new SqlCommand("DELETE FROM AddressTypes " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = addressType.Id;
                command.ExecuteNonQuery();
            }
        }

        private AddressType CreateAddressType(IDataReader reader)
        {
            return new AddressType((int)reader["Id"], reader["Name"] as string);
        }
    }
}
