using Phonebook.BusinessLogicLayer.Managers;
using Phonebook.PresentationLayer.Web.Models;
using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace Phonebook.PresentationLayer.Web.Controllers
{
    public class EmailDetailsController : Controller
    {
        private readonly Emails EmailManager = new Emails();
        private readonly EmailTypes emailTypesManager = new EmailTypes();
        private readonly Contacts contactsManager = new Contacts();

        [HttpPost]
        public ActionResult SaveEmail(EmailModel model)
        {
            ModelState.Remove("EmailType.Id");
            if (ModelState.IsValid)
            {
                int x = 0;
                string[] stringedIds = model.ParseIds.Split('/');

                model.Id = Int32.TryParse(stringedIds[0], out x) ? x : 0;
                model.Contact = Int32.TryParse(stringedIds[1], out x) ? contactsManager.GetById(x) : null;

                model.EmailType = model.EmailType.Id != 0 ? emailTypesManager.GetById(model.EmailType.Id) : null;

                if (model.Contact != null)
                {
                    EmailManager.Save(model);
                }
            }
            return RedirectToAction("Details", "Contact", new { @id = model.Contact.Id });
        }

        [HttpPost]
        public ActionResult AddEmail(EmailModel model)
        {
            ModelState.Remove("EmailType.Id");
            if (ModelState.IsValid)
            {
                int x = 0;
                string[] stringedIds = model.ParseIds.Split('/');

                model.Id = Int32.TryParse(stringedIds[0], out x) ? x : 0;
                model.Contact = Int32.TryParse(stringedIds[1], out x) ? contactsManager.GetById(x) : null;

                model.EmailType = model.EmailType.Id != 0 ? emailTypesManager.GetById(model.EmailType.Id) : null;

                if (model.Contact != null)
                {
                    EmailManager.Add(model);
                }
            }
            return RedirectToAction("Details", "Contact", new { @id = model.Contact.Id });
        }

        public ActionResult DeleteEmail(int id, int contactId)
        {
            EmailManager.Delete(id);

            return RedirectToAction("Details", "Contact", new { @id = contactId });
        }
    }
}