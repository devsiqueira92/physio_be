using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Queries.GetByDate;

internal sealed class GetByDateHandler : IRequestHandler<GetByDateQuery, Result<List<SchedulingWithDetailListResponse>>>
{
    private readonly ISchedulingRepository _schedulingRepository;

    public GetByDateHandler(ISchedulingRepository schedulingRepository)
    {
        _schedulingRepository = schedulingRepository;
    }

    public async Task<Result<List<SchedulingWithDetailListResponse>>> Handle(GetByDateQuery request, CancellationToken cancellationToken)
    {
        var schedulings = await _schedulingRepository.GetByDateAsync(request.date,request.userId, cancellationToken);

        if (schedulings is null)
            return Result.Failure<List<SchedulingWithDetailListResponse>>(DomainErrors.Generic.NotFound);

        var list = schedulings.Select(scheduling => new SchedulingWithDetailListResponse(
                scheduling.Date,
                scheduling.Schedulings.Select(s => new SchedulingDetailsResponse(
                    s.Id,
                    s.PatientEntity.Name,
                    s.ProfessionalEntity.Name,
                    s.SchedulingStatusEntity.Name
                )).ToList()
            )).ToList();

        return new List<SchedulingWithDetailListResponse>(list);
    }
}
