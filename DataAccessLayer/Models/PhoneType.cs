namespace Phonebook.DataAccessLayer.Models
{
    public class PhoneType
    {
        public PhoneType() { }

        public PhoneType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
