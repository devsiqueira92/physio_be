

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Queries.GetAll;
public record GetPatientsQuery(string userId) : IRequest<Result<List<PatientResponse>>>;
