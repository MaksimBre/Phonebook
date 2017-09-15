using System;

namespace Phonebook.DataAccessLayer.Models
{
    public class EmailType
    {
        public EmailType()
        {
        }

        public EmailType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
