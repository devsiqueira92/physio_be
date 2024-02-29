

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Queries.GetAll;
public record GetProfessionalSchedulingsQuery(int pageSize = 10, int page = 1) : IRequest<Result<List<SchedulingResponse>>>;
