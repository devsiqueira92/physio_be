
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicProfessional.Commands.AddExistingProfessional;

public sealed record AddExistingPatientCommandHandler(ClinicPatientAddExistingRequest professional, Guid userId) : IRequest<Result<ProfessionalClinicResponse>>;
