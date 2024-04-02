
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.SchedulingType.Commands.Create;

public sealed record CreateSchedulingTypeCommand(SchedulingTypeCreateRequest schedulingType, Guid userId) : IRequest<Result<SchedulingTypeResponse>>;
