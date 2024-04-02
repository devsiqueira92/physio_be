
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.SchedulingType.Commands.Delete;

public sealed record DeleteSchedulingTypeCommand(string schedulingType, Guid userId) : IRequest<Result>;
