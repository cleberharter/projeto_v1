using System.Threading.Tasks;

namespace Examples.Charge.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}