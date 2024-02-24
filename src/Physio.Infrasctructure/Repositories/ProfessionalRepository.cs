using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class ProfessionalRepository : IProfessionalRepository
{
    private readonly PhysioContext _context;
    public ProfessionalRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ProfessionalEntity entity, CancellationToken cancellationToken = default) => 
        await _context.Professionals.AddAsync(entity, cancellationToken);


    public void Update(ProfessionalEntity entity) =>
        _context.Professionals.Update(entity);

    public async Task<List<ProfessionalEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.Professionals
                    .AsNoTracking()
                    .Select(d => new ProfessionalEntity
                    {
                        Name = d.Name,
                        BirthDate = d.BirthDate,
                        Contact = d.Contact,
                        AppointmentValue = d.AppointmentValue,
                        RegisterNumber = d.RegisterNumber,
                        Id = d.Id,
                        CreatedOn = d.CreatedOn,
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<ProfessionalEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.Professionals
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
