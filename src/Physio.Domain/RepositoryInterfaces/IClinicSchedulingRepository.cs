using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IClinicSchedulingRepository
{
    Task CreateAsync(ClinicSchedulingEntity entity, CancellationToken cancellationToken = default);
    void Update(ClinicSchedulingEntity entity);
    Task<List<ClinicSchedulingEntity>> GetClinicSchedulingsByDateAsync(int month, int year, string userId, CancellationToken cancellationToken = default);
    Task<List<ClinicSchedulingEntity>> GetClinicSchedulingsByProfessionalAsync(int page, int pageSize, Guid professionalId, CancellationToken cancellationToken = default);
}