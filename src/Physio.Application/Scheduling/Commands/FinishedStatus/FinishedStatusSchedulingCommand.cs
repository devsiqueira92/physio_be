using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.Scheduling.Commands.FinishedStatus;

public sealed record FinishedStatusSchedulingCommand(Guid id, Guid userId) : IRequest<Result>;
