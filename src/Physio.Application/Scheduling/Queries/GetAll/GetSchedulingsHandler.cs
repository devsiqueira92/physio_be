using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Queries.GetAll;

internal sealed class GetSchedulingsHandler : IRequestHandler<GetSchedulingsQuery, Result<List<SchedulingResponse>>>
{
    private readonly ISchedulingRepository _schedulingRepository;

    public GetSchedulingsHandler(ISchedulingRepository schedulingRepository)
    {
        _schedulingRepository = schedulingRepository;
    }

    public async Task<Result<List<SchedulingResponse>>> Handle(GetSchedulingsQuery request, CancellationToken cancellationToken)
    {
            var schedulings = await _schedulingRepository.GetAllAsync(request.page, request.pageSize, cancellationToken);

            if (!schedulings.Any())
                return Result.Failure<List<SchedulingResponse>>(null);

            var list = schedulings.Select(scheduling => new SchedulingResponse(scheduling.Id, scheduling.Date, scheduling.PatientId, scheduling.ProfessionalId, scheduling.SchedulingStatusId)).ToList();

            return new List<SchedulingResponse>(list);
    }
}
