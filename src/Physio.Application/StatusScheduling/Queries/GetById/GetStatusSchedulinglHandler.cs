using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.StatusScheduling.Queries.GetById;

internal sealed class GetStatusSchedulingHandler : IRequestHandler<GetStatusSchedulingQuery, Result<StatusSchedulingResponse>>
{
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;

    public GetStatusSchedulingHandler(IStatusSchedulingRepository statusSchedulingRepository)
    {
        _statusSchedulingRepository = statusSchedulingRepository;
    }

    public async Task<Result<StatusSchedulingResponse>> Handle(GetStatusSchedulingQuery request, CancellationToken cancellationToken)
    {
            var statusScheduling = await _statusSchedulingRepository.GetAsync(Guid.Parse(request.id), cancellationToken);

            if (statusScheduling is null)
                return Result.Failure<StatusSchedulingResponse>(DomainErrors.Generic.NotFound);

            return new StatusSchedulingResponse(statusScheduling.Id, statusScheduling.Name);
    }
}
