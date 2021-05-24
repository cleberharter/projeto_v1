using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos.Person;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonResponse : BaseResponse
    {
        public PersonDto Person { get; set; }
    }
}