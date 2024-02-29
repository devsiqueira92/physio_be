using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IProfessionalPatientRepository
{
    Task CreateAsync(ProfessionalPatientEntity entity, CancellationToken cancellationToken = default);
    void Update(ProfessionalPatientEntity entity);
    Task<List<ProfessionalPatientEntity>> GetAllAsync(int page, int pageSize, string userId, CancellationToken cancellationToken = default);
    Task<bool> CheckAvailabilityAsync(Guid patientId, Guid clinicId, CancellationToken cancellationToken = default);
}