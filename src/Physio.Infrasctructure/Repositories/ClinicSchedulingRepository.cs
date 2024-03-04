
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrasctructure.Repositories;

internal sealed class ClinicSchedulingRepository : IClinicSchedulingRepository
{
    private readonly PhysioContext _context;
    public ClinicSchedulingRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ClinicSchedulingEntity entity, CancellationToken cancellationToken = default) => await _context.ClinicSchedulings.AddAsync(entity, cancellationToken);

    public async Task<List<ClinicSchedulingEntity>> GetClinicSchedulingsByDateAsync(int month, int year, string userId, CancellationToken cancellationToken = default)
    {
        var query = _context.ClinicSchedulings
                    .Where(sc => (sc.SchedulingEntity.Date.Month == month && sc.SchedulingEntity.Date.Year == year) && (sc.ClinicEntity.UserId == userId))
                    .Select(d => new ClinicSchedulingEntity
                    {
                        SchedulingEntity = new SchedulingEntity
                        {
                            Id = d.Id,
                            Date = d.SchedulingEntity.Date,
                            SchedulingStatusEntity = new StatusSchedulingEntity { Name = d.SchedulingEntity.SchedulingStatusEntity.Name },
                        },
                        
                        Id = d.Id,
                    })
                    .OrderBy(status => status.SchedulingEntity.Date);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<ClinicSchedulingEntity>> GetClinicSchedulingsByProfessionalAsync(int page, int pageSize, Guid professionalId, CancellationToken cancellationToken = default)
    {
        var query = _context.ClinicSchedulings
                    .Where(sc => (sc.SchedulingEntity.ProfessionalId == professionalId))
                    .Select(d => new ClinicSchedulingEntity
                    {
                        SchedulingEntity = new SchedulingEntity
                        {
                            Id = d.Id,
                            Date = d.SchedulingEntity.Date,
                            SchedulingStatusEntity = new StatusSchedulingEntity { Name = d.SchedulingEntity.SchedulingStatusEntity.Name },
                        },

                        Id = d.Id,
                    })
                    .OrderBy(status => status.SchedulingEntity.Date)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public void Update(ClinicSchedulingEntity entity) => _context.ClinicSchedulings.Update(entity);
}
