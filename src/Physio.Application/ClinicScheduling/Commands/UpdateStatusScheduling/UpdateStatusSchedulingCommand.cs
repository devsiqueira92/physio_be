
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.ClinicScheduling.Commands.UpdateStatusClinicScheduling;

public sealed record UpdateStatusClinicSchedulingCommand(SchedulingUpdateStatusRequest scheduling, Guid userId) : IRequest<Result>;
