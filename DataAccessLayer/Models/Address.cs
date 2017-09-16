namespace Phonebook.DataAccessLayer.Models
{
    public class Address
    {
        public Address() { }

        public Address(int id, string city, string zipCode, string street, int houseNo, int contactId, int countryId, int? typeId = null)
        {
            Id = id;
            City = city;
            ZipCode = zipCode;
            Street = street;
            HouseNo = houseNo;
            ContactId = contactId;
            TypeId = typeId;
            CountryId = countryId;
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int HouseNo { get; set; }
        public int ContactId { get; set; }
        public int? TypeId { get; set; }
        public int CountryId { get; set; }
    }
}
