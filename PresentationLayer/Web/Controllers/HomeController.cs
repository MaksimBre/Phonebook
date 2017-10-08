using Phonebook.BusinessLogicLayer.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhoneTypes manager = new PhoneTypes();

        public ActionResult Index()
        {
            IEnumerable<PhoneTypeModel> model = manager.GetAll().Select(x => (PhoneTypeModel)x);

            return View(model);
        }

        public ActionResult Test()
        {
            IEnumerable<PhoneTypeModel> model = manager.GetAll().Select(x => (PhoneTypeModel)x);

            return View(model.First());
        }

        [HttpPost]
        public ActionResult SavePhoneType(PhoneTypeModel model)
        {
            manager.Save(model);

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