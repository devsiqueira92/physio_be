using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IProfessionalRepository
{
    Task CreateAsync(ProfessionalEntity entity, CancellationToken cancellationToken = default);
    void Update(ProfessionalEntity entity);
    Task<List<ProfessionalEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ProfessionalEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> CheckAvailabilityAsync(string userId, CancellationToken cancellationToken = default);
    Task<ProfessionalEntity> FindByRegisterNumberAsync(string registerNumber, CancellationToken cancellationToken = default);
}