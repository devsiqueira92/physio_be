﻿using Physio.Domain.Entities;

namespace Physio.Domain.RepositoryInterfaces;

public interface ISchedulingRepository
{
    Task CreateAsync(SchedulingEntity entity, CancellationToken cancellationToken = default);
    void Update(SchedulingEntity entity);
    Task<List<SchedulingEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<SchedulingEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<SchedulingEntity> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<SchedulingEntity>> GetByMonthYearAsync(short month, short year, CancellationToken cancellationToken = default);
    Task<List<SchedulingWithDetailsEntity>> GetByDateAsync(DateOnly date, CancellationToken cancellationToken = default);

    Task<bool> CheckIfProfessionalIsAvailableAsync(DateTime date, Guid professionalId, CancellationToken cancellationToken = default);
    Task<bool> CheckIfPatientIsAvailableAsync(DateTime date, Guid patientId, Guid professionaiId, CancellationToken cancellationToken = default);
}