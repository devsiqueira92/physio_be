
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Commands.Create;

public sealed record CreatePatientCommand(PatientCreateRequest patient, Guid userId) : IRequest<Result<PatientResponse>>;
