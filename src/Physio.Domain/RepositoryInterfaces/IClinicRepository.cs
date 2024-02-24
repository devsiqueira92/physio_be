using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IClinicRepository
{
    Task CreateAsync(ClinicEntity entity, CancellationToken cancellationToken = default);
    void Update(ClinicEntity entity);
    Task<List<ClinicEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ClinicEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> CheckAvailabilityAsync(string userId, CancellationToken cancellationToken = default);
}