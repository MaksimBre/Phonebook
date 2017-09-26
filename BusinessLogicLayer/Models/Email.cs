using System;
using System.Diagnostics;


namespace Phonebook.BusinessLogicLayer.Models
{
    public class Email
    {
        private Contact contact;
        private string emailAddress;
        public Email() { }
        public Email(Contact contact, string emailAddress, EmailType emailType = null)
        {
            Contact = contact;
            EmailAddress = emailAddress;
            EmailType = emailType;
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
        public string EmailAddress
        {
            get
            {
                Debug.Assert(!Equals(emailAddress,null));
                return emailAddress;
            }
            set
            { if (Equals(value, null))
                    throw new ArgumentNullException("EmailAddress", "Valid email address is mandatory");

                emailAddress = value;
            } }
        public EmailType EmailType { get; set; }
    }
}
