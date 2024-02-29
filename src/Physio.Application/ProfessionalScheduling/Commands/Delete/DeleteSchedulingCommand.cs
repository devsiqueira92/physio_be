
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.ProfessionalScheduling.Commands.Delete;

public sealed record DeleteProfessionalSchedulingCommand(string scheduling, Guid userId) : IRequest<Result>;
