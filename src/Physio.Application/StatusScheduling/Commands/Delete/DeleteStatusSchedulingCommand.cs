
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.StatusScheduling.Commands.Delete;

public sealed record DeleteStatusSchedulingCommand(string statusScheduling, Guid userId) : IRequest<Result>;
