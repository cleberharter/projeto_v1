using Examples.Charge.Application.Common;
using Examples.Charge.Application.Dtos.Person;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public async Task<ActionResult<PersonDto>> Find(int id)
        {
            PersonDto result = await _facade.FindAsync(id);

            if (result is null)
                return Response(null);

            return Response(new PersonResponse() { Person = result, Success = true });
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<ActionResult<PersonDto>> Create([FromBody] AddOrUpdatePersonDto personDto)
        {
            ApplicationDataResult<PersonDto> result = await _facade.AddAsync(personDto);

            if (!result.IsSuccess)
                return Response(new PersonResponse() { Errors = result.Errors, Success = result.IsSuccess });

            return Response(new PersonResponse() { Person = result.Data, Success = result.IsSuccess });
        }

        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Update))]
        public async Task<ActionResult<PersonDto>> Update(int id, [FromBody] AddOrUpdatePersonDto productDto)
        {
            ApplicationDataResult<PersonDto> result = await _facade.UpdateAsync(id, productDto);

            if (!result.IsSuccess)
                return Response(new PersonResponse() { Errors = result.Errors, Success = result.IsSuccess });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<PersonDto>> Delete(int id)
        {
            ApplicationDataResult<PersonDto> result = await _facade.RemoveAsync(id);

            if (!result.IsSuccess)
                return Response(new PersonResponse() { Errors = result.Errors, Success = result.IsSuccess });

            return Response(null);
        }
    }
}
