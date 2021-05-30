using Examples.Charge.Application.Dtos.Person;

namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public PhoneNumberTypeDto PhoneNumberType { get; set; }
    }
}
