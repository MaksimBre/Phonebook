using System;

namespace Phonebook.DataAccessLayer.Models
{
    public class AddressType
    {
        public AddressType()
        {
        }

        public AddressType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
