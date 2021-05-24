using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Dtos.Person
{
    public class AddOrUpdatePersonDto
    {
        public string Name { get; set; }

        public Task<ValidationResult> Validate()
            => new AddOrUpdateProductDtoValidator()
                .ValidateAsync(this);

        private class AddOrUpdateProductDtoValidator : AbstractValidator<AddOrUpdatePersonDto>
        {
            public AddOrUpdateProductDtoValidator()
            {
                RuleFor(x => x.Name)
                    .Length(1, 100);
            }
        }
    }
}
