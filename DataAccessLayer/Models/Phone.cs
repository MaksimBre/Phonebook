using System;


namespace Phonebook.DataAccessLayer.Models
{
   public class Phone
    {
        public Phone() { }
        public Phone(int contactId, string number, int? typeId)
        {
            ContactId = contactId;
            Number = number;
            TypeId = typeId;
        }

        public int ContactId { get; set; }
        public string Number { get; set; }
        public int? TypeId { get; set; }
    }
}
