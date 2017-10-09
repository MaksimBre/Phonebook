using Phonebook.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Phonebook.DataAccessLayer.DBAccess
{
    public class Countries
    {
        private readonly SqlConnection connection;

        internal Countries(SqlConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("connection", "Valid connection is mandatory!");
        }

        public IEnumerable<Country> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Countries", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Country> countries = new List<Country>();

                    while (reader.Read())
                        countries.Add(CreateCountry(reader));

                    return countries;
                }
            }
        }

        public Country GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Countries WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Country country = new Country();
                    while (reader.Read())
                        country = CreateCountry(reader);

                    return country;
                }
            }
        }

        public int Insert(Country country)
        {
            if (country == null)
                throw new ArgumentNullException("country", "Valid country is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO Countries (Name, PhonePrefix) " +
                                                       "VALUES (@Name, @PhonePrefix) " +
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = country.Name;
                command.Parameters.Add("@PhonePrefix", SqlDbType.NVarChar).Value = country.PhonePrefix;

                return (int)command.ExecuteScalar();
            }
        }

        public void Update(Country country)
        {
            if (country == null)
                throw new ArgumentNullException("country", "Valid country is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Countries " +
                                                       "SET  Name = @Name, PhonePrefix = @PhonePrefix " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = country.Name;
                command.Parameters.Add("@PhonePrefix", SqlDbType.NVarChar).Value = country.PhonePrefix;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Country country)
        {
            using (SqlCommand command = new SqlCommand("DELETE FROM Countries " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = country.Id;

                command.ExecuteNonQuery();
            }
        }

        private Country CreateCountry(IDataReader reader)
        {
            return new Country((int)reader["Id"], reader["Name"] as string, reader["PhonePrefix"] as string);
        }
    }
}
