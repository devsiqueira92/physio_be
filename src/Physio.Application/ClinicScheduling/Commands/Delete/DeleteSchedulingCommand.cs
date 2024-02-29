
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.ClinicScheduling.Commands.Delete;

public sealed record DeleteClinicSchedulingCommand(string scheduling, Guid userId) : IRequest<Result>;
