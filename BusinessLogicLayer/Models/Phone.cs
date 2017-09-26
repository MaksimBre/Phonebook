using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.BusinessLogicLayer.Models
{
    public class Phone
    {
        private int number;
        private int contactId;
        private int countryId;

        public Phone() { }
        public Phone(int number, int contactId, int countryId, int? typeId = null)
        {
            Number = number;
            ContactId = contactId;
            CountryId = countryId;
            TypeId = typeId;
        }

        public int Id { get; set; }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                int oldValue = number;
                try
                {
                    number = value;
                }
                catch
                {
                    number = oldValue;
                    //throw;
                }
            }
        }

        public int ContactId
        {
            get
            {
                return contactId;
            }
            set
            {
                int oldValue = contactId;
                try
                {
                    contactId = value;
                }
                catch
                {
                    contactId = oldValue;
                    //throw;
                }
            }
        }

        public int CountryId
        {
            get
            {
                return countryId;
            }
            set
            {
                int oldValue = countryId;
                try
                {
                    countryId = value;
                }
                catch
                {
                    countryId = oldValue;
                    //throw;
                }
            }
        }

        public int? TypeId { get; set; }
    }
}
