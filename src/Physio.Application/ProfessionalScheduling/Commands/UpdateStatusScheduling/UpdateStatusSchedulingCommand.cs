
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.ProfessionalScheduling.Commands.UpdateStatusProfessionalScheduling;

public sealed record UpdateStatusProfessionalSchedulingCommand(SchedulingUpdateStatusRequest scheduling, Guid userId) : IRequest<Result>;
