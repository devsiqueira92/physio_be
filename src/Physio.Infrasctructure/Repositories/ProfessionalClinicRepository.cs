using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class ProfessionalClinicRepository : IProfessionalClinicRepository
{
    private readonly PhysioContext _context;
    public ProfessionalClinicRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ProfessionalClinicEntity entity, CancellationToken cancellationToken = default) => 
        await _context.ProfessionalClinics.AddAsync(entity, cancellationToken);


    public void Update(ProfessionalClinicEntity entity) =>
        _context.ProfessionalClinics.Update(entity);

    public async Task<List<ProfessionalClinicEntity>> GetAllAsync(int page, int pagesize, string userId, CancellationToken cancellationToken = default)
    {
        var query = _context.ProfessionalClinics
                    .AsNoTracking()
                    .Where(cls => cls.ClinicEntity.UserId == userId)
                    .Select(d => new ProfessionalClinicEntity
                    {
                        Id = d.Id,
                        ProfessionalId = d.ProfessionalId,
                        ProfessionalEntity = new ProfessionalEntity
                        {
                            AppointmentValue = d.ProfessionalEntity.AppointmentValue,
                            Name = d.ProfessionalEntity.Name,
                            Contact = d.ProfessionalEntity.Contact,
                            RegisterNumber = d.ProfessionalEntity.RegisterNumber,
                            BirthDate = d.ProfessionalEntity.BirthDate
                        },
                        CreatedOn = d.CreatedOn,
                    })
                    .OrderBy(status => status.ProfessionalEntity.Name)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<ProfessionalClinicEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.ProfessionalClinics
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> CheckAvailabilityAsync(Guid professionalId, Guid clinicId, CancellationToken cancellationToken = default)
    {
        return await _context.ProfessionalClinics
                    .AsNoTracking()
                    .Where(cls => !cls.IsDeleted && cls.ProfessionalId == professionalId && cls.ClinicId == clinicId).AnyAsync(cancellationToken);
    }

    //public async Task<ProfessionalClinicEntity> FindByRegisterNumberAsync(string registerNumber, CancellationToken cancellationToken = default)
    //{
    //    var query = _context.ProfessionalClinics
    //                .Where(cls => !cls.IsDeleted && cls.RegisterNumber == registerNumber);

    //    return await query.SingleOrDefaultAsync(cancellationToken);
    //}
}
