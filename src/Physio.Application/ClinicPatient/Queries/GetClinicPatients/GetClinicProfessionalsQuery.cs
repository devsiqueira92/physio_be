

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicPatient.Queries.GetClinicPatients;
public record GetClinicPatientsQuery(PaginatedRequest request, string userId) : IRequest<Result<List<PatientResponse>>>;
