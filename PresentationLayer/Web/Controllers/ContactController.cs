using Phonebook.BusinessLogicLayer.Managers;
using Phonebook.BusinessLogicLayer.Models;
using Phonebook.PresentationLayer.Web.Models;
using System.Web.Mvc;

namespace Phonebook.PresentationLayer.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly Contacts ContactManager = new Contacts();
        private readonly Emails EmailManager = new Emails();
        private readonly Phones PhoneManager = new Phones();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Title = "Contact details";
            if (id.HasValue)
            {
                ContactModel model = ContactManager.GetById((int)id);
                model.Emails = EmailManager.GetByContact(model);
                model.Phones = PhoneManager.GetAllByContact(model);

                return View(model);
            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult Edit(int id)
        {
            ContactModel model = ContactManager.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ContactModel contactModel)
        {
            ContactManager.Save(contactModel);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactModel contactModel)
        {
            ContactManager.Add(contactModel);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(ContactModel contactModel)
        {
            ContactManager.Delete(contactModel);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeletePhone(PhoneModel phoneModel)
        {
            PhoneManager.Delete(phoneModel);
            return RedirectToAction("Index", "Home");
        }
    }
}