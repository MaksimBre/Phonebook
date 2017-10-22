using Phonebook.BusinessLogicLayer.Managers;
using Phonebook.PresentationLayer.Web.Models;
using System;
using System.Web.Mvc;

namespace Phonebook.PresentationLayer.Web.Controllers
{
    public class PhoneDetailsController : Controller
    {
        private readonly Phones PhoneManager = new Phones();
        private readonly PhoneTypes phoneTypesManager = new PhoneTypes();
        private readonly Contacts contactsManager = new Contacts();
        private readonly Countries countriesManager = new Countries();

        [HttpPost]
        public ActionResult SavePhone(PhoneModel model)
        {
            if (ModelState.IsValid)
            {
                int x = 0;
                string[] stringedIds = model.ParseIds.Split('/');

                model.Id = Int32.TryParse(stringedIds[0], out x) ? x : 0;
                model.Contact = Int32.TryParse(stringedIds[1], out x)? contactsManager.GetById(x) : null;
                model.Country = countriesManager.GetById(model.Country.Id);
                model.PhoneType = phoneTypesManager.GetById(model.PhoneType.Id);

                if (model.Contact != null)
                {
                    PhoneManager.Save(model);
                }
            }
            return RedirectToAction("Details", "Contact",new { @id = model.Contact.Id } );
        }

        [HttpPost]
        public ActionResult AddPhone(PhoneModel model)
        {
            if (ModelState.IsValid)
            {
                int x = 0;
                string[] stringedIds = model.ParseIds.Split('/');

                model.Id = Int32.TryParse(stringedIds[0], out x) ? x : 0;
                model.Contact = Int32.TryParse(stringedIds[1], out x) ? contactsManager.GetById(x) : null;
                model.Country = countriesManager.GetById(model.Country.Id);
                model.PhoneType = phoneTypesManager.GetById(model.PhoneType.Id);

                if (model.Contact != null)
                {
                    PhoneManager.Add(model);
                }
            }
            return RedirectToAction("Details", "Contact", new { @id = model.Contact.Id });
        }

        public ActionResult DeletePhone(int id, int contactId)
        {
            PhoneManager.Delete(id);

            return RedirectToAction("Details", "Contact", new { @id = contactId });
        }
    }
}