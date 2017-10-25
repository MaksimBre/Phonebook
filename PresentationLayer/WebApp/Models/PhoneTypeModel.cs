using Phonebook.BusinessLogicLayer.Models;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class PhoneTypeModel
    {
        public PhoneTypeModel() { }
        public PhoneTypeModel(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator PhoneType(PhoneTypeModel ptm)
        {
            if (ptm == null)
                return null;

            PhoneType phoneType = new PhoneType(ptm.Name);
            phoneType.Id = ptm.Id;

            return phoneType;
        }

        public static implicit operator PhoneTypeModel(PhoneType pt)
        {
            if (pt == null)
                return null;

            PhoneTypeModel phoneType = new PhoneTypeModel(pt.Name);
            phoneType.Id = pt.Id;

            return phoneType;
        }
    }
}