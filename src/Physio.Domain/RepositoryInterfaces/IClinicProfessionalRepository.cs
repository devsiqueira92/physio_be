using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IClinicProfessionalRepository
{
    Task CreateAsync(ClinicProfessionalEntity entity, CancellationToken cancellationToken = default);
    void Update(ClinicProfessionalEntity entity);
    Task<List<ClinicProfessionalEntity>> GetAllAsync(int page, int pageSize, string userId, CancellationToken cancellationToken = default);
    Task<bool> CheckAvailabilityAsync(Guid professionalId, Guid clinicId, CancellationToken cancellationToken = default);
}