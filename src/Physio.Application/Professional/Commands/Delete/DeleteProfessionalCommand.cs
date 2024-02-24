
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.Professional.Commands.Delete;

public sealed record DeleteProfessionalCommand(string professional, Guid userId) : IRequest<Result>;
