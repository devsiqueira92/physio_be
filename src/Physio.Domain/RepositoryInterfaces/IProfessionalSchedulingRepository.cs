using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IProfessionalSchedulingRepository
{
    Task CreateAsync(ProfessionalSchedulingEntity entity, CancellationToken cancellationToken = default);
    void Update(ProfessionalSchedulingEntity entity);
    Task<List<ProfessionalSchedulingEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ProfessionalSchedulingEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ProfessionalSchedulingEntity> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<ProfessionalSchedulingEntity>> GetByMonthYearAsync(short month, short year, string id, CancellationToken cancellationToken = default);
    Task<List<SchedulingWithDetailsEntity>> GetByDateAsync(DateOnly date, string id, CancellationToken cancellationToken = default);

    Task<bool> CheckIfProfessionalIsAvailableAsync(DateTime date, Guid professionalId, CancellationToken cancellationToken = default);
    Task<bool> CheckIfPatientIsAvailableAsync(DateTime date, Guid patientId, Guid professionaiId, CancellationToken cancellationToken = default);
}