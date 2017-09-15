using System;

namespace Phonebook.DataAccessLayer.Models
{
    public class Contact
    {
        public Contact()
        {
        }

        public Contact(int id, string name, byte[] picture, DateTime? dateOfBirth)
        {
            Id = id;
            Name = name;
            Picture = picture;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get;  set;}
        public DateTime? DateOfBirth { get; set; }
    }
}
