using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class AddressRepository : IAddressRepository
{
    private readonly PhysioContext _context;
    public AddressRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(AddressEntity entity, CancellationToken cancellationToken = default) => 
        await _context.Addresses.AddAsync(entity, cancellationToken);


    public void Update(AddressEntity entity) =>
        _context.Addresses.Update(entity);

    public async Task<List<AddressEntity>> GetPatientAddressesAsync(int page, int pageSize, Guid patientId, CancellationToken cancellationToken = default)
    {
        var query = _context.Addresses
                   .AsNoTracking()
                   .Where(cls => cls.PatientId == patientId)
                   .Select(d => new AddressEntity
                   {
                       Id = d.Id,
                       IsDeleted = d.IsDeleted,
                       CreatedOn = d.CreatedOn,
                       Number = d.Number,
                       PostalCode = d.PostalCode,
                       Street = d.Street,
                       City = d.City
                   })
                   .OrderBy(status => status.CreatedOn)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<AddressEntity>> GetProfessionalAddressesAsync(int page, int pageSize, Guid professionalId, CancellationToken cancellationToken = default)
    {
        var query = _context.Addresses
                    .AsNoTracking()
                    .Where(cls => cls.PatientId == professionalId)
                    .Select(d => new AddressEntity
                    {
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                        CreatedOn = d.CreatedOn,
                        Number = d.Number,
                        PostalCode = d.PostalCode,
                        Street = d.Street,
                        City = d.City
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<AddressEntity>> GetClinicAddressesAsync(int page, int pageSize, Guid clinicId, CancellationToken cancellationToken = default)
    {
        var query = _context.Addresses
                    .AsNoTracking()
                    .Where(cls => cls.PatientId == clinicId)
                    .Select(d => new AddressEntity
                    {
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                        CreatedOn = d.CreatedOn,
                        Number = d.Number,
                        PostalCode = d.PostalCode,
                        Street = d.Street,
                        City = d.City
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

        return await query.ToListAsync(cancellationToken);
    }
}
