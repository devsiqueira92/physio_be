using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IStatusSchedulingRepository
{
    Task CreateAsync(StatusSchedulingEntity entity, CancellationToken cancellationToken = default);
    void Update(StatusSchedulingEntity entity);
    Task<List<StatusSchedulingEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<StatusSchedulingEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<StatusSchedulingEntity> GetByEnumAsync(StatusSchedulingEnum schedulingEnum, CancellationToken cancellationToken = default);
}