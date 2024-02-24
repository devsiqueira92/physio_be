using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Protocol.Commands.Delete;

internal sealed class DeleteProtocolCommandHandler : IRequestHandler<DeleteProtocolCommand, Result>
{
    private readonly IProtocolRepository _protocolRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProtocolCommandHandler(IProtocolRepository protocolRepository, IUnitOfWork unitOfWork)
    {
        _protocolRepository = protocolRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProtocolCommand request, CancellationToken cancellationToken)
    {
        var protocol = await _protocolRepository.GetAsync(Guid.Parse(request.protocol));
        if (protocol is not null)
        {
            protocol.Delete(request.userId);

            _protocolRepository.Update(protocol);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<ProtocolResponse>(DomainErrors.Generic.UpdateError);

    }
}
