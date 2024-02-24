using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IProfessionalClinicRepository
{
    Task CreateAsync(ProfessionalClinicEntity entity, CancellationToken cancellationToken = default);
    void Update(ProfessionalClinicEntity entity);
    Task<List<ProfessionalClinicEntity>> GetAllAsync(int page, int pageSize, string userId, CancellationToken cancellationToken = default);
    Task<bool> CheckAvailabilityAsync(Guid professionalId, Guid clinicId, CancellationToken cancellationToken = default);
    //Task<ProfessionalClinicEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    //Task<bool> CheckAvailabilityAsync(string userId, CancellationToken cancellationToken = default);
}