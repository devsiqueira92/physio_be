

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicProfessional.Queries.GetClinicProfessionals;
public record GetClinicProfessionalsQuery(PaginatedRequest request, string userId) : IRequest<Result<List<ProfessionalResponse>>>;
