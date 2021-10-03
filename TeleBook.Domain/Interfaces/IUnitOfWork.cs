using System.Threading;
using System.Threading.Tasks;

namespace TeleBook.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> CompleteAsync(CancellationToken cancellationToken = default);
    }
}