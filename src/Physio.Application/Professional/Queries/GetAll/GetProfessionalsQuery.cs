

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Queries.GetAll;
public record GetProfessionalsQuery(int pageSize = 10, int page = 1) : IRequest<Result<List<ProfessionalResponse>>>;
