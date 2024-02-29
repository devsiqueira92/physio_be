
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.ProfessionalScheduling.Commands.Update;

public sealed record UpdateProfessionalSchedulingCommand(SchedulingUpdateRequest scheduling, Guid userId) : IRequest<Result>;
