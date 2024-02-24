using System.Data;

namespace Physio.Domain.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        //IDbTransaction BeginTransaction();
    }
}
