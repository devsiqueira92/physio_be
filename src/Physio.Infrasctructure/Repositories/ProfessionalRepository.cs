using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;
using System.Linq;

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

    public async Task<bool> CheckAvailabilityAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await _context.Professionals
                    .AsNoTracking()
                    .Where(cls => !cls.IsDeleted && cls.UserId == userId).AnyAsync(cancellationToken);
    }

    public async Task<ProfessionalEntity> FindByRegisterNumberAsync(string registerNumber, CancellationToken cancellationToken = default)
    {
        var query = _context.Professionals
                    .Where(cls => !cls.IsDeleted && cls.RegisterNumber == registerNumber);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ProfessionalEntity> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        var query = _context.Professionals
                    .Select(d => new ProfessionalEntity
                    {
                        UserId = d.UserId,
                        Id = d.Id,
                        Name = d.Name,
                        RegisterNumber = d.RegisterNumber,
                        BirthDate = d.BirthDate,
                        AppointmentValue = d.AppointmentValue,
                        CreatedOn = d.CreatedOn,
                        IsDeleted = d.IsDeleted,
                        UserEntity = new UserEntity
                        {
                            LoginType = d.UserEntity.LoginType,
                        },
                        
                    })
                   .Where(cls => !cls.IsDeleted && cls.UserId == userId);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ProfessionalEntity> GetUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        var query = _context.Professionals
                    .Select(d => new ProfessionalEntity
                    {
                        UserId = d.UserId,
                        IsDeleted = d.IsDeleted,
                    })
                   .Where(cls => !cls.IsDeleted && cls.UserId == userId);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
