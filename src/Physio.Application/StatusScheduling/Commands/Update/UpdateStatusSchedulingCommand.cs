
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.StatusScheduling.Commands.Update;

public sealed record UpdateStatusSchedulingCommand(StatusSchedulingUpdateRequest statusScheduling, Guid userId) : IRequest<Result>;
