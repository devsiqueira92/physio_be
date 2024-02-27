using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IContactRepository
{
    Task CreateAsync(ContactEntity entity, CancellationToken cancellationToken = default);
    void Update(ContactEntity entity);
    Task<ContactEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<ContactEntity>> GetContactListAsync(string userId, CancellationToken cancellationToken = default);
}