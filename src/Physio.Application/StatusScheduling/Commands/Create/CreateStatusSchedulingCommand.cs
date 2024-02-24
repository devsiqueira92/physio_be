
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.StatusScheduling.Commands.Create;

public sealed record CreateStatusSchedulingCommand(StatusSchedulingCreateRequest statusScheduling, Guid userId) : IRequest<Result<StatusSchedulingResponse>>;
