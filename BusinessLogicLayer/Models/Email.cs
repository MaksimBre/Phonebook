using System;
using System.Diagnostics;


namespace Phonebook.BusinessLogicLayer.Models
{
    public class Email
    {
        private Contact contact;
        private string address;
        public Email() { }
        public Email(Contact contact, string address/*, EmailType emailType = null*/)
        {
            Contact = contact;
            Address = address;
            //EmailType = emailType;
        }

        public int Id { get; set; }
        public Contact Contact
        { get
            { 
                Debug.Assert(!Equals(contact, null));
                return contact;
            }
            set
            {
                if (Equals(value, null))
                    throw new ArgumentNullException("Email", "Valid email is mandatory");

                contact = value;
            }
        }
        public string Address
        {
            get
            {
                Debug.Assert(!Equals(address,null));
                return address;
            }
            set
            { if (Equals(value, null))
                    throw new ArgumentNullException("Address", "Valid address is mandatory");

                address = value;
            } }
        //public EmailType EmailType { get; set; }
    }
}
