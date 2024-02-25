using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IContactRepository
{
    Task CreateAsync(ContactEntity entity, CancellationToken cancellationToken = default);
    void Update(ContactEntity entity);
    Task<List<ContactEntity>> GetPatientContactsAsync(int page, int pageSize, Guid patientId, CancellationToken cancellationToken = default);
    Task<List<ContactEntity>> GetProfessionalContactsAsync(int page, int pageSize, Guid professionalId, CancellationToken cancellationToken = default);
    Task<List<ContactEntity>> GetClinicContactsAsync(int page, int pageSize, Guid clinicId, CancellationToken cancellationToken = default);
}