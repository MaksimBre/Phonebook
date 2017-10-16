using System;
using System.Diagnostics;

namespace Phonebook.BusinessLogicLayer.Models
{
    public class PhoneType
    {
        private string name;

        public PhoneType() { }
        public PhoneType(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name
        {
            get
            {
                //Debug.Assert(name != null);
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
                    //throw;
                }
            }
        }
    }
}
