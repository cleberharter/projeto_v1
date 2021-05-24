using Microsoft.EntityFrameworkCore;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Reflection;
using Examples.Charge.Core.Data;
using System.Threading.Tasks;
using Abp.Events.Bus;
using System.Linq;
using Abp.Domain.Entities;

namespace Examples.Charge.Infra.Data.Context
{
    public class ExampleContext : DbContext, IUnitOfWork
    {
        public static bool firstRun = true;

        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ExampleContext)));
        }

        public async Task<bool> CommitAsync()
        {
            bool isSuccess = await base.SaveChangesAsync() > 0;

            if (isSuccess)
            {
                ChangeTracker.Entries<AggregateRoot>().ToList().ForEach(x =>
                {
                    x.Entity.DomainEvents.ToList().ForEach(d =>
                    {
                        EventBus.Default.Trigger(d.GetType(), x.Entity, d);
                    });
                });
            }

            return isSuccess;
        }

        public DbSet<Example> Example { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonPhone> PersonPhone { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberType { get; set; }
    }
}