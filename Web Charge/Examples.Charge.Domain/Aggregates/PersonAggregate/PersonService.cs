using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task AddAsync(Person person)
        {
            person.Add(person.Name);
            await _personRepository.AddAsync(person);
            await _personRepository.UnitOfWork.CommitAsync();
        }

        public async Task<Person> FindAsync(int Id)
        {
            return await _personRepository.FindAsync(Id);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            var personResult = await _personRepository.UpdateAsync(person);
            await _personRepository.UnitOfWork.CommitAsync();
            return personResult;
        }

        public async Task RemoveAsync(int Id)
        {
            var person = await _personRepository.FindAsync(Id);
            _personRepository.Remove(person);
            await _personRepository.UnitOfWork.CommitAsync();
        }
    }
}
