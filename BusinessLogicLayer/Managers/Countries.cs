using Phonebook.BusinessLogicLayer.Managers.Properties;
using Phonebook.BusinessLogicLayer.Models;
using System;

namespace Phonebook.BusinessLogicLayer.Managers
{
    public class Countries
    {
        public Country GetById(int id)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return Map(phonebook.Countries.GetById(id));
            }
        }

        public int Add(Country country)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                return phonebook.Countries.Insert(Map(country));
            }
        }

        public void Save(Country country)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Countries.Update(Map(country));
            }
        }

        public void Delete(Country country)
        {
            using (DataAccessLayer.DBAccess.Phonebook phonebook = new DataAccessLayer.DBAccess.Phonebook(Settings.Default.PhonebookDBConnection))
            {
                phonebook.Countries.Delete(Map(country));
            }
        }

        private Country Map(DataAccessLayer.Models.Country dbCountry)
        {
            if (dbCountry == null)
                return null;

            Country country = new Country(dbCountry.Name, dbCountry.PhonePrefix);
            country.Id = dbCountry.Id;

            return country;
        }

        private DataAccessLayer.Models.Country Map(Country country)
        {
            if (country == null)
                throw new ArgumentNullException("country", "Valid country is mandatory!");

            return new DataAccessLayer.Models.Country(country.Id, country.Name, country.PhonePrefix);
        }
    }
}
