using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class PatientRepository : IPatientRepository
{
    private readonly PhysioContext _context;
    public PatientRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(PatientEntity entity, CancellationToken cancellationToken = default) => 
        await _context.Patients.AddAsync(entity, cancellationToken);


    public void Update(PatientEntity entity) =>
        _context.Patients.Update(entity);

    public async Task<List<PatientEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.Patients
                    .AsNoTracking()
                    .Select(d => new PatientEntity
                    {
                        Name = d.Name,
                        BirthDate = d.BirthDate,
                        Contact = d.Contact,
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                        CreatedOn = d.CreatedOn,
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }



    public async Task<PatientEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.Patients
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> FindByDocumentNumberAsync(string documentNumber, CancellationToken cancellationToken = default)
    {
        return await _context.Patients
                    .AsNoTracking()
                    .Where(cls => !cls.IsDeleted && cls.Contact == documentNumber).AnyAsync(cancellationToken);

    }
}
