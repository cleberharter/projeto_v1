using System.Collections.Generic;

namespace Examples.Charge.Application.Dtos.Person
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PersonPhoneDto> Phones { get; set; }
    }
}
