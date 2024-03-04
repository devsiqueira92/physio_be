using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Commands.Create;

public sealed record CreateClinicSchedulingCommand(SchedulingCreateRequest scheduling, string userId) : IRequest<Result<SchedulingResponse>>;
