using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;
using System.Linq;

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
        var schedulings = await _schedulingRepository.GetByDateAsync(request.date, request.userId, cancellationToken);

        var list = schedulings.Select(scheduling =>
                                new SchedulingWithDetailListResponse(scheduling.Date, scheduling.Schedulings.Select(sc => new SchedulingDetailsResponse(sc.Id,
                                sc.PatientEntity.Name,
                                sc.ProfessionalEntity.Name,
                                sc.SchedulingStatusEntity.Name)).ToList())
                  ).ToList();


        return list;
    }
}
