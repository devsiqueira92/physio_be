using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class ProfessionalPatientRepository : IProfessionalPatientRepository
{
    private readonly PhysioContext _context;
    public ProfessionalPatientRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ProfessionalPatientEntity entity, CancellationToken cancellationToken = default) => 
        await _context.ProfessionalPatients.AddAsync(entity, cancellationToken);


    public void Update(ProfessionalPatientEntity entity) =>
        _context.ProfessionalPatients.Update(entity);

    public async Task<List<ProfessionalPatientEntity>> GetAllAsync(int page, int pagesize, string userId, CancellationToken cancellationToken = default)
    {
        var query = _context.ProfessionalPatients
                    .AsNoTracking()
                    .Where(cls => cls.ProfessionalEntity.UserId == userId)
                    .Select(d => new ProfessionalPatientEntity
                    {
                        Id = d.Id,
                        PatientId = d.PatientId,
                        ProfessionalId = d.ProfessionalId,
                        PatientEntity = new PatientEntity
                        {
                            Name = d.PatientEntity.Name,
                            Contact = d.PatientEntity.Contact,
                            BirthDate = d.PatientEntity.BirthDate
                        },
                        CreatedOn = d.CreatedOn,
                    })
                    .OrderBy(status => status.PatientEntity.Name)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<ProfessionalPatientEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.ProfessionalPatients
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> CheckAvailabilityAsync(Guid patientId, Guid professionalId, CancellationToken cancellationToken = default)
    {
        return await _context.ProfessionalPatients
                    .AsNoTracking()
                    .Where(cls => !cls.IsDeleted && cls.PatientId == patientId && cls.ProfessionalId == professionalId).AnyAsync(cancellationToken);
    }
}
