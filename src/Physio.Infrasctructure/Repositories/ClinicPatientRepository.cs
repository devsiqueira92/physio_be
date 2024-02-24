using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class ClinicPatientRepository : IClinicPatientRepository
{
    private readonly PhysioContext _context;
    public ClinicPatientRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ClinicPatientEntity entity, CancellationToken cancellationToken = default) => 
        await _context.ClinicPatients.AddAsync(entity, cancellationToken);


    public void Update(ClinicPatientEntity entity) =>
        _context.ClinicPatients.Update(entity);

    public async Task<List<ClinicPatientEntity>> GetAllAsync(int page, int pagesize, string userId, CancellationToken cancellationToken = default)
    {
        var query = _context.ClinicPatients
                    .AsNoTracking()
                    .Where(cls => cls.ClinicEntity.UserId == userId)
                    .Select(d => new ClinicPatientEntity
                    {
                        Id = d.Id,
                        PatientId = d.PatientId,
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

    public async Task<ClinicPatientEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.ClinicPatients
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> CheckAvailabilityAsync(Guid patientId, Guid clinicId, CancellationToken cancellationToken = default)
    {
        return await _context.ClinicPatients
                    .AsNoTracking()
                    .Where(cls => !cls.IsDeleted && cls.PatientId == patientId && cls.ClinicId == clinicId).AnyAsync(cancellationToken);
    }

    //public async Task<ClinicPatientEntity> FindByRegisterNumberAsync(string registerNumber, CancellationToken cancellationToken = default)
    //{
    //    var query = _context.ClinicPatients
    //                .Where(cls => !cls.IsDeleted && cls.RegisterNumber == registerNumber);

    //    return await query.SingleOrDefaultAsync(cancellationToken);
    //}
}
