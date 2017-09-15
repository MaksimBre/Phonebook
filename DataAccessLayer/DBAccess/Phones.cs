using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.DBAccess
{
   public class Phones
    {
        private readonly SqlConnection connection;

        internal Phones(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection", "Valid connection is mandatory!");

            this.connection = connection;
        }

      public IEnumerable<Phone> GetByContactId(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Phones WHERE ContactId = @ContactId", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Phone> phones = new List<Phone>();
                    while (reader.Read())
                        phones.Add(CreatePhone(reader));

                    return phones;
                }
            }
        }

        public void Insert(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException("phone", "Valid phone is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO Phones (ContactId, Number, TypeId) " +
                                                       "VALUES (@ContactId, @Number, @TypeId)", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = phone.ContactId; 
                command.Parameters.Add("@Number", SqlDbType.NVarChar).Value = phone.Number;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = phone.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }

        public void Update(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException("phone", "Valid phone is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Phones " +
                                                       "SET Number = @Number, TypeId = @TypeId " +
                                                       "WHERE ContactId = @ContactId AND Number = @Number", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = phone.ContactId;
                command.Parameters.Add("@Number", SqlDbType.NVarChar).Value = phone.Number;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = phone.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }
        public void Update(Phone phone, string num)
        {
            if (phone == null)
                throw new ArgumentNullException("phone", "Valid phone is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Phones " + 
                                                       "SET Number = @Num, TypeId = @TypeId " +
                                                       "WHERE ContactId = @ContactId AND Number = @Number", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = phone.ContactId;
                command.Parameters.Add("@Number", SqlDbType.NVarChar).Value = phone.Number;
                command.Parameters.Add("@Num", SqlDbType.NVarChar).Value = num;//parameter for new number that will be inserted in database
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = phone.TypeId.Optional();

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException("phone", "Valid phone is mandatory!");

            using (SqlCommand command = new SqlCommand("DELETE FROM Phones " +
                                                       "WHERE ContactId = @ContactId AND Number = @Number", connection))
            {
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = phone.ContactId;
                command.Parameters.Add("@Number", SqlDbType.NVarChar).Value = phone.Number;

                command.ExecuteNonQuery();
            }
        }

        private Phone CreatePhone(IDataReader reader)
        {
            return new Phone((int)reader["ContactId"], reader["Number"] as string, reader["TypeId"].DBNullTo<int?>());
        }
    }
}
