using Examples.Charge.Application.Common;
using Examples.Charge.Application.Dtos.Person;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonDto> FindAsync(int id);

        Task<PersonListResponse> FindAllAsync();

        Task<ApplicationDataResult<PersonDto>> AddAsync(AddOrUpdatePersonDto productDto);

        Task<ApplicationDataResult<PersonDto>> RemoveAsync(int id);

        Task<ApplicationDataResult<PersonDto>> UpdateAsync(int id, AddOrUpdatePersonDto productDto);
    }
}