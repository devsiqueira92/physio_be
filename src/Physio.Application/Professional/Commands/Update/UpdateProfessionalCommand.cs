
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.Professional.Commands.Update;

public sealed record UpdateProfessionalCommand(ProfessionalUpdateRequest professional, Guid userId) : IRequest<Result>;
