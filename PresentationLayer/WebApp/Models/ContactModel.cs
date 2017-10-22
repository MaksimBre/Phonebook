using Phonebook.BusinessLogicLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "The name required")]
        public string Name { get; set; }

        public byte[] Picture { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
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
            ContactModel contact = new ContactModel(c.Name, c.Picture, c.DateOfBirth)
            {
                Id = c.Id
            };

            return contact;
        }
    }
}