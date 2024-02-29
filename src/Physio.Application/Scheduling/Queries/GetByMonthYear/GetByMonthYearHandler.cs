using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Queries.GetByMonthYear;

internal sealed class GetByMonthYearHandler : IRequestHandler<GetByMonthYearQuery, Result<List<SchedulingResponse>>>
{
    private readonly ISchedulingRepository _schedulingRepository;

    public GetByMonthYearHandler(ISchedulingRepository schedulingRepository)
    {
        _schedulingRepository = schedulingRepository;
    }

    public async Task<Result<List<SchedulingResponse>>> Handle(GetByMonthYearQuery request, CancellationToken cancellationToken)
    {

        var schedulings = await _schedulingRepository.GetByMonthYearAsync(request.by.month, request.by.year, request.userId);

        var list = schedulings.Select(scheduling => new SchedulingResponse(scheduling.Id, scheduling.Date, scheduling.PatientId, scheduling.ProfessionalId, scheduling.SchedulingStatusId)).ToList();

        return new List<SchedulingResponse>(list);
    }
}
