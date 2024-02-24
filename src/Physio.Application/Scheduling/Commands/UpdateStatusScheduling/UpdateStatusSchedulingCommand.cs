
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.Scheduling.Commands.UpdateStatusScheduling;

public sealed record UpdateStatusSchedulingCommand(SchedulingUpdateStatusRequest scheduling, Guid userId) : IRequest<Result>;
