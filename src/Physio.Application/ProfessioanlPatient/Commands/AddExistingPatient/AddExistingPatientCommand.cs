
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalPatient.Commands.AddExistingPatient;

public sealed record AddExistingPatientCommand(ProfessionalPatientAddExistingRequest patient, Guid userId) : IRequest<Result<ProfessionalPatientResponse>>;
