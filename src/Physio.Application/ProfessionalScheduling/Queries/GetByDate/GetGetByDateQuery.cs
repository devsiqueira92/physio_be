

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Queries.GetByDate;
public record GetByDateQuery(DateOnly date, string userId) : IRequest<Result<List<SchedulingWithDetailListResponse>>>;
