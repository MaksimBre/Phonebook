using Phonebook.BusinessLogicLayer.Managers;
using Phonebook.PresentationLayer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.PresentationLayer.Web.Controllers
{
    public class AddressDetailsController : Controller
    {
        private readonly Addresses AddresssManager = new Addresses();
        private readonly AddressTypes AddressTypesManager = new AddressTypes();
        private readonly Contacts ContactsManager = new Contacts();
        private readonly Countries CountriesManager = new Countries();

        [HttpPost]
        public ActionResult SaveAddress(AddressModel model)
        {
            if (ModelState.IsValid)
            {
                int x = 0;
                string[] stringedIds = model.ParseIds.Split('/');

                model.Id = Int32.TryParse(stringedIds[0], out x) ? x : 0;
                model.Contact = Int32.TryParse(stringedIds[1], out x) ? ContactsManager.GetById(x) : null;
                model.Country = CountriesManager.GetById(model.Country.Id);

                if (model.AddressType.Id == 0)
                {
                    model.AddressType = default(AddressTypeModel);
                }
                else
                {
                    model.AddressType = AddressTypesManager.GetById(model.AddressType.Id);
                }

                if (model.Contact != null)
                {
                    AddresssManager.Save(model);
                }
            }
            return RedirectToAction("Details", "Contact", new { @id = model.Contact.Id });
        }

        [HttpPost]
        public ActionResult AddAddress(AddressModel model)
        {
            if (ModelState.IsValid)
            {
                int x = 0;
                string[] stringedIds = model.ParseIds.Split('/');

                model.Id = Int32.TryParse(stringedIds[0], out x) ? x : 0;
                model.Contact = Int32.TryParse(stringedIds[1], out x) ? ContactsManager.GetById(x) : null;
                model.Country = CountriesManager.GetById(model.Country.Id);

                model.AddressType = AddressTypesManager.GetById(model.AddressType.Id);

                if (model.Contact != null)
                {
                    AddresssManager.Add(model);
                }
            }
            return RedirectToAction("Details", "Contact", new { @id = model.Contact.Id });
        }

        public ActionResult DeleteAddress(int id, int contactId)
        {
            AddresssManager.Delete(id);

            return RedirectToAction("Details", "Contact", new { @id = contactId });
        }
    }
}