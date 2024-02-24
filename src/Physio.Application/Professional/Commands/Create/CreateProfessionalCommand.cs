
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Commands.Create;

public sealed record CreateProfessionalCommand(ProfessionalCreateRequest professional, Guid userId) : IRequest<Result<ProfessionalResponse>>;
