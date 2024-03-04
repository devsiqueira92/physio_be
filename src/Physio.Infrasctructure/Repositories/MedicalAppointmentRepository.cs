using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrasctructure.Repositories;

internal class MedicalAppointmentRepository : IMedicalAppointmentRepository
{
    private readonly PhysioContext _context;
    public MedicalAppointmentRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(MedicalAppointmentEntity entity, CancellationToken cancellationToken = default) =>
        await _context.MedicalAppointments.AddAsync(entity, cancellationToken);

    public async Task<MedicalAppointmentEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.MedicalAppointments
                   .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<List<MedicalAppointmentEntity>> GetPatientAppointmentsAsync(Guid patientId, int pagesize, int page, CancellationToken cancellationToken = default)
    {
        var query = _context.MedicalAppointments
                    .AsNoTracking()
                    .Where(cls => cls.SchedulingEntity.PatientId == patientId)
                   
                    .OrderByDescending(status => status.SchedulingEntity.Date)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<MedicalAppointmentEntity>> GetProfessionalAppointmentsAsync(Guid professionalId, int pagesize, int page, CancellationToken cancellationToken = default)
    {
        var query = _context.MedicalAppointments
                    .AsNoTracking()
                    .Where(cls => cls.SchedulingEntity.ProfessionalId == professionalId)
                   
                    .OrderByDescending(status => status.SchedulingEntity.Date)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public void Update(MedicalAppointmentEntity entity) =>
        _context.MedicalAppointments.Update(entity);
}
