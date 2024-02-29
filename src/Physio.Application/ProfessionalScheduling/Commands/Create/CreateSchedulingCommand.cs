
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Commands.Create;

public sealed record CreateProfessionalSchedulingCommand(SchedulingCreateRequest scheduling, Guid userId) : IRequest<Result<SchedulingResponse>>;
