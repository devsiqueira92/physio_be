

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalPatient.Queries.GetProfessionalPatients;
public record GetProfessionalPatientsQuery(PaginatedRequest request, string userId) : IRequest<Result<List<PatientResponse>>>;
