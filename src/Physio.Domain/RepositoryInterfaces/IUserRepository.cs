using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    Task<UserEntity> RegisterUser(string id, CancellationToken cancellationToken);
}