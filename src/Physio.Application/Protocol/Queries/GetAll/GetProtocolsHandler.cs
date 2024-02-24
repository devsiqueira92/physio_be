using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Protocol.Queries.GetAll;

internal sealed class GetProtocolsHandler : IRequestHandler<GetProtocolsQuery, Result<List<ProtocolResponse>>>
{
    private readonly IProtocolRepository _protocolRepository;

    public GetProtocolsHandler(IProtocolRepository protocolRepository)
    {
        _protocolRepository = protocolRepository;
    }

    public async Task<Result<List<ProtocolResponse>>> Handle(GetProtocolsQuery request, CancellationToken cancellationToken)
    {
            var protocols = await _protocolRepository.GetAllAsync(request.page, request.pageSize, cancellationToken);

            if (!protocols.Any())
                return Result.Failure<List<ProtocolResponse>>(null);

            var list = protocols.Select(protocol => new ProtocolResponse(protocol.Id, protocol.Name, protocol.Member, protocol.Description)).ToList();

            return new List<ProtocolResponse>(list);
    }
}
