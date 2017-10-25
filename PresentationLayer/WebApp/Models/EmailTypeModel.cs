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

        public static implicit operator EmailType(EmailTypeModel etm)
        {
            if (etm == null)
                return null;

            EmailType emailType = new EmailType(etm.Name)
            {
            Id = etm.Id
            };

            return emailType;
        }

        public static implicit operator EmailTypeModel(EmailType et)
        {
            if (et == null)
                return null;

            EmailTypeModel emailType = new EmailTypeModel(et.Name)
            {
                Id = et.Id
            };

            return emailType;
        }
    }
}