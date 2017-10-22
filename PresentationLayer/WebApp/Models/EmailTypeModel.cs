using Phonebook.BusinessLogicLayer.Models;

namespace Phonebook.PresentationLayer.Web.Models
{
    public class EmailTypeModel
    {
        public EmailTypeModel() { }

        public EmailTypeModel(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator EmailType(EmailTypeModel et)
        {
            EmailType emailType = new EmailType(et.Name)
            {
                Id = et.Id
            };

            return emailType;
        }

        public static implicit operator EmailTypeModel(EmailType et)
        {
            EmailTypeModel emailType = new EmailTypeModel(et.Name)
            {
                Id = et.Id
            };

            return emailType;
        }
    }
}