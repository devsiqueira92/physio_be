using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Protocol.Commands.Create;

internal sealed class CreateProtocolCommandHandler : IRequestHandler<CreateProtocolCommand, Result<ProtocolResponse>>
{
    private readonly IProtocolRepository _protocolRepository;
    private readonly IUnitOfWork _unitOfWork;



    public CreateProtocolCommandHandler(IProtocolRepository protocolRepository, IUnitOfWork unitOfWork)
    {
        _protocolRepository = protocolRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProtocolResponse>> Handle(CreateProtocolCommand request, CancellationToken cancellationToken)
    {
        var newProtocol = ProtocolEntity.Create(request.protocol.name, request.protocol.member, request.protocol.description, request.userId);
        if (newProtocol.IsSuccess)
        {
            await _protocolRepository.CreateAsync(newProtocol.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ProtocolResponse(newProtocol.Value.Id, newProtocol.Value.Name, newProtocol.Value.Member, newProtocol.Value.Description);
        }

        return Result.Failure<ProtocolResponse>(newProtocol.Error);

    }
}
