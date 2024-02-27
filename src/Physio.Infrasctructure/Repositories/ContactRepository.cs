using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class ContactRepository : IContactRepository
{
    private readonly PhysioContext _context;
    public ContactRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ContactEntity entity, CancellationToken cancellationToken = default) => 
        await _context.Contacts.AddAsync(entity, cancellationToken);


    public void Update(ContactEntity entity) =>
        _context.Contacts.Update(entity);

    public async Task<List<ContactEntity>> GetContactListAsync(string userId, CancellationToken cancellationToken = default)
    {
        var query = _context.Contacts
                    .AsNoTracking()
                    .Where(c => c.UserId == userId)
                    .Select(d => new ContactEntity
                    {
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                        CreatedOn = d.CreatedOn,
                        Type = d.Type,
                        Contact = d.Contact,
                    })
                    .OrderByDescending(status => status.CreatedOn);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<ContactEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.Contacts
                     .AsNoTracking()
                     .Where(c => c.Id == id)
                     .Select(d => new ContactEntity
                     {
                         Id = d.Id,
                         IsDeleted = d.IsDeleted,
                         CreatedOn = d.CreatedOn,
                         Type = d.Type,
                         Contact = d.Contact,
                         UserId = d.UserId,
                         CreatedBy = d.CreatedBy,
                     });

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
