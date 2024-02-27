using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IAddressRepository
{
    Task CreateAsync(AddressEntity entity, CancellationToken cancellationToken = default);
    void Update(AddressEntity entity);
    Task<List<AddressEntity>> GetAddressListAsync(string userId, CancellationToken cancellationToken = default);
}