using Phonebook.BusinessLogicLayer.Models;
using System;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class ContactModel
    {
        public ContactModel() { }
        public ContactModel(string name, byte[] picture, DateTime? dateOfBirth)
        {
            Name = name;
            Picture = picture;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public static implicit operator Contact(ContactModel cm)
        {
            Contact contact = new Contact(cm.Name, cm.Picture, cm.DateOfBirth)
            {
                Id = cm.Id
            };

            return contact;
        }

        public static implicit operator ContactModel(Contact c)
        {
            ContactModel contact = new ContactModel(c.Name, c.Picture, c.DateOfBirth);
            contact.Id = c.Id;

            return contact;
        }
    }
}