using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface ISchedulingTypeRepository
{
    Task CreateAsync(SchedulingTypeEntity entity, CancellationToken cancellationToken = default);
    void Update(SchedulingTypeEntity entity);
    Task<List<SchedulingTypeEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<SchedulingTypeEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
}