using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class ProtocolRepository : IProtocolRepository
{
    private readonly PhysioContext _context;
    public ProtocolRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ProtocolEntity entity, CancellationToken cancellationToken = default) => 
        await _context.Protocols.AddAsync(entity, cancellationToken);


    public void Update(ProtocolEntity entity) =>
        _context.Protocols.Update(entity);

    public async Task<List<ProtocolEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.Protocols
                    .AsNoTracking()
                    .Select(d => new ProtocolEntity
                    {
                        Name = d.Name,
                        Member = d.Member,
                        Description = d.Description,
                        Id = d.Id,
                        CreatedOn = d.CreatedOn,
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<ProtocolEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.Protocols
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
