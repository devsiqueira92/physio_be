
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.Patient.Commands.Update;

public sealed record UpdatePatientCommand(PatientUpdateRequest patient, Guid userId) : IRequest<Result>;
