using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Phonebook.DataAccessLayer.Models;

namespace Phonebook.DataAccessLayer.DBAccess
{
   public class Contacts
    {
        private readonly SqlConnection connection;

        internal Contacts(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection", "Valid connection is mandatory!");

            this.connection = connection;
        }

      public  IEnumerable<Contact> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Contacts ", connection))
            {


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Contact> contacts = new List<Contact>();
                    while (reader.Read())
                        contacts.Add(CreateContact(reader));

                    return contacts;
                }
            }
        }

        public Contact GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Contacts WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return CreateContact(reader);

                    return null;
                }
            }
        }
        public IEnumerable<Contact> Search(string name)
        {
            using (SqlCommand command = new SqlCommand("SELECT *  FROM Contacts WHERE Name LIKE '@Name' OR Surname LIKE '@Name' ", connection))//?
            {
              command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name + "%";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Contact> contacts = new List<Contact>();
                    while (reader.Read())
                        contacts.Add(CreateContact(reader));

                    return contacts;
                }
            }
        }

        public int Insert(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact", "Valid contact is mandatory!");

            using (SqlCommand command = new SqlCommand("INSERT INTO Contacts (Name, Surname, Picture, DateOfBirth) " +
                                                       "VALUES (@Name, @Picture, @DateOfBirth)"+ 
                                                       "SELECT CAST(SCOPE_IDENTITY() AS int)", connection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = contact.Name;
                command.Parameters.Add("@Picture", SqlDbType.Image).Value = contact.Picture.Optional();
                command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = contact.DateOfBirth.Optional();
                
                return  contact.Id =  (int)command.ExecuteScalar();
            }
        }

        public void Update(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact", "Valid contact is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Contacts " + 
                                                       "SET Name, Picture, DateOfBirth " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = contact.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = contact.Name;
                command.Parameters.Add("@Picture", SqlDbType.Image).Value = contact.Picture.Optional();
                command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = contact.DateOfBirth.Optional();

                command.ExecuteNonQuery();
            }
        }
        public void Update(Contact contact,string name, string surname, string picture, DateTime? dateOfBirth)
        {
            if (contact == null)
                throw new ArgumentNullException("contact", "Valid contact is mandatory!");

            using (SqlCommand command = new SqlCommand("UPDATE Contacts " +
                                                       "SET Name = @Name, Surname=@Surname, Picture=@Picture, DateOfBirth=@DateOfBirth " +
                                                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = contact.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = surname;
                command.Parameters.Add("@Picture", SqlDbType.Image).Value = picture.Optional();
                command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateOfBirth.Optional();

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact", "Valid contact is mandatory!");

            using (SqlCommand command = new SqlCommand("DELETE FROM Contacts " +
                                                       "WHERE Id = @Id ", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = contact.Id;

                command.ExecuteNonQuery();
            }
        }

        private Contact CreateContact(IDataReader reader)
        {
            return new Contact((int)reader["Id"], reader["Name"] as string, reader["Picture"] as byte[], reader["DateOfBirth"].DBNullTo<DateTime?>());


        }
    }
}
