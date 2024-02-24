using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IClinicPatientRepository
{
    Task CreateAsync(ClinicPatientEntity entity, CancellationToken cancellationToken = default);
    void Update(ClinicPatientEntity entity);
    Task<List<ClinicPatientEntity>> GetAllAsync(int page, int pageSize, string userId, CancellationToken cancellationToken = default);
    Task<bool> CheckAvailabilityAsync(Guid patientId, Guid clinicId, CancellationToken cancellationToken = default);
    //Task<ClinicPatientEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    //Task<bool> CheckAvailabilityAsync(string userId, CancellationToken cancellationToken = default);
}