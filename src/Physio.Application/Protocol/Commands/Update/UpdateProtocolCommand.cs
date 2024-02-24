
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.Protocol.Commands.Update;

public sealed record UpdateProtocolCommand(ProtocolUpdateRequest protocol, Guid userId) : IRequest<Result>;
