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
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

       public Phone GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Phones WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Phone phone = new Phone();
                    while (reader.Read())
                        phone = CreatePhone(reader);

                    return phone;
                }
            }
        }

        public IEnumerable<Phone> GetAllByContactId(int id)
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

        public int Insert(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException("phone", "Valid phone is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO Phones (Number, TypeId, ContactId, CountryId) " +
                                                       "VALUES (@Number, @TypeId, @ContactId, @CountryId) " +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)",connection))
            {
                command.Parameters.Add("@Number", SqlDbType.Int).Value = phone.Number;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = phone.TypeId.Optional();
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = phone.ContactId;
                command.Parameters.Add("@CountryId", SqlDbType.Int).Value = phone.CountryId;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException("phone", "Valid phone is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Phone " +
                                                       "SET  Number = @Number, TypeId = @TypeId, ContactId = @ContactId, CountryId = @CountryId " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = phone.Id;
                command.Parameters.Add("@Number", SqlDbType.Int).Value = phone.Number;
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = phone.TypeId.Optional();
                command.Parameters.Add("@ContactId", SqlDbType.Int).Value = phone.ContactId;
                command.Parameters.Add("@CountryId", SqlDbType.Int).Value = phone.CountryId;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand command = new SqlCommand("DELETE FROM Phones " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }
         
        private Phone CreatePhone(IDataReader reader )
        {
            return new Phone((int)reader["Id"],(int)reader["Number"], (int)reader["ContactId"], (int)reader["CountryId"], reader["TypeId"].DBNullTo<int?>());
        }
    }
}
