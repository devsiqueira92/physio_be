using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    Task RegisterUser(string id, CancellationToken cancellationToken);
}