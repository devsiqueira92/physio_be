using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.Scheduling.Commands.Delete;

public sealed record DeleteSchedulingCommand(Guid scheduling) : IRequest<Result>;

