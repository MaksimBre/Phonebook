using Phonebook.BusinessLogicLayer.Managers;
using Phonebook.PresentationLayer.Web.Models;
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
            ViewBag.Title = "Contact list";
            IEnumerable<ContactModel> model = ContactManager.GetAll().Select(x => (ContactModel)x);
            
            return View(model);
        }
    }
}