using System;

namespace Phonebook.DataAccessLayer.Models
{
    public class Email
    {
        public Email()
        {
        }

        public Email(int contactId, string address, int? typeId = null)
        {
            ContactId = contactId;
            Address = address;
            TypeId = typeId;
        }

        public int ContactId { get; set; }
        public string Address { get; set; }
        public int? TypeId { get; set; }
    }
}