using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IProtocolRepository
{
    Task CreateAsync(ProtocolEntity entity, CancellationToken cancellationToken = default);
    void Update(ProtocolEntity entity);
    Task<List<ProtocolEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ProtocolEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
}