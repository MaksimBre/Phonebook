using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Phonebook.BusinessLogicLayer.Models
{
    public class Contact
    {
        private string name;

        public Contact () { }
        public Contact(string name, byte[] picture = null, DateTime? dateOfBirth = null)
        {
            Name = name;
            Picture = picture;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }
        public string Name
        {
            get
            {
                Debug.Assert(name != null);
                return name;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name", "Valid name is mandatory!");

                string oldValue = name;
                try
                {
                    name = value;
                }
                catch
                {
                    name = oldValue;
                }
            }
        }
        public byte[] Picture { get; set; }
        public DateTime? DateOfBirth { get; set; }

        //public IEnumerable<Phone> Phones { get; set; }
        //public IEnumerable<Address> Addresses { get; set; }
        //public IEnumerable<Email> Emails { get; set; }
    }
}
