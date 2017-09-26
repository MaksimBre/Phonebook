using Phonebook.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class Addresses
    {
        private readonly SqlConnection connection;

        internal Addresses(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection", "Valid connection is mandatory!");

            this.connection = connection;
        }

        public Address GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Addresses WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Address address = new Address();
                    while (reader.Read())
                        address = CreateAddress(reader);

                    return address;
                }
            }
        }

        public IEnumerable<Address> GetAllByContactId(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Addresses WHERE ContactId = @ContactId", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Address> addresses = new List<Address>();
                    while (reader.Read())
                        addresses.Add(CreateAddress(reader));

                    return addresses;
                }
            }
        }

        public int Insert(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address", "Valid address is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO Addresses (City, ZipCode, Street, HouseNo, ContactId, TypeId, CountryId) " +
                                                       "VALUES (@City, @ZipCode, @Street, @HouseNo, @ContactId, @TypeId, @CountryId) " +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode.Optional();
                command.Parameters.Add("@Street", SqlDbType.NVarChar).Value = address.Street;
                command.Parameters.Add("@HouseNo", SqlDbType.Int).Value = address.HouseNo;
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = address.ContactId;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = address.TypeId.Optional();
                command.Parameters.Add("@CountryId", SqlDbType.Int).Value = address.CountryId;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address", "Valid address is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Addresses " +
                                                       "SET  City = @City, ZipCode = @ZipCode, Street = @Street, HouseNo = @HouseNo, ContactId = @ContactId, TypeId = @TypeId, CountryId = @CountryId " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = address.Id;
                command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode.Optional();
                command.Parameters.Add("@Street", SqlDbType.NVarChar).Value = address.Street;
                command.Parameters.Add("@HouseNo", SqlDbType.Int).Value = address.HouseNo;
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = address.ContactId;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = address.TypeId.Optional();
                command.Parameters.Add("@CountryId", SqlDbType.Int).Value = address.CountryId;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Address address)
        {
            using (SqlCommand command = new SqlCommand("DELETE FROM Addresses " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = address.Id;

                command.ExecuteNonQuery();
            }
        }

        private Address CreateAddress(IDataReader reader)
        {
            return new Address((int)reader["Id"], reader["City"] as string, reader["ZipCode"] as string, reader["Street"] as string, (int)reader["HouseNo"], (int)reader["ContactId"], (int)reader["CountryId"], (int)reader["TypeId"].DBNullTo<int?>());
        }
    }
}
