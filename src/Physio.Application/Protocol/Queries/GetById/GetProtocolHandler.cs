using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Protocol.Queries.GetById;

internal sealed class GetProtocolHandler : IRequestHandler<GetProtocolQuery, Result<ProtocolResponse>>
{
    private readonly IProtocolRepository _protocolRepository;

    public GetProtocolHandler(IProtocolRepository protocolRepository)
    {
        _protocolRepository = protocolRepository;
    }

    public async Task<Result<ProtocolResponse>> Handle(GetProtocolQuery request, CancellationToken cancellationToken)
    {
            var protocol = await _protocolRepository.GetAsync(Guid.Parse(request.id), cancellationToken);

            if (protocol is null)
                return Result.Failure<ProtocolResponse>(DomainErrors.Generic.NotFound);

            return new ProtocolResponse(protocol.Id, protocol.Name, protocol.Member, protocol.Description);
    }
}
