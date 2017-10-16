using Phonebook.BusinessLogicLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class EmailModel
    {
        public EmailModel() {
            Contact = new ContactModel();
            EmailType = new EmailTypeModel();
        }

        public EmailModel(ContactModel contact, string emailAddress, EmailTypeModel emailType = default(EmailTypeModel))
        {
            Contact = contact;
            EmailAddress = emailAddress;
            EmailType = emailType;
        }

        public int Id { get; set; }
        public ContactModel Contact { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        public EmailTypeModel EmailType { get; set; }
        public string ParseIds { get; set; }

        public static implicit operator Email(EmailModel cm)
        {
            Email email = new Email(cm.Contact, cm.EmailAddress, cm.EmailType)
            {
                Id = cm.Id
            };

            return email;
        }

        public static implicit operator EmailModel(Email c)
        {
            EmailModel emailModel = new EmailModel(c.Contact, c.EmailAddress, c.EmailType)
            {
                Id = c.Id
            };

            return emailModel;
        }
    }
}