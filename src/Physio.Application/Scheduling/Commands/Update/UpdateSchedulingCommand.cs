using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.Scheduling.Commands.Update;

public sealed record UpdateSchedulingCommand(SchedulingUpdateRequest scheduling, Guid userId) : IRequest<Result>;
