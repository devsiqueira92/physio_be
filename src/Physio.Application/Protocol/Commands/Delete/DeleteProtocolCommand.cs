
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.Protocol.Commands.Delete;

public sealed record DeleteProtocolCommand(string protocol, Guid userId) : IRequest<Result>;
