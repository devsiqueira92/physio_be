
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicProfessional.Commands.AddProfessional;

public sealed record AddProfessionalCommand(ProfessionalClinicCreateRequest professional, Guid userId) : IRequest<Result<ProfessionalClinicResponse>>;
