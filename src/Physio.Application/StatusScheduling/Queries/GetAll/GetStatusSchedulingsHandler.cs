using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.StatusScheduling.Queries.GetAll;

internal sealed class GetStatusSchedulingsHandler : IRequestHandler<GetStatusSchedulingsQuery, Result<List<StatusSchedulingResponse>>>
{
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;

    public GetStatusSchedulingsHandler(IStatusSchedulingRepository statusSchedulingRepository)
    {
        _statusSchedulingRepository = statusSchedulingRepository;
    }

    public async Task<Result<List<StatusSchedulingResponse>>> Handle(GetStatusSchedulingsQuery request, CancellationToken cancellationToken)
    {
            var statusSchedulings = await _statusSchedulingRepository.GetAllAsync(cancellationToken);

            if (!statusSchedulings.Any())
                return Result.Failure<List<StatusSchedulingResponse>>(null);

            var list = statusSchedulings.Select(statusScheduling => new StatusSchedulingResponse(statusScheduling.Id, statusScheduling.Name)).ToList();

            return new List<StatusSchedulingResponse>(list);
    }
}
