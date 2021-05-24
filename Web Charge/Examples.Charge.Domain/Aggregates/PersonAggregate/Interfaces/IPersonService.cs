using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<Person> FindAsync(int Id);

        Task<List<Person>> FindAllAsync();

        Task AddAsync(Person person);

        Task<Person> UpdateAsync(Person person);

        Task RemoveAsync(int Id);
    }
}
