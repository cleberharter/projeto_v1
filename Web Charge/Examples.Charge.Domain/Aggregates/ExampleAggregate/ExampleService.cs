using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate
{
    public class ExampleService : IExampleService
    {
        private IExampleRepository _repository;
        public ExampleService(IExampleRepository exampleService)
        {
            _repository = exampleService;
        }

        public Task AddAsync(Example example)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Example>> FindAllAsync() => (await _repository.FindAllAsync()).ToList();
    }
}
