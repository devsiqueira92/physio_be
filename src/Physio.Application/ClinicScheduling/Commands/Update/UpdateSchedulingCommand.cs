
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.ClinicScheduling.Commands.Update;

public sealed record UpdateClinicSchedulingCommand(SchedulingUpdateRequest scheduling, Guid userId) : IRequest<Result>;
