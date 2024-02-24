using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Protocol.Commands.Update;

internal sealed class UpdateProtocolCommandHandler : IRequestHandler<UpdateProtocolCommand, Result>
{
    private readonly IProtocolRepository _protocolRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProtocolCommandHandler(IProtocolRepository protocolRepository, IUnitOfWork unitOfWork)
    {
        _protocolRepository = protocolRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateProtocolCommand request, CancellationToken cancellationToken)
    {
        var protocol = await _protocolRepository.GetAsync(request.protocol.id);
        if (protocol is not null)
        {
            protocol.Update(request.protocol.name, request.protocol.member, request.protocol.description, request.userId);

            _protocolRepository.Update(protocol);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<ProtocolResponse>(DomainErrors.Generic.UpdateError);

    }
}
