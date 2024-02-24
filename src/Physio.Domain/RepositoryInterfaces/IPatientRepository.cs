using Physio.Domain.Entities;
using Physio.Domain.Shared;

namespace Physio.Domain.RepositoryInterfaces;

public interface IPatientRepository
{
    Task CreateAsync(PatientEntity entity, CancellationToken cancellationToken = default);
    void Update(PatientEntity entity);
    Task<List<PatientEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<PatientEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> FindByDocumentNumberAsync(string documentNumber, CancellationToken cancellationToken = default);
}