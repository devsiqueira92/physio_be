using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.SchedulingType.Queries.GetAll;

internal sealed class GetSchedulingTypesHandler : IRequestHandler<GetSchedulingTypesQuery, Result<List<SchedulingTypeResponse>>>
{
    private readonly ISchedulingTypeRepository _schedulingTypeRepository;

    public GetSchedulingTypesHandler(ISchedulingTypeRepository schedulingTypeRepository)
    {
        _schedulingTypeRepository = schedulingTypeRepository;
    }

    public async Task<Result<List<SchedulingTypeResponse>>> Handle(GetSchedulingTypesQuery request, CancellationToken cancellationToken)
    {
            var schedulingTypes = await _schedulingTypeRepository.GetAllAsync(cancellationToken);

            if (!schedulingTypes.Any())
                return Result.Failure<List<SchedulingTypeResponse>>(null);

            var list = schedulingTypes.Select(schedulingType => new SchedulingTypeResponse(schedulingType.Id, schedulingType.Name)).ToList();

            return new List<SchedulingTypeResponse>(list);
    }
}
