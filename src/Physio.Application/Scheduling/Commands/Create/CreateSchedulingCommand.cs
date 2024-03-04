using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Commands.Create;

public sealed record CreateSchedulingCommand(SchedulingCreateRequest scheduling, Guid userId) : IRequest<Result<SchedulingResponse>>;
