using Phonebook.BusinessLogicLayer.Managers;
using Phonebook.PresentationLayer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhoneTypes PhoneTypeManager = new PhoneTypes();
        private readonly Contacts ContactManager = new Contacts();

        public ActionResult Index()
        {
            //IEnumerable<PhoneTypeModel> model = PhoneTypeManager.GetAll().Select(x => (PhoneTypeModel)x);
            IEnumerable<ContactModel> model = ContactManager.GetAll().Select(x => (ContactModel)x);

            return View(model);
        }
        
        public ActionResult Details(int id)
        {
            ContactModel model = ContactManager.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult SavePhoneType(PhoneTypeModel model)
        {
            PhoneTypeManager.Save(model);

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}