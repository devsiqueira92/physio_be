﻿using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class ClinicRepository : IClinicRepository
{
    private readonly PhysioContext _context;
    public ClinicRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ClinicEntity entity, CancellationToken cancellationToken = default) => 
        await _context.Clinics.AddAsync(entity, cancellationToken);


    public void Update(ClinicEntity entity) =>
        _context.Clinics.Update(entity);

    public async Task<List<ClinicEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.Clinics
                    .AsNoTracking()
                    .Select(d => new ClinicEntity
                    {
                        Name = d.Name,
                        Address= d.Address,
                        IdentificationNumber = d.IdentificationNumber,
                        Contact = d.Contact,
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                        CreatedOn = d.CreatedOn,
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<ClinicEntity> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _context.Clinics
            .Where(cls => !cls.IsDeleted && cls.Id == id)
            .SingleOrDefaultAsync(cancellationToken);


    public async Task<bool> CheckAvailabilityAsync(string userId, CancellationToken cancellationToken = default) => 
        await _context.Clinics
                   .AsNoTracking()
                   .Where(cls => !cls.IsDeleted && cls.UserId == userId).AnyAsync(cancellationToken);
}