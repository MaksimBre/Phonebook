using Phonebook.BusinessLogicLayer.Managers;
using Phonebook.BusinessLogicLayer.Models;
using Phonebook.PresentationLayer.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.PresentationLayer.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly Contacts ContactManager = new Contacts();
        private readonly Emails EmailManager = new Emails();
        private readonly Phones PhoneManager = new Phones();
        private readonly Addresses AddressManager = new Addresses();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Title = "Contact details";
            if (id.HasValue)
            {
                Contact contact = ContactManager.GetById((int)id);
                
                if (contact == null)
                {
                    return RedirectToAction("Index", "Home");

                }

                IEnumerable<PhoneModel> phones = PhoneManager.GetAllByContact(contact).Select(x => (PhoneModel)x);
                IEnumerable<EmailModel> emails = EmailManager.GetAllByContact(contact).Select(x => (EmailModel)x);
                IEnumerable<AddressModel> addresses = AddressManager.GetAllByContact(contact).Select(x => (AddressModel)x);

                ContactDetailsModel model = new ContactDetailsModel()
                {
                    Contact = contact,
                    EmailList = emails,
                    PhoneList = phones,
                    AddressList = addresses
                };

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(ContactModel contactModel, HttpPostedFileBase file)
        {

            if (file != null)
            {
                contactModel.Picture = new byte[file.ContentLength];
                file.InputStream.Read(contactModel.Picture, 0, file.ContentLength);
            }

            ContactManager.Save(contactModel);

            return RedirectToAction("Details", "Contact", new { @id = contactModel.Id });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactModel contactModel, HttpPostedFileBase file)
        {
            if (file != null)
            {
                contactModel.Picture = new byte[file.ContentLength];
                file.InputStream.Read(contactModel.Picture, 0, file.ContentLength);
            }
            ContactManager.Add(contactModel);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            ContactManager.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}