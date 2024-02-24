
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Protocol.Commands.Create;

public sealed record CreateProtocolCommand(ProtocolCreateRequest protocol, Guid userId) : IRequest<Result<ProtocolResponse>>;
