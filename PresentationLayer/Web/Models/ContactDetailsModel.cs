using Phonebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class ContactDetailsModel
    {
        public ContactDetailsModel() { }
        public ContactDetailsModel(ContactModel c, IEnumerable<PhoneModel> lp, IEnumerable<EmailModel> le)
        {
            Contact = c;
            PhoneList = lp;
            EmailList = le;
        }

        public ContactModel Contact { get; set; }
        public IEnumerable<PhoneModel> PhoneList { get; set; }
        public IEnumerable<EmailModel> EmailList { get; set; }

    }
}