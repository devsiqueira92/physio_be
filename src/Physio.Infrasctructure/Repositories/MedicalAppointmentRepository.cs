using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class MedicalAppointmentRepository : IMedicalAppointmentRepository
{
    private readonly PhysioContext _context;
    public MedicalAppointmentRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(MedicalAppointmentEntity entity, CancellationToken cancellationToken = default) => 
        await _context.MedicalAppointments.AddAsync(entity, cancellationToken);


    public void Update(MedicalAppointmentEntity entity) =>
        _context.MedicalAppointments.Update(entity);

    public async Task<List<MedicalAppointmentEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.MedicalAppointments
                    .AsNoTracking()
                    .Select(d => new MedicalAppointmentEntity
                    {
                        BeatsPerMinute = d.BeatsPerMinute,
                        Evolution = d.Evolution,
                        Notes = d.Notes,
                        SchedulingId = d.SchedulingId,
                        BloodPressure = d.BloodPressure,
                        BloodOxygenation = d.BloodOxygenation,
                        Weight = d.Weight,
                        Id = d.Id,
                        CreatedOn = d.CreatedOn,
                        SchedulingEntity = new SchedulingEntity
                        {
                            Date = d.SchedulingEntity.Date,
                            PatientEntity = new PatientEntity { Name = d.SchedulingEntity.PatientEntity.Name },
                            ProfessionalEntity = new ProfessionalEntity { Name = d.SchedulingEntity.ProfessionalEntity.Name },
                        },
                    })
                    .OrderByDescending(status => status.CreatedOn)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<MedicalAppointmentEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.MedicalAppointments
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<MedicalAppointmentEntity> GetBySchedulingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.MedicalAppointments
                    .Where(cls => !cls.IsDeleted && cls.SchedulingId == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
