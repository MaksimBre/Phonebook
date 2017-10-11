using Phonebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class EmailModel
    {
        public EmailModel(){ }

        public EmailModel(int contactId, string emailAddress, int? typeId = null)
        {
            ContactId = contactId;
            EmailAddress = emailAddress;
            TypeId = typeId;
        }

        public int Id { get; set; }
        public int ContactId { get; set; }
        public string EmailAddress { get; set; }
        public int? TypeId { get; set; }

        public static implicit operator Email(EmailModel cm)
        {
            Contact contact = new Contact() { Id = cm.ContactId };
            EmailType emailType = new EmailType() { Id = (int)cm.TypeId };

            Email email = new Email(contact, cm.EmailAddress, emailType)
            {
                Id = cm.Id
            };

            return email;
        }

        public static implicit operator EmailModel(Email c)
        {

            EmailModel emailModel = new EmailModel(c.Contact.Id, c.EmailAddress, c.EmailType.Id)
            {
                Id = c.Id
            };

            return emailModel;
        }
    }
}