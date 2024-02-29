
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalPatient.Commands.AddPatient;

public sealed record AddProfessionalPatientCommand(ProfessionalPatientCreateRequest patient, Guid userId) : IRequest<Result<ProfessionalPatientResponse>>;
