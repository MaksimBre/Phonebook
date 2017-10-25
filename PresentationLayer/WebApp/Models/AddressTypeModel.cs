using Phonebook.BusinessLogicLayer.Models;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class AddressTypeModel
    {
        public AddressTypeModel() { }
        public AddressTypeModel(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator AddressType(AddressTypeModel atm)
        {
            if (atm == null)
                return null;

            AddressType addressType = new AddressType(atm.Name);
            addressType.Id = atm.Id;

            return addressType;
        }

        public static implicit operator AddressTypeModel(AddressType at)
        {
            if (at == null)
                return null;

            AddressTypeModel addressType = new AddressTypeModel(at.Name);
            addressType.Id = at.Id;

            return addressType;
        }
    }
}