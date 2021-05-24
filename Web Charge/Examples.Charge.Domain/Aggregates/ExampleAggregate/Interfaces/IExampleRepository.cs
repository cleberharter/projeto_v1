using Examples.Charge.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces
{
    public interface IExampleRepository : IRepository<Example>
    {
        Task<IEnumerable<Example>> FindAllAsync();
    }
}