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

    public async Task<List<ContactEntity>> GetPatientContactsAsync(int page, int pageSize, Guid patientId, CancellationToken cancellationToken = default)
    {
        var query = _context.Contacts
                   .AsNoTracking()
                   .Where(cls => cls.PatientId == patientId)
                   .Select(d => new ContactEntity
                   {
                       Id = d.Id,
                       IsDeleted = d.IsDeleted,
                       CreatedOn = d.CreatedOn,
                       Type = d.Type,
                       Contact = d.Contact,
                   })
                   .OrderBy(status => status.CreatedOn)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<ContactEntity>> GetProfessionalContactsAsync(int page, int pageSize, Guid professionalId, CancellationToken cancellationToken = default)
    {
        var query = _context.Contacts
                    .AsNoTracking()
                    .Where(cls => cls.PatientId == professionalId)
                    .Select(d => new ContactEntity
                    {
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                        CreatedOn = d.CreatedOn,
                        Type = d.Type,
                        Contact = d.Contact,
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<ContactEntity>> GetClinicContactsAsync(int page, int pageSize, Guid clinicId, CancellationToken cancellationToken = default)
    {
        var query = _context.Contacts
                    .AsNoTracking()
                    .Where(cls => cls.PatientId == clinicId)
                    .Select(d => new ContactEntity
                    {
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                        CreatedOn = d.CreatedOn,
                        Type = d.Type,
                        Contact = d.Contact,
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

        return await query.ToListAsync(cancellationToken);
    }
}
