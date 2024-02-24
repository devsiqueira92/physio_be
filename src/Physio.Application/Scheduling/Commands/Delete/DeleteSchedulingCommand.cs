
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.Scheduling.Commands.Delete;

public sealed record DeleteSchedulingCommand(string scheduling, Guid userId) : IRequest<Result>;
