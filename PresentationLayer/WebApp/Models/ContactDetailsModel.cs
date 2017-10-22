using Phonebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class ContactDetailsModel
    {
        public ContactDetailsModel() { }
        public ContactDetailsModel(ContactModel c, IEnumerable<PhoneModel> lp, IEnumerable<EmailModel> le, IEnumerable<AddressModel> la)
        {
            Contact = c;
            PhoneList = lp;
            EmailList = le;
            AddressList = la;
        }

        public ContactModel Contact { get; set; }
        public IEnumerable<PhoneModel> PhoneList { get; set; }
        public IEnumerable<EmailModel> EmailList { get; set; }
        public IEnumerable<AddressModel> AddressList { get; set; }

    }
}