using System;
using System.Diagnostics;

namespace Phonebook.BusinessLogicLayer.Models
{
    public class Country
    {
        private string name;
        private string phonePrefix;

        public Country() { }

        public Country(string name, string phonePrefix)
        {
            Name = name;
            PhonePrefix = phonePrefix;
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

        public string PhonePrefix
        {
            get
            {
                Debug.Assert(phonePrefix != null);
                return phonePrefix;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("PhonePrefix", "Valid phone prefix is mandatory!");

                string oldValue = phonePrefix;
                try
                {
                    phonePrefix = value;
                }
                catch
                {
                    phonePrefix = oldValue;
                    //throw;
                }
            }
        }

    }
}
