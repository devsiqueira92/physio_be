using Microsoft.EntityFrameworkCore;
using Physio.Domain;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class StatusSchedulingRepository : IStatusSchedulingRepository
{
    private readonly PhysioContext _context;
    public StatusSchedulingRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(StatusSchedulingEntity entity, CancellationToken cancellationToken = default) => 
        await _context.SchedulingStatuses.AddAsync(entity, cancellationToken);


    public void Update(StatusSchedulingEntity entity) =>
        _context.SchedulingStatuses.Update(entity);

    public async Task<List<StatusSchedulingEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var query = _context.SchedulingStatuses
                    .AsNoTracking()
                    .Select(d => new StatusSchedulingEntity
                    {
                        Name = d.Name,
                        Id = d.Id,
                    })
                    .OrderBy(status => status.Name);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<StatusSchedulingEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.SchedulingStatuses
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<StatusSchedulingEntity> GetByEnumAsync(StatusSchedulingEnum schedulingEnum, CancellationToken cancellationToken = default)
    {
        var query = _context.SchedulingStatuses
                    .Where(cls => !cls.IsDeleted && cls.Status == schedulingEnum);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
