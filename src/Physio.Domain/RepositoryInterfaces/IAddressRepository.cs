using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface IAddressRepository
{
    Task CreateAsync(AddressEntity entity, CancellationToken cancellationToken = default);
    void Update(AddressEntity entity);
    Task<List<AddressEntity>> GetPatientAddressesAsync(int page, int pageSize, Guid patientId, CancellationToken cancellationToken = default);
    Task<List<AddressEntity>> GetProfessionalAddressesAsync(int page, int pageSize, Guid professionalId, CancellationToken cancellationToken = default);
    Task<List<AddressEntity>> GetClinicAddressesAsync(int page, int pageSize, Guid clinicId, CancellationToken cancellationToken = default);
}