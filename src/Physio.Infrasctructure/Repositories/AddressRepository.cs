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

    public async Task<List<AddressEntity>> GetAddressListAsync(string userId, CancellationToken cancellationToken = default)
    {
        var query = _context.Addresses
                   .AsNoTracking()
                   .Where(c => c.UserId == userId)
                   .Select(d => new AddressEntity
                   {
                       Id = d.Id,
                       IsDeleted = d.IsDeleted,
                       CreatedOn = d.CreatedOn,
                       UserId = userId,
                       City = d.City,
                       PostalCode = d.PostalCode,   
                       Street = d.Street,   
                       Number = d.Number,
                       
                   })
                   .OrderByDescending(status => status.CreatedOn);

        return await query.ToListAsync(cancellationToken);
    }







    //example porpouse only. Try in another circustances
    public async Task<object> GetPatientAddressesUsingCursorAsync(int page, int pageSize, Guid patientId, CancellationToken cancellationToken = default)
    {
        DateTime? createdOnCursor = new DateTime(2022, 10, 12);

        var query = await _context.Addresses
                   .AsNoTracking()
                   //.Where(cls => cls.PatientId == patientId && cls.CreatedOn > createdOnCursor)
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
                   .Take(pageSize)
                   .ToListAsync(cancellationToken);

        //store on cache/localStorage
        var nextCursor = query[^1].CreatedOn;

        return (query, nextCursor);
    }


}
