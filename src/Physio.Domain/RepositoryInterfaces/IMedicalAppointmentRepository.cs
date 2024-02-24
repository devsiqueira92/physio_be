using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IMedicalAppointmentRepository
{
    Task CreateAsync(MedicalAppointmentEntity entity, CancellationToken cancellationToken = default);
    void Update(MedicalAppointmentEntity entity);
    Task<List<MedicalAppointmentEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<MedicalAppointmentEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<MedicalAppointmentEntity> GetBySchedulingAsync(Guid id, CancellationToken cancellationToken = default);
}