using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.DataAccessLayer.Models
{
    public class Phone
    {
        public Phone() { }

        public Phone(int id, int number, int contactId, int countryId, int? typeId)
        {
            Id = id;
            Number = number;
            TypeId = typeId;
            ContactId = contactId;
            CountryId = countryId;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public int ContactId { get; set; }
        public int CountryId { get; set; }
        public int? TypeId { get; set; }
    }
}
