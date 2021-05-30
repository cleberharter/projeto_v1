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

        public async Task<List<Person>> FindAllAsync()
        {
            return await Task.FromResult(_personRepository.GetAllIncluding(x => x.Phones).ToList<Person>());
        }

        public async Task AddAsync(Person person)
        {
            person.Add(person.Name);
            await _personRepository.AddAsync(person);
            await _personRepository.UnitOfWork.CommitAsync();
        }

        public async Task<Person> FindAsync(int Id)
        {
            return await Task.FromResult(_personRepository.GetIncluding(Id, x => x.Phones).FirstOrDefault<Person>());
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            _personRepository.Update(person);
            await _personRepository.UnitOfWork.CommitAsync();
            return person;
        }

        public async Task RemoveAsync(int Id)
        {
            var person = await _personRepository.FindAsync(Id);
            _personRepository.Remove(person);
            await _personRepository.UnitOfWork.CommitAsync();
        }
    }
}
