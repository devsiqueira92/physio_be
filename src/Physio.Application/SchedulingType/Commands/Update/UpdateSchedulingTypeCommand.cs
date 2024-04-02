
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.SchedulingType.Commands.Update;

public sealed record UpdateSchedulingTypeCommand(SchedulingTypeUpdateRequest schedulingType, Guid userId) : IRequest<Result>;
