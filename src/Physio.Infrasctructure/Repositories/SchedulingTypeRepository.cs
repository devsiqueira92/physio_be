using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class SchedulingTypeRepository : ISchedulingTypeRepository
{
    private readonly PhysioContext _context;
    public SchedulingTypeRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(SchedulingTypeEntity entity, CancellationToken cancellationToken = default) => 
        await _context.SchedulingTypes.AddAsync(entity, cancellationToken);


    public void Update(SchedulingTypeEntity entity) =>
        _context.SchedulingTypes.Update(entity);

    public async Task<List<SchedulingTypeEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var query = _context.SchedulingTypes
                    .AsNoTracking()
                    .Select(d => new SchedulingTypeEntity
                    {
                        Name = d.Name,
                        Id = d.Id,
                    })
                    .OrderBy(status => status.Name);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<SchedulingTypeEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.SchedulingTypes
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
