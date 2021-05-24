using Examples.Charge.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IEnumerable<PersonAggregate.Person>> FindAllAsync();
    }
}
