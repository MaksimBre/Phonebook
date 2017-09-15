namespace Phonebook.DataAccessLayer.Models
{
    public class Email
    {
        public Email()
        {
        }

        public Email(int id,int contactId, string emailAddress, int? typeId = null)
        {
            Id = id;
            ContactId = contactId;
            EmailAddress = emailAddress;
            TypeId = typeId;
        }

        public int Id { get; set; }
        public int ContactId { get; set; }
        public string EmailAddress { get; set; }
        public int? TypeId { get; set; }
    }
}