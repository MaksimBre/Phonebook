using Phonebook.BusinessLogicLayer.Models;

namespace Web.Models
{
    public class CountryModel
    {
        public CountryModel() { }
        public CountryModel(string name, string phonePrefix)
        {
            Name = name;
            PhonePrefix = phonePrefix;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhonePrefix { get; set; }

        public static implicit operator Country(CountryModel cm)
        {
            Country country = new Country(cm.Name, cm.PhonePrefix);
            country.Id = cm.Id;

            return country;
        }

        public static implicit operator CountryModel(Country c)
        {
            CountryModel country = new CountryModel(c.Name, c.PhonePrefix);
            country.Id = c.Id;

            return country;
        }
    }
}