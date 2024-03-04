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
        var schedulings = await _schedulingRepository.GetProfessionalAgendaByMonthYearAsync(request.scheduling.month, request.scheduling.year, request.userId, cancellationToken);

        if (!schedulings.Any())
            return Result.Failure<List<SchedulingResponse>>(null);

        var list = schedulings.Select(scheduling => new SchedulingResponse(scheduling.Id, scheduling.Date, scheduling.PatientId, scheduling.ProfessionalId, scheduling.SchedulingTypeId)).ToList();

        return new List<SchedulingResponse>(list);
    }
}
