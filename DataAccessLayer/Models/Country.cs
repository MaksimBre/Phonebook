namespace Phonebook.DataAccessLayer.Models
{
    public class Country
    {
        public Country() { }

        public Country(int id, string name, string phonePrefix)
        {
            Id = id;
            Name = name;
            PhonePrefix = phonePrefix;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhonePrefix { get; set; }
    }
}
