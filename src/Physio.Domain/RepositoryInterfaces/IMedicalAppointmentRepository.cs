using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IMedicalAppointmentRepository
{
    Task CreateAsync(MedicalAppointmentEntity entity, CancellationToken cancellationToken = default);
    void Update(MedicalAppointmentEntity entity);
    Task<MedicalAppointmentEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<MedicalAppointmentEntity>> GetProfessionalAppointmentsAsync(Guid professionalId, int pagesize, int page, CancellationToken cancellationToken = default);
    Task<List<MedicalAppointmentEntity>> GetPatientAppointmentsAsync(Guid patientId, int pagesize, int page, CancellationToken cancellationToken = default);

    //Task<List<MedicalAppointmentEntity>> GetMyAppointmentsAsync(string userId, CancellationToken cancellationToken = default);
}