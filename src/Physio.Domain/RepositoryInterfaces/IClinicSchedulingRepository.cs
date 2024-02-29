using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IClinicSchedulingRepository
{
    Task CreateAsync(ClinicSchedulingEntity entity, CancellationToken cancellationToken = default);
    void Update(ClinicSchedulingEntity entity);
    Task<List<ClinicSchedulingEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ClinicSchedulingEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ClinicSchedulingEntity> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<ClinicSchedulingEntity>> GetByMonthYearAsync(short month, short year, string id, CancellationToken cancellationToken = default);
    Task<List<SchedulingWithDetailsEntity>> GetByDateAsync(DateOnly date, string id, CancellationToken cancellationToken = default);

    Task<bool> CheckIfProfessionalIsAvailableAsync(DateTime date, Guid professionalId, CancellationToken cancellationToken = default);
    Task<bool> CheckIfPatientIsAvailableAsync(DateTime date, Guid patientId, Guid professionaiId, CancellationToken cancellationToken = default);
}