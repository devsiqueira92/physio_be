

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Queries.GetById;
public record GetPatientQuery(string id) : IRequest<Result<PatientResponse>>;
