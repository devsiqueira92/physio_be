
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicPatient.Commands.AddExistingPatient;

public sealed record AddExistingPatientCommand(ClinicPatientAddExistingRequest patient, Guid userId, Guid clinicId) : IRequest<Result<ClinicPatientResponse>>;
