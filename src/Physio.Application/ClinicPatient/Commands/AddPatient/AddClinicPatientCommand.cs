
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicPatient.Commands.AddPatient;

public sealed record AddClinicPatientCommand(ClinicPatientCreateRequest patient, Guid userId, Guid clinicId) : IRequest<Result<ClinicPatientResponse>>;
