using Microsoft.EntityFrameworkCore;
using Physio.Domain;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;
namespace Physio.Infrastructure.Repositories;

internal sealed class ClinicSchedulingRepository : IClinicSchedulingRepository
{
    private readonly PhysioContext _context;
    public ClinicSchedulingRepository(PhysioContext context) => _context = context;

    public async Task CreateAsync(ClinicSchedulingEntity entity, CancellationToken cancellationToken = default) => 
        await _context.ClinicSchedulings.AddAsync(entity, cancellationToken);


    public void Update(ClinicSchedulingEntity entity) =>
        _context.ClinicSchedulings.Update(entity);

    public async Task<List<ClinicSchedulingEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.ClinicSchedulings
                    .AsNoTracking()
                    .Select(d => new ClinicSchedulingEntity
                    {
                        Date = d.Date,
                        PatientId = d.PatientId,
                        ProfessionalId = d.ProfessionalId,
                        SchedulingStatusId = d.SchedulingStatusId,
                        Id = d.Id,
                        CreatedOn = d.CreatedOn,
                    })
                    .OrderBy(status => status.CreatedOn)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<ClinicSchedulingEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.ClinicSchedulings
                    .Where(cls => !cls.IsDeleted && cls.Id == id)
                    .Select(d => new ClinicSchedulingEntity
                    {
                        Date = d.Date,
                        PatientId = d.PatientId,
                        ProfessionalId = d.ProfessionalId,
                        SchedulingStatusId = d.SchedulingStatusId,
                        SchedulingTypeId = d.SchedulingTypeId,
                        Id = d.Id,
                        CreatedOn = d.CreatedOn,
                    });

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ClinicSchedulingEntity> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.ClinicSchedulings
                    .Where(cls => !cls.IsDeleted && cls.Id == id)
                    .Select(d => new ClinicSchedulingEntity
                    {
                        Date = d.Date,
                        PatientId = d.PatientId,
                        ProfessionalId = d.ProfessionalId,
                        SchedulingStatusId = d.SchedulingStatusId,
                        SchedulingTypeEntity = new SchedulingTypeEntity
                        {
                           Name = d.SchedulingTypeEntity.Name, 
                        },
                        SchedulingStatusEntity = new StatusSchedulingEntity
                        {
                            Name = d.SchedulingStatusEntity.Name,
                        },

                        ProfessionalEntity = new ProfessionalEntity
                        {
                            Name = d.ProfessionalEntity.Name,
                        },

                        PatientEntity = new PatientEntity
                        {
                            Name = d.PatientEntity.Name,
                            Contact = d.PatientEntity.Contact,
                            BirthDate = d.PatientEntity.BirthDate,
                        },


                        Id = d.Id,
                        CreatedOn = d.CreatedOn,
                    });

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<List<ClinicSchedulingEntity>> GetByMonthYearAsync(short month, short year, string id, CancellationToken cancellationToken = default)
    {
        var query = _context.ClinicSchedulings
                    .Where(sc => (sc.Date.Month == month && sc.Date.Year == year) && (sc.ClinicEntity.UserId == id || sc.ProfessionalEntity.UserId == id))
                    .Select(d => new ClinicSchedulingEntity
                    {
                        Date = d.Date,
                        SchedulingStatusEntity = new StatusSchedulingEntity { Name = d.SchedulingStatusEntity.Name },
                        Id = d.Id,
                    })
                    .OrderBy(status => status.Date);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<SchedulingWithDetailsEntity>> GetByDateAsync(DateOnly date, string id, CancellationToken cancellationToken = default)
    {
        var query = await _context.ClinicSchedulings
        .AsNoTracking()
        .Where(sc => (DateOnly.FromDateTime(sc.Date) == date &&
            !sc.PatientEntity.IsDeleted &&
            !sc.ProfessionalEntity.IsDeleted &&
            !sc.SchedulingStatusEntity.IsDeleted) &&
            (sc.ClinicEntity.UserId == id || sc.ProfessionalEntity.UserId == id)
        )
        .GroupBy(group => group.Date)
        .Select(x => new SchedulingWithDetailsEntity
        {
            Date = x.Key,
            Schedulings = x.Select(r => new SchedulingEntity
            {
                Date = r.Date,
                Id = r.Id,
                PatientEntity = new PatientEntity { Name = r.PatientEntity.Name },
                SchedulingStatusEntity = new StatusSchedulingEntity { Name = r.SchedulingStatusEntity.Name },
                ProfessionalEntity = new ProfessionalEntity { Name = r.ProfessionalEntity.Name },
            }).ToList(),
        })
        .ToListAsync(cancellationToken);

        return query;
    }

    public async Task<bool> CheckIfProfessionalIsAvailableAsync(DateTime date, Guid professionalId, CancellationToken cancellationToken = default)
    {
        return await _context.ClinicSchedulings
            .AsNoTracking()
            .AnyAsync(sc => !sc.IsDeleted && 
                sc.Date == date && 
                sc.ProfessionalId == professionalId &&
                sc.SchedulingStatusEntity.Status != StatusSchedulingEnum.Cancelado,
                cancellationToken
            );
    }

    public async Task<bool> CheckIfPatientIsAvailableAsync(DateTime date, Guid patientId, Guid professionaiId, CancellationToken cancellationToken = default)
    {
        return await _context.ClinicSchedulings
            .AsNoTracking()
            .AnyAsync(sc => !sc.IsDeleted && 
                sc.Date == date &&
                sc.ProfessionalId == professionaiId &&
                sc.PatientId == patientId &&
                sc.SchedulingStatusEntity.Status != StatusSchedulingEnum.Cancelado,
                cancellationToken
            );
    }


}
