using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.SchedulingType.Queries.GetById;

internal sealed class GetSchedulingTypeHandler : IRequestHandler<GetSchedulingTypeQuery, Result<SchedulingTypeResponse>>
{
    private readonly ISchedulingTypeRepository _schedulingTypeRepository;

    public GetSchedulingTypeHandler(ISchedulingTypeRepository schedulingTypeRepository)
    {
        _schedulingTypeRepository = schedulingTypeRepository;
    }

    public async Task<Result<SchedulingTypeResponse>> Handle(GetSchedulingTypeQuery request, CancellationToken cancellationToken)
    {
            var schedulingType = await _schedulingTypeRepository.GetAsync(Guid.Parse(request.id), cancellationToken);

            if (schedulingType is null)
                return Result.Failure<SchedulingTypeResponse>(DomainErrors.Generic.NotFound);

            return new SchedulingTypeResponse(schedulingType.Id, schedulingType.Name);
    }
}
