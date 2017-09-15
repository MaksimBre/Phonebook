using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Phonebook.DataAccessLayer.Models;

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

       public IEnumerable<Address> GetByContactId(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Addresses WHERE ContactId = @ContactId", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Address> phones = new List<Address>();
                    while (reader.Read())
                        phones.Add(CreateAddress(reader));

                    return phones;
                }
            }
        }

        public void Insert(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address", "Valid address is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO Addresses (ContactId, Country, City, ZipCode, Street, HouseNo, TypeID) " +
                                                       "VALUES (@ContactId, @Country, @City, @ZipCode, @Street, @HouseNo,  @TypeId)", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = address.ContactId;
                command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = address.Country.Optional();
                command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode.Optional();
                command.Parameters.Add("@Street", SqlDbType.NVarChar).Value = address.Street;
                command.Parameters.Add("@HouseNo", SqlDbType.NVarChar).Value = address.HouseNo;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = address.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }

        public void Update(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address", "Valid address is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Addresses "+
                                                       "SET ContactId = @ContactId, Country = @Country, City = @City, ZipCode = @ZipCode, Street = @Street, HouseNo = @HouseNo, TypeId = @TypeId " +
                                                       "WHERE ContactId = @ContactId AND City = @City AND Street = @Street AND HouseNo = @HouseNo",connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = address.ContactId;
                command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = address.Country.Optional();
                command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode.Optional();
                command.Parameters.Add("@Street", SqlDbType.NVarChar).Value = address.Street;
                command.Parameters.Add("@HouseNo", SqlDbType.NVarChar).Value = address.HouseNo;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = address.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }

        public void Update(Address address, string city, string street, string houseNo)
        {
            if (address == null)
                throw new ArgumentNullException("address", "Valid address is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Addresses " +
                                                       "SET ContactId = @ContactId, Country = @Country, City = @Ci, ZipCode = @ZipCode, Street = @str, HouseNo = @hNo, TypeId = @TypeId " +
                                                       "WHERE ContactId = @ContactId AND City = @City AND Street = @Street AND HouseNo = @HouseNo",connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = address.ContactId;
                command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = address.Country.Optional();
                command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                command.Parameters.Add("@Ci", SqlDbType.NVarChar).Value = city;//new value for city 
                command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode.Optional();
                command.Parameters.Add("@Street", SqlDbType.NVarChar).Value = address.Street;
                command.Parameters.Add("@str", SqlDbType.NVarChar).Value = street;//new value for street
                command.Parameters.Add("@HouseNo", SqlDbType.NVarChar).Value = address.HouseNo;
                command.Parameters.Add("@hNo", SqlDbType.NVarChar).Value = houseNo;//new value for houseNo
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = address.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address", "Valid address is mandatory!");

            using (SqlCommand command = new SqlCommand("DELETE FROM  Addresses " +
                                                       "WHERE ContactId = @ContactId AND City = @City AND Street = @Street AND HouseNo = @HouseNo", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = address.ContactId;
                command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                command.Parameters.Add("@Street", SqlDbType.NVarChar).Value = address.Street;
                command.Parameters.Add("@HouseNo", SqlDbType.NVarChar).Value = address.HouseNo;
             

                command.ExecuteNonQuery();
            }
        }

        private Address CreateAddress(IDataReader reader)
        {
            return new Address((int)reader["ContactId"], reader["Country"] as string, reader["City"] as string, reader["ZipCode"] as string, reader["Street"] as string, reader["HouseNo"] as string, reader["TypeId"].DBNullTo<int?>());
        }


    }
}
